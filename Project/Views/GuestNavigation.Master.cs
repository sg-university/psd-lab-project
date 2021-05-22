using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class GuestNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookieAccount = HttpContext.Current.Request.Cookies["account"];
                Boolean isAccountExists = (cookieAccount != null) && (cookieAccount.Value != "");
                if (isAccountExists == true)
                {
                    switch (cookieAccount["role"])
                    {
                        case "member":
                            HttpContext.Current.Response.Redirect("/Views/MemberHomePage.aspx");
                            break;
                        case "staff":
                            HttpContext.Current.Response.Redirect("/Views/EmployeeHomePage.aspx");
                            break;
                        case "admin":
                            HttpContext.Current.Response.Redirect("/Views/AdministratorHomePage.aspx");
                            break;
                    }
                }
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonForgotPassword_Click(object sender, EventArgs e)
        {

        }
    }
}