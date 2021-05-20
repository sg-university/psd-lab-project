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
            toCreateMsEmployee.EmployeeID = Guid.NewGuid();
            MsEmployee result = MsEmployeeRepository.CreateOne(toCreateMsEmployee);
            return result;
        }
        public MsEmployee UpdateOneByID(Guid ID, MsEmployee toUpdateMsEmployee)
        {
            MsEmployee result = MsEmployeeRepository.UpdateOneByID(ID, toUpdateMsEmployee);
            return result;
        }
        public MsEmployee DeleteOneByID(Guid ID)
        {
            MsEmployee result = MsEmployeeRepository.DeleteOneByID(ID);
            return result;
        }
    }
}