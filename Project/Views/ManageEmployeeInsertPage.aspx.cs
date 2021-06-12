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
    public partial class ManageEmployeeInsertPage : System.Web.UI.Page
    {
        MsEmployeeController MsEmployeeController = new MsEmployeeController();
        MsEmployeeFactory MsEmployeeFactory = new MsEmployeeFactory();
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
            Decimal salary = 0;
            Decimal.TryParse(TextBoxSalary.Text.ToString(), out salary);
            String role = DropDownListRole.SelectedValue.ToString();

            MsEmployee toCreateMsEmployee = MsEmployeeFactory.Create(name, DOB, gender, address, phone, role, salary, email, password);

            Result result = MsEmployeeController.CreateOne(toCreateMsEmployee.EmployeeName, toCreateMsEmployee.EmployeeDOB.GetValueOrDefault(), toCreateMsEmployee.EmployeeGender, toCreateMsEmployee.EmployeeAddress, toCreateMsEmployee.EmployeePhone, toCreateMsEmployee.EmployeeRole, toCreateMsEmployee.EmployeeSalary.GetValueOrDefault(), toCreateMsEmployee.EmployeeEmail, toCreateMsEmployee.EmployeePassword);

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