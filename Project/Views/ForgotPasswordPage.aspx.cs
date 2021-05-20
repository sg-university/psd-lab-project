using Project.Controllers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class ForgotPasswordPage : System.Web.UI.Page
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

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            Result result = null;

            String email = TextBoxEmail.Text.ToString();
            String captcha = TextBoxCaptcha.Text.ToString();
            String password = TextBoxPassword.Text.ToString();
            String role = DropDownListRole.SelectedValue.ToString();

            switch (role)
            {
                case "member":
                    result = MsMemberAuthenticationController.ForgotPassword(email, password, captcha);
                    break;
                case "employee":
                    result = MsEmployeeAuthenticationController.ForgotPassword(email, password, captcha);
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

            return;
        }
    }
}