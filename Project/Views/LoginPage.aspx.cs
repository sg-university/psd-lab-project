using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Models;

namespace Project.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        MsEmployeeAuthenticationController MsEmployeeAuthenticationController = new MsEmployeeAuthenticationController();

        MsMemberAuthenticationController MsMemberAuthenticationController = new MsMemberAuthenticationController();

        JavaScriptSerializer JSS = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Boolean isAccountExists = HttpContext.Current.Response.Cookies.Get("account").Value != null;
                if (isAccountExists)
                {
                    Object account = JSS.DeserializeObject(HttpContext.Current.Response.Cookies["account"].Value.ToString());
                    HttpContext.Current.Session.Add("account", account);
                    if (account.GetType() == typeof(MsMember))
                    {
                        HttpContext.Current.Response.Redirect("/Views/MemberHome.aspx");
                    }
                    else if (account.GetType() == typeof(MsEmployee))
                    {
                        String employeeRole = ((MsEmployee)account).EmployeeRole.ToString();
                        if (employeeRole.Equals("staff"))
                        {
                            HttpContext.Current.Response.Redirect("/Views/EmployeeHome.aspx");
                        }
                        else if (employeeRole.Equals("admin"))
                        {
                            HttpContext.Current.Response.Redirect("/Views/AdministratorHome.aspx");
                        }
                    }
                }
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            Result result = null;

            String email = TextBoxEmail.Text.ToString();
            String password = TextBoxPassword.Text.ToString();
            String role = DropDownListRole.SelectedValue.ToString();

            switch (role)
            {
                case "member":
                    result = MsMemberAuthenticationController.Login(email, password);
                    break;
                case "employee":
                    result = MsEmployeeAuthenticationController.Login(email, password);
                    break;
                default:
                    break;
            }

            if (result.SuccessCode != null)
            {
                LabelMessageStatus.Text = result.SucessMessage.ToString();
            }
            if (result.ErrorCode != null)
            {
                LabelMessageStatus.Text = result.ErrorMessage.ToString();
                return;
            }

            HttpContext.Current.Session.Add("account", result.Data);
            HttpCookie httpCookie = new HttpCookie("account");
            httpCookie.Value = JSS.Serialize(result.Data);
            httpCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(httpCookie);

            switch (role)
            {
                case "member":
                    Response.Redirect("/Views/MemberHome.aspx");
                    break;
                case "employee":
                    String employeeRole = ((MsEmployee)result.Data).EmployeeRole.ToString();
                    if (employeeRole.Equals("staff"))
                    {
                        HttpContext.Current.Response.Redirect("/Views/EmployeeHome.aspx");
                    }
                    else if (employeeRole.Equals("admin"))
                    {
                        HttpContext.Current.Response.Redirect("/Views/AdministratorHome.aspx");
                    }
                    break;
                default:
                    break;
            }

            return;
        }
    }
}