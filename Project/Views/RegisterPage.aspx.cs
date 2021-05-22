using Project.Controllers;
using Project.Factory;
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
    public partial class RegisterPage : System.Web.UI.Page
    {
        readonly MsEmployeeAuthenticationController MsEmployeeAuthenticationController = new MsEmployeeAuthenticationController();

        readonly MsMemberAuthenticationController MsMemberAuthenticationController = new MsMemberAuthenticationController();

        readonly MsMemberFactory MsMemberFactory = new MsMemberFactory();
        readonly MsEmployeeFactory MsEmployeeFactory = new MsEmployeeFactory();

        JavaScriptSerializer JSS = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            Result result = null;

            String name = TextBoxName.Text.ToString();
            DateTime DOB = DateTime.Parse(TextBoxDOB.Text.ToString());
            String gender = DropDownListGender.SelectedValue.ToString();
            String address = TextBoxAddress.Text.ToString();
            String phone = TextBoxPhoneNumber.Text.ToString();
            String email = TextBoxEmail.Text.ToString();
            String password = TextBoxPassword.Text.ToString();
            String role = DropDownListRole.SelectedValue.ToString();

            switch (role)
            {
                case "member":
                    MsMember toRegisterMsMember = MsMemberFactory.Create(name, DOB, gender, address, phone, email, password);
                    result = MsMemberAuthenticationController.Register(toRegisterMsMember);
                    break;
                case "staff":
                    MsEmployee toRegisterMsEmployeeStaff = MsEmployeeFactory.Create(name, DOB, gender, address, phone, role, 0, email, password);
                    result = MsEmployeeAuthenticationController.Register(toRegisterMsEmployeeStaff);
                    break;
                case "admin":
                    MsEmployee toRegisterMsEmployeeAdmin = MsEmployeeFactory.Create(name, DOB, gender, address, phone, role, 0, email, password);
                    result = MsEmployeeAuthenticationController.Register(toRegisterMsEmployeeAdmin);
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