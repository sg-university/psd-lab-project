using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class MsEmployeeFactory
    {
        public MsEmployee Create(Guid ID, string name, DateTime DOB, string gender, string address, string phone, string role, decimal salary, string email, string password)
        {
            MsEmployee createdMsEmployee = new MsEmployee
            {
                EmployeeID = ID,
                EmployeeName = name,
                EmployeeDOB = DOB,
                EmployeeGender = gender,
                EmployeeAddress = address,
                EmployeePhone = phone,
                EmployeeRole = role,
                EmployeeSalary = salary,
                EmployeeEmail = email,
                EmployeePassword = password
            };

            return createdMsEmployee;
        }

        public MsEmployee Create(string name, DateTime DOB, string gender, string address, string phone, string role, decimal salary, string email, string password)
        {
            MsEmployee createdMsEmployee = new MsEmployee
            {
                EmployeeID = Guid.NewGuid(),
                EmployeeName = name,
                EmployeeDOB = DOB,
                EmployeeGender = gender,
                EmployeeAddress = address,
                EmployeePhone = phone,
                EmployeeRole = role,
                EmployeeSalary = salary,
                EmployeeEmail = email,
                EmployeePassword = password
            };

            return createdMsEmployee;
        }
    }
}