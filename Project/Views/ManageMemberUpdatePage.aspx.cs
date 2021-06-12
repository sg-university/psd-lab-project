﻿using Project.Controllers;
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
    public partial class ManageMemberUpdatePage : System.Web.UI.Page
    {
        MsMemberController MsMemberController = new MsMemberController();
        MsMemberFactory MsMemberFactory = new MsMemberFactory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Guid ID = Guid.Parse(Request["ID"].ToString());
                    Result result = MsMemberController.ReadOneByID(ID);
                    MsMember currentMsMember = (MsMember)result.Data;
                    TextBoxName.Text = currentMsMember.MemberName.ToString();
                    TextBoxDOB.Text = currentMsMember.MemberDOB.ToString();
                    DropDownListGender.SelectedValue = currentMsMember.MemberGender.ToString();
                    TextBoxAddress.Text = currentMsMember.MemberAddress.ToString();
                    TextBoxPhoneNumber.Text = currentMsMember.MemberPhone.ToString();
                    TextBoxEmail.Text = currentMsMember.MemberEmail.ToString();
                    TextBoxPassword.Text = currentMsMember.MemberPassword.ToString();
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("/Views/ErrorPage.aspx");
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Guid ID = Guid.Empty;
            Guid.TryParse(HttpContext.Current.Request["ID"].ToString(), out ID);
            String name = TextBoxName.Text.ToString();
            DateTime DOB = DateTime.Now;
            DateTime.TryParse(TextBoxDOB.Text.ToString(), out DOB);
            String gender = DropDownListGender.SelectedValue.ToString();
            String address = TextBoxAddress.Text.ToString();
            String phone = TextBoxPhoneNumber.Text.ToString();
            String email = TextBoxEmail.Text.ToString();
            String password = TextBoxPassword.Text.ToString();
            String role = HttpContext.Current.Request.Cookies["account"]["role"].ToString();

            MsMember toUpdateMsMember = MsMemberFactory.Create(name, DOB, gender, address, phone, email, password);

            Result result = MsMemberController.UpdateOneByID(ID, toUpdateMsMember.MemberName, toUpdateMsMember.MemberDOB.GetValueOrDefault(), toUpdateMsMember.MemberGender, toUpdateMsMember.MemberAddress, toUpdateMsMember.MemberPhone, toUpdateMsMember.MemberEmail, toUpdateMsMember.MemberPassword);

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