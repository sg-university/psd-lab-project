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

            HttpCookie httpCookie = new HttpCookie("account");
            httpCookie.Expires = DateTime.Now.AddDays(1);

            switch (role)
            {
                case "member":
                    httpCookie["id"] = ((MsMember)result.Data).MemberID.ToString();
                    httpCookie["role"] = "member";
                    break;
                case "employee":
                    String employeeRole = ((MsEmployee)result.Data).EmployeeRole.ToString();
                    if (employeeRole.Equals("staff"))
                    {
                        httpCookie["id"] = ((MsEmployee)result.Data).EmployeeID.ToString();
                        httpCookie["role"] = "staff";
                    }
                    else if (employeeRole.Equals("admin"))
                    {
                        httpCookie["id"] = ((MsEmployee)result.Data).EmployeeID.ToString();
                        httpCookie["role"] = "admin";
                    }
                    break;
                default:
                    break;
            }

            HttpContext.Current.Response.Cookies.Add(httpCookie);

            switch (role)
            {
                case "member":
                    Response.Redirect("/Views/MemberHomePage.aspx");
                    break;
                case "employee":
                    String employeeRole = ((MsEmployee)result.Data).EmployeeRole.ToString();
                    if (employeeRole.Equals("staff"))
                    {
                        HttpContext.Current.Response.Redirect("/Views/EmployeeHomePage.aspx");
                    }
                    else if (employeeRole.Equals("admin"))
                    {
                        HttpContext.Current.Response.Redirect("/Views/AdministratorHomePage.aspx");
                    }
                    break;
                default:
                    break;
            }

            return;
        }
    }
}