using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Factory;
using Project.Models;

namespace Project.Views
{
    public partial class InsertFlower : System.Web.UI.Page
    {
        readonly MsFlowerController MsFlowerController = new MsFlowerController();
        readonly MsFlowerTypeController MsFlowerTypeController = new MsFlowerTypeController();
        readonly MsFlowerFactory MsFlowerFactory = new MsFlowerFactory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Result resultAllFlowerType = MsFlowerTypeController.ReadAll();
                List<MsFlowerType> type = (List<MsFlowerType>)resultAllFlowerType.Data;
                DropDownListType.DataSource = type;
                DropDownListType.DataTextField = "FlowerTypeName";
                DropDownListType.DataValueField = "FlowerTypeID";
                DropDownListType.DataBind();
            }
        }


        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            String name = TextBoxName.Text.ToString();
            Guid typeID = Guid.Parse(DropDownListType.SelectedValue.ToString());
            String description = TextBoxDescription.Text.ToString();
            Decimal price = Decimal.Parse(TextBoxPrice.Text.ToString());
            String image = System.IO.Path.GetFileName(FileUploadImage.FileName);

            MsFlower toCreateMsFlower = MsFlowerFactory.Create(name, typeID, description, price, image);
            Result result = MsFlowerController.CreateOne(toCreateMsFlower);

            if (!String.IsNullOrEmpty(result.SuccessCode))
            {
                FileUploadImage.SaveAs(Server.MapPath("~/Assets/Images/" + name + ".jpg"));
                LabelMessageSuccess.Text = result.SucessMessage;
            }
            else
            {
                LabelMessageError.Text = result.ErrorMessage;
            }
        }
    }
}