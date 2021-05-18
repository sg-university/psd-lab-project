using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Factory;
using Project.Controllers;
using Project.Models;

namespace Project.Views
{
    public partial class InsertFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertFlowerbtn_Click(object sender, EventArgs e)
        {
            string imageFile = System.IO.Path.GetFileName(FlowerUploadImg.FileName);
            Result res = MsFlowerController.InsertFlower(FlowerName.Text, imageFile, Description.Text, DropDownType.SelectedValue.ToString(), price.Text);
            ErrorMessage.Text = res.ErrorMessage;
            SuccessMessage.Text = res.SucessMessage;
        }
    }
}