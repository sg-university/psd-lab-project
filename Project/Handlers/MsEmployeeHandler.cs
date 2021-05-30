using Project.Factory;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MsEmployeeHandler
    {
        readonly MsEmployeeRepository MsEmployeeRepository = new MsEmployeeRepository();
        readonly MsEmployeeFactory MsEmployeeFactory = new MsEmployeeFactory();

        public List<MsEmployee> ReadAll()
        {
            List<MsEmployee> result = MsEmployeeRepository.ReadAll();
            return result;
        }
        public MsEmployee ReadOneByID(Guid ID)
        {
            MsEmployee result = MsEmployeeRepository.ReadOneByID(ID);
            return result;
        }
        public MsEmployee CreateOne(MsEmployee toCreateMsEmployee)
        {
            MsEmployee currentMsEmployee = MsEmployeeFactory.Create(Guid.NewGuid(), toCreateMsEmployee.EmployeeName, toCreateMsEmployee.EmployeeDOB.GetValueOrDefault(), toCreateMsEmployee.EmployeeGender, toCreateMsEmployee.EmployeeAddress, toCreateMsEmployee.EmployeePhone, toCreateMsEmployee.EmployeeRole, toCreateMsEmployee.EmployeeSalary.GetValueOrDefault(), toCreateMsEmployee.EmployeeEmail, toCreateMsEmployee.EmployeePassword);

            MsEmployee result = MsEmployeeRepository.CreateOne(currentMsEmployee);

            return result;
        }
        public MsEmployee UpdateOneByID(Guid ID, MsEmployee toUpdateMsEmployee)
        {
            MsEmployee currentMsEmployee = MsEmployeeFactory.Create(toUpdateMsEmployee.EmployeeName, toUpdateMsEmployee.EmployeeDOB.GetValueOrDefault(), toUpdateMsEmployee.EmployeeGender, toUpdateMsEmployee.EmployeeAddress, toUpdateMsEmployee.EmployeePhone, toUpdateMsEmployee.EmployeeRole, toUpdateMsEmployee.EmployeeSalary.GetValueOrDefault(), toUpdateMsEmployee.EmployeeEmail, toUpdateMsEmployee.EmployeePassword);

            MsEmployee result = MsEmployeeRepository.UpdateOneByID(ID, currentMsEmployee);
            return result;
        }
        public MsEmployee DeleteOneByID(Guid ID)
        {
            MsEmployee result = MsEmployeeRepository.DeleteOneByID(ID);
            return result;
        }
    }
}