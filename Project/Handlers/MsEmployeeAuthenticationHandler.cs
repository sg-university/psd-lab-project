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

        public MsEmployee Register(MsEmployee toRegisterMsEmployee)
        {
            MsEmployee currentMsEmployee = MsEmployeeFactory.Create(toRegisterMsEmployee.EmployeeName, toRegisterMsEmployee.EmployeeDOB.GetValueOrDefault(), toRegisterMsEmployee.EmployeeGender, toRegisterMsEmployee.EmployeeAddress, toRegisterMsEmployee.EmployeePhone, toRegisterMsEmployee.EmployeeRole, toRegisterMsEmployee.EmployeeSalary.GetValueOrDefault(), toRegisterMsEmployee.EmployeeEmail, toRegisterMsEmployee.EmployeePassword);

            MsEmployee registeredMsEmployee = MsEmployeeHandler.CreateOne(currentMsEmployee);

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

            MsEmployee updatedMsEmployee = MsEmployeeHandler.UpdateOneByID(currentMsEmployee.EmployeeID, currentMsEmployee);

            return updatedMsEmployee;
        }
    }
}