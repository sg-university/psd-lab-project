using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Models;

namespace Project.Views
{
    public partial class InsertFlower : System.Web.UI.Page
    {
        readonly MsFlowerController MsFlowerController = new MsFlowerController();
        readonly MsFlowerTypeController MsFlowerTypeController = new MsFlowerTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MsFlowerType> type = MsFlowerTypeController.GetAllType();
                DDType.DataSource = type;
                DDType.DataTextField = "FlowerTypeName";
                DDType.DataValueField = "FlowerTypeID";
                DDType.DataBind();
            }
        }

        protected void InsertFlowerbtn_Click(object sender, EventArgs e)
        {
            string imageFile = System.IO.Path.GetFileName(FlowerUploadImg.FileName);
            Result res = MsFlowerController.InsertFlower(FlowerName.Text, imageFile, Description.Text, DDType.SelectedValue, price.Text);
            if (!String.IsNullOrEmpty(res.SuccessCode))
            {
                FlowerUploadImg.SaveAs(Server.MapPath("~/Assets/Images/" + FlowerName.Text + ".jpg"));
                ErrorMessage.Text = "";
                SuccessMessage.Text = res.SucessMessage;
            }
            else
            {
                SuccessMessage.Text = "";
                ErrorMessage.Text = res.ErrorMessage;
            }
        }
    }
}