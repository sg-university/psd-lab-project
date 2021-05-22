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
                HttpContext.Current.Request.Cookies["account"].Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies["account"].Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                Response.Redirect("/Views/LoginPage.aspx");
            }
        }
    }
}