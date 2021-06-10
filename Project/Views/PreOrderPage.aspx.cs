using Project.Controllers;
using Project.Factory;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class PreOrderPage : System.Web.UI.Page
    {
        readonly PreOrderController PreOrderController = new PreOrderController();
        readonly TrHeaderController TrHeaderController = new TrHeaderController();
        readonly MsFlowerController MsFlowerController = new MsFlowerController();
        readonly MsMemberController MsMemberController = new MsMemberController();
        readonly MsEmployeeController MsEmployeeController = new MsEmployeeController();

        readonly TrHeaderFactory TrHeaderFactory = new TrHeaderFactory();
        readonly TrDetailFactory TrDetailFactory = new TrDetailFactory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Result resultAllFlower = MsFlowerController.ReadAll();
                    GridViewFlowerSelection.DataSource = (List<MsFlower>)resultAllFlower.Data;
                    GridViewFlowerSelection.DataBind();

                    List<TrDetail> toCreateTrDetail = new List<TrDetail>();
                    GridViewTransactionDetail.DataSource = toCreateTrDetail;
                    GridViewTransactionDetail.DataBind();
                    HttpContext.Current.Session["ToCreateTrDetail"] = toCreateTrDetail;

                    Result resultAllMember = MsMemberController.ReadAll();
                    List<MsMember> allMember = (List<MsMember>)resultAllMember.Data;
                    DropDownListMember.DataSource = allMember;
                    DropDownListMember.DataTextField = "MemberName";
                    DropDownListMember.DataValueField = "MemberID";
                    DropDownListMember.DataBind();

                    Result resultAllEmployee = MsEmployeeController.ReadAll();
                    List<MsEmployee> allEmployee = (List<MsEmployee>)resultAllEmployee.Data;
                    DropDownListEmployee.DataSource = allEmployee;
                    DropDownListEmployee.DataTextField = "EmployeeName";
                    DropDownListEmployee.DataValueField = "EmployeeID";
                    DropDownListEmployee.DataBind();
                }
                catch
                {
                    Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void GridViewFlowerSelection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridViewFlowerSelection.Rows[index];
            Guid flowerID = Guid.Parse(row.Cells[1].Text.ToString());

            Decimal quantity = 0;
            Decimal.TryParse(TextBoxQuantity.Text.ToString(), out quantity);
            List<TrDetail> toCreateTrDetail = (List<TrDetail>)HttpContext.Current.Session["ToCreateTrDetail"];

            switch (e.CommandName)
            {
                case "Add":
                    try
                    {
                        // kami menggunakan factory di view karena fitur preorder tidak mungkin diimplementasi dengan cara membuat semua object fieldnya menjadi parameter. soalnya field yg dipassing itu dalam bentuk one-to-many, dimana many nya bisa unlimited. sedangkan jika fieldnya dipecah satu-satu menjadi parameter akan menjadi tidak mungkin untuk dilakukan.

                        TrDetail currentTrDetail = TrDetailFactory.Create(Guid.Empty, flowerID, quantity);
                        toCreateTrDetail.Add(currentTrDetail);

                        toCreateTrDetail = toCreateTrDetail
                         .GroupBy(x => x.FlowerID)
                         .Select(x => new TrDetail()
                         {
                             DetailID = x.First().DetailID,
                             FlowerID = x.First().FlowerID.GetValueOrDefault(),
                             Quantity = x.Sum(y => y.Quantity.GetValueOrDefault())
                         }).ToList();

                        GridViewTransactionDetail.DataSource = toCreateTrDetail;
                        GridViewTransactionDetail.DataBind();
                    }
                    catch
                    {
                        HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                    }
                    break;
                default:
                    Response.Redirect("/Views/ErrorPage.aspx");
                    break;
            }
        }

        protected void GridViewTransactionDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridViewFlowerSelection.Rows[index];
            Guid flowerID = Guid.Parse(row.Cells[1].Text.ToString());
            List<TrDetail> toCreateTrDetail = (List<TrDetail>)HttpContext.Current.Session["ToCreateTrDetail"];

            switch (e.CommandName)
            {
                case "Remove":
                    try
                    {
                        TrDetail currentTrDetail = toCreateTrDetail.Where(x => x.FlowerID.Equals(flowerID)).FirstOrDefault();
                        toCreateTrDetail.Remove(currentTrDetail);
                        GridViewTransactionDetail.DataSource = toCreateTrDetail;
                        GridViewTransactionDetail.DataBind();
                    }
                    catch
                    {
                        HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                    }
                    break;
                default:
                    Response.Redirect("/Views/ErrorPage.aspx");
                    break;
            }
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Guid memberID = Guid.Empty;
            Guid.TryParse(DropDownListMember.SelectedValue.ToString(), out memberID);
            Guid employeeID = Guid.Empty;
            Guid.TryParse(DropDownListEmployee.SelectedValue.ToString(), out employeeID);
            DateTime transactionDate = DateTime.Now;
            DateTime.TryParse(TextBoxTransactionDate.Text, out transactionDate);
            Decimal discountPercentage = 0;
            Decimal.TryParse(TextBoxDiscountPercentage.Text, out discountPercentage);

            TrHeader toCreateTrHeader = TrHeaderFactory.Create(memberID, employeeID, transactionDate, discountPercentage);

            List<TrDetail> toCreateTrDetail = (List<TrDetail>)HttpContext.Current.Session["ToCreateTrDetail"];

            Result result = PreOrderController.CreateOne(toCreateTrHeader, toCreateTrDetail);
            if (result.SuccessCode != null)
            {
                LabelMessageStatus.Text = result.SucessMessage.ToString();
            }
            if (result.ErrorCode != null)
            {
                LabelMessageStatus.Text = result.ErrorMessage.ToString();
                return;
            }
        }
    }
}