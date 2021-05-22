using Project.Handlers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class MsEmployeeController
    {
        readonly MsEmployeeHandler MsEmployeeHandler = new MsEmployeeHandler();

        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Employee";
            result.Data = MsEmployeeHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Employee";
            result.Data = MsEmployeeHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(MsEmployee toCreateMsEmployee)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Employee";
            result.Data = MsEmployeeHandler.CreateOne(toCreateMsEmployee);
            return result;
        }
        public Result UpdateOneByID(Guid ID, MsEmployee toUpdateMsEmployee)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Employee";
            result.Data = MsEmployeeHandler.UpdateOneByID(ID, toUpdateMsEmployee);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Employee";
            result.Data = MsEmployeeHandler.DeleteOneByID(ID);
            return result;
        }
    }
}