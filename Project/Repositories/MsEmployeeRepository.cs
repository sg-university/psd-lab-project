using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class MsEmployeeRepository
    {
        readonly NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public List<MsEmployee> ReadAll()
        {
            List<MsEmployee> result = db.MsEmployees.ToList();
            return result;
        }
        public MsEmployee ReadOneByID(int ID)
        {
            MsEmployee result = this.ReadAll().Where(x => x.EmployeeID.Equals(ID)).FirstOrDefault();
            return result;
        }
        public MsEmployee CreateOne(MsEmployee toCreateMsEmployee)
        {
            db.MsEmployees.Add(toCreateMsEmployee);
            db.SaveChanges();
            MsEmployee currentMsEmployee = this.ReadAll().LastOrDefault();
            return currentMsEmployee;
        }
        public MsEmployee UpdateOneByID(int ID, MsEmployee toUpdateMsEmployee)
        {
            MsEmployee currentMsEmployee = this.ReadOneByID(ID);
            currentMsEmployee.EmployeeName = toUpdateMsEmployee.EmployeeName;
            currentMsEmployee.EmployeeDOB = toUpdateMsEmployee.EmployeeDOB;
            currentMsEmployee.EmployeeGender = toUpdateMsEmployee.EmployeeGender;
            currentMsEmployee.EmployeeAddress = toUpdateMsEmployee.EmployeeAddress;
            currentMsEmployee.EmployeePhone = toUpdateMsEmployee.EmployeePhone;
            currentMsEmployee.EmployeeEmail = toUpdateMsEmployee.EmployeeEmail;
            currentMsEmployee.EmployeeSalary = toUpdateMsEmployee.EmployeeSalary;
            currentMsEmployee.EmployeePassword = toUpdateMsEmployee.EmployeePassword;
            db.SaveChanges();
            return currentMsEmployee;
        }
        public MsEmployee DeleteOneByID(int ID)
        {
            MsEmployee currentMsEmployee = this.ReadOneByID(ID);
            db.MsEmployees.Remove(currentMsEmployee);
            db.SaveChanges();
            return currentMsEmployee;
        }
    }
}
