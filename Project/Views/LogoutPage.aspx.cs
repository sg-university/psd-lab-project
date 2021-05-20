using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class LogoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpContext.Current.Response.Cookies.Clear();
                HttpContext.Current.Session.Clear();
                Response.Redirect("/Views/LoginPage.aspx");
            }
        }
    }
}