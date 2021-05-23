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
    public partial class ManageEmployeeUpdatePage : System.Web.UI.Page
    {
        MsEmployeeController MsEmployeeController = new MsEmployeeController();
        MsEmployeeFactory MsEmployeeFactory = new MsEmployeeFactory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Guid ID = Guid.Parse(Request["ID"].ToString());
                    Result result = MsEmployeeController.ReadOneByID(ID);
                    MsEmployee currentMsEmployee = (MsEmployee)result.Data;
                    TextBoxName.Text = currentMsEmployee.EmployeeName.ToString();
                    TextBoxDOB.Text = currentMsEmployee.EmployeeDOB.ToString();
                    DropDownListGender.SelectedValue = currentMsEmployee.EmployeeGender.ToString();
                    TextBoxAddress.Text = currentMsEmployee.EmployeeAddress.ToString();
                    TextBoxPhoneNumber.Text = currentMsEmployee.EmployeePhone.ToString();
                    TextBoxEmail.Text = currentMsEmployee.EmployeeEmail.ToString();
                    TextBoxPassword.Text = currentMsEmployee.EmployeePassword.ToString();
                    DropDownListRole.SelectedValue = currentMsEmployee.EmployeeRole.ToString();
                    TextBoxSalary.Text = currentMsEmployee.EmployeeSalary.ToString();
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
            Decimal salary = 0;
            Decimal.TryParse(TextBoxSalary.Text.ToString(), out salary);
            String role = DropDownListRole.SelectedValue.ToString();

            MsEmployee toUpdateMsEmployee = MsEmployeeFactory.Create(name, DOB, gender, address, phone, role, salary, email, password);

            Result result = MsEmployeeController.UpdateOneByID(ID, toUpdateMsEmployee);

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