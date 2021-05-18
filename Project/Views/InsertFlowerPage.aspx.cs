using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Factory;
using Project.Handler;

namespace Project.Views
{
    public partial class InsertFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertFlowerbtn_Click(object sender, EventArgs e)
        {
            ErrorMessage.Text = Validation.FlowerValidation(FlowerName.Text, Description.Text, price.Text);
            if (String.IsNullOrEmpty(ErrorMessage.Text))
            {

                Response.Redirect("~/Views/ManageFlowerPage.aspx");
            }
        }
    }
}