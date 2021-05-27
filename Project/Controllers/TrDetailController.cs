using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Handlers;

namespace Project.Controllers
{
    public class TrDetailController
    {
        readonly TrDetailHandler TrDetailHandler = new TrDetailHandler();

        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Transaction Detail";
            result.Data = TrDetailHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Transaction Detail";
            result.Data = TrDetailHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(TrDetail toCreateTrDetail)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Transaction Detail";
            result.Data = TrDetailHandler.CreateOne(toCreateTrDetail);
            return result;
        }
        public Result UpdateOneByID(Guid ID, TrDetail toUpdateTrDetail)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Transaction Detail";
            result.Data = TrDetailHandler.UpdateOneByID(ID, toUpdateTrDetail);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Transaction Detail";
            result.Data = TrDetailHandler.DeleteOneByID(ID);
            return result;
        }
    }
}