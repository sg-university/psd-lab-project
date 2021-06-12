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
        public MsEmployee CreateOne(String name, DateTime DOB, String gender, String address, String phone, String role, Decimal salary, String email, String password)
        {
            MsEmployee currentMsEmployee = MsEmployeeFactory.Create(Guid.NewGuid(), name, DOB, gender, address, phone, role, salary, email, password);

            MsEmployee result = MsEmployeeRepository.CreateOne(currentMsEmployee);

            return result;
        }
        public MsEmployee UpdateOneByID(Guid ID, String name, DateTime DOB, String gender, String address, String phone, String role, Decimal salary, String email, String password)
        {
            MsEmployee currentMsEmployee = MsEmployeeFactory.Create(name, DOB, gender, address, phone, role, salary, email, password);

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