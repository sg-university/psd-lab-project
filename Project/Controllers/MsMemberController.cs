using Project.Handlers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class MsMemberController
    {
        readonly MsMemberHandler MsMemberHandler = new MsMemberHandler();

        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Member";
            result.Data = MsMemberHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Member";
            result.Data = MsMemberHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(MsMember toCreateMsMember)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Member";
            result.Data = MsMemberHandler.CreateOne(toCreateMsMember);
            return result;
        }
        public Result UpdateOneByID(Guid ID, MsMember toUpdateMsMember)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Member";
            result.Data = MsMemberHandler.UpdateOneByID(ID, toUpdateMsMember);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Member";
            result.Data = MsMemberHandler.DeleteOneByID(ID);
            return result;
        }
    }
}