using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;

namespace Project.Views
{
    public partial class LoginPage1 : System.Web.UI.Page
    {
        MsEmployeeAuthenticationController MsEmployeeAuthenticationController = new MsEmployeeAuthenticationController();

        MsMemberAuthenticationController MsMemberAuthenticationController = new MsMemberAuthenticationController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

        }
    }
}