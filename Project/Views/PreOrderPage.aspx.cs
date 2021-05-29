using Project.Controllers;
using Project.Factory;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class PreOrderPage : System.Web.UI.Page
    {
        PreOrderController PreOrderController = new PreOrderController();
        TrHeaderController TrHeaderController = new TrHeaderController();
        MsFlowerController MsFlowerController = new MsFlowerController();
        MsMemberController MsMemberController = new MsMemberController();
        MsEmployeeController MsEmployeeController = new MsEmployeeController();

        TrHeaderFactory TrHeaderFactory = new TrHeaderFactory();
        TrDetailFactory TrDetailFactory = new TrDetailFactory();

        List<TrDetail> ToCreateTrDetail = new List<TrDetail>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Result resultAllFlower = MsFlowerController.ReadAll();
                    GridViewFlowerSelection.DataSource = (List<MsFlower>)resultAllFlower.Data;
                    GridViewFlowerSelection.DataBind();

                    GridViewTransactionDetail.DataSource = ToCreateTrDetail;
                    GridViewTransactionDetail.DataBind();

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

            switch (e.CommandName)
            {
                case "Add":
                    try
                    {
                        TrDetail currentTrDetail = ToCreateTrDetail.Where(x => x.FlowerID.Equals(flowerID)).FirstOrDefault();

                        if (currentTrDetail != null)
                        {
                            currentTrDetail.Quantity += quantity;
                        }
                        else
                        {
                            currentTrDetail = TrDetailFactory.Create(Guid.Empty, flowerID, quantity); ToCreateTrDetail.Add(currentTrDetail);
                        }
                        GridViewTransactionDetail.DataSource = null;
                        GridViewTransactionDetail.DataSource = ToCreateTrDetail;
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

            switch (e.CommandName)
            {
                case "Remove":
                    try
                    {
                        TrDetail currentTrDetail = ToCreateTrDetail.Where(x => x.FlowerID.Equals(flowerID)).FirstOrDefault();
                        ToCreateTrDetail.Remove(currentTrDetail);
                        GridViewTransactionDetail.DataSource = null;
                        GridViewTransactionDetail.DataSource = ToCreateTrDetail;
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

            Result result = PreOrderController.CreateOne(toCreateTrHeader, ToCreateTrDetail);
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