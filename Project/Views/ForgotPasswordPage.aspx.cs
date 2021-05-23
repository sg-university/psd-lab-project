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