using Project.Factory;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MsEmployeeAuthenticationHandler
    {
        readonly MsEmployeeHandler MsEmployeeHandler = new MsEmployeeHandler();
        readonly MsEmployeeFactory MsEmployeeFactory = new MsEmployeeFactory();

        public MsEmployee Register(String name, DateTime DOB, String gender, String address, String phone, String role, Decimal salary, String email, String password)
        {
            MsEmployee currentMsEmployee = MsEmployeeFactory.Create(name, DOB, gender, address, phone, role, salary, email, password);

            MsEmployee registeredMsEmployee = MsEmployeeHandler.CreateOne(name, DOB, gender, address, phone, role, salary, email, password);

            return registeredMsEmployee;
        }

        public MsEmployee Login(String email, String password)
        {
            MsEmployee currentMsEmployee = MsEmployeeHandler.ReadAll().Find(x => x.EmployeeEmail.Equals(email) && x.EmployeePassword.Equals(password));

            return currentMsEmployee;
        }

        public MsEmployee ForgotPassword(String email, String password, String captcha)
        {
            MsEmployee currentMsEmployee = MsEmployeeHandler.ReadAll().Find(x => x.EmployeeEmail.Equals(email));

            currentMsEmployee.EmployeePassword = password;

            MsEmployee updatedMsEmployee = MsEmployeeHandler.UpdateOneByID(currentMsEmployee.EmployeeID, currentMsEmployee.EmployeeName, currentMsEmployee.EmployeeDOB.GetValueOrDefault(), currentMsEmployee.EmployeeGender, currentMsEmployee.EmployeeAddress, currentMsEmployee.EmployeePhone, currentMsEmployee.EmployeeRole, currentMsEmployee.EmployeeSalary.GetValueOrDefault(), currentMsEmployee.EmployeeEmail, currentMsEmployee.EmployeePassword);

            return updatedMsEmployee;
        }
    }
}