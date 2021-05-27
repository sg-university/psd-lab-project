using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Handlers;

namespace Project.Controllers
{
    public class TrHeaderController
    {
        readonly TrHeaderHandler TrHeaderHandler = new TrHeaderHandler();

        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Transaction Header";
            result.Data = TrHeaderHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Transaction Header";
            result.Data = TrHeaderHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(TrHeader toCreateTrHeader)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Transaction Header";
            result.Data = TrHeaderHandler.CreateOne(toCreateTrHeader);
            return result;
        }
        public Result UpdateOneByID(Guid ID, TrHeader toUpdateTrHeader)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Transaction Header";
            result.Data = TrHeaderHandler.UpdateOneByID(ID, toUpdateTrHeader);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Transaction Header";
            result.Data = TrHeaderHandler.DeleteOneByID(ID);
            return result;
        }
    }
}