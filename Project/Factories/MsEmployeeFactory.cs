using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class MsEmployeeFactory
    {
        public MsEmployee Create(Guid ID, string name, DateTime DOB, string gender, string address, string phone, string email, decimal salary, string password)
        {
            MsEmployee createdMsEmployee = new MsEmployee
            {
                EmployeeID = ID,
                EmployeeName = name,
                EmployeeDOB = DOB,
                EmployeeGender = gender,
                EmployeeAddress = address,
                EmployeePhone = phone,
                EmployeeEmail = email,
                EmployeeSalary = salary,
                EmployeePassword = password
            };

            return createdMsEmployee;
        }
    }
}