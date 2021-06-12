using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Handlers;

namespace Project.Controllers
{
    public class MsFlowerTypeController
    {
        readonly MsFlowerTypeHandler MsFlowerTypeHandler = new MsFlowerTypeHandler();

        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Flower Type";
            result.Data = MsFlowerTypeHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Flower Type";
            result.Data = MsFlowerTypeHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(string typeName)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Flower Type";
            result.Data = MsFlowerTypeHandler.CreateOne(typeName);
            return result;
        }
        public Result UpdateOneByID(Guid ID, string typeName)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Flower Type";
            result.Data = MsFlowerTypeHandler.UpdateOneByID(ID, typeName);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Flower Type";
            result.Data = MsFlowerTypeHandler.DeleteOneByID(ID);
            return result;
        }
    }
}