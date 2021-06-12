using Project.Controllers;
using Project.Factory;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class ManageMemberInsertPage : System.Web.UI.Page
    {
        MsMemberController MsMemberController = new MsMemberController();
        MsMemberFactory MsMemberFactory = new MsMemberFactory();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            String name = TextBoxName.Text.ToString();
            DateTime DOB = DateTime.Now;
            DateTime.TryParse(TextBoxDOB.Text.ToString(), out DOB);
            String gender = DropDownListGender.SelectedValue.ToString();
            String address = TextBoxAddress.Text.ToString();
            String phone = TextBoxPhoneNumber.Text.ToString();
            String email = TextBoxEmail.Text.ToString();
            String password = TextBoxPassword.Text.ToString();
            String role = HttpContext.Current.Request.Cookies["account"]["role"].ToString();

            MsMember toCreateMsMember = MsMemberFactory.Create(name, DOB, gender, address, phone, email, password);

            Result result = MsMemberController.CreateOne(toCreateMsMember.MemberName, toCreateMsMember.MemberDOB.GetValueOrDefault(), toCreateMsMember.MemberGender, toCreateMsMember.MemberAddress, toCreateMsMember.MemberPhone, toCreateMsMember.MemberEmail, toCreateMsMember.MemberPassword);

            if (result.SuccessCode != null)
            {
                LabelMessageStatus.Text = result.SucessMessage.ToString();
            }
            if (result.ErrorCode != null)
            {
                LabelMessageStatus.Text = result.ErrorMessage.ToString();
                return;
            }
        }
    }
}