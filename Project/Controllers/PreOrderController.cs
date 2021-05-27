using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Handlers;

namespace Project.Controllers
{
    public class PreOrderController
    {
        readonly MsMemberHandler MsMemberHandler = new MsMemberHandler();
        readonly MsEmployeeHandler MsEmployeeHandler = new MsEmployeeHandler();
        readonly MsFlowerHandler MsFlowerHandler = new MsFlowerHandler();
        readonly TrHeaderHandler TrHeaderHandler = new TrHeaderHandler();
        readonly TrDetailHandler TrDetailHandler = new TrDetailHandler();
        readonly PreOrderHandler PreOrderHandler = new PreOrderHandler();

        public Result CreateOne(TrHeader toCreateTrHeader, List<TrDetail> toCreateTrDetail)
        {
            Result result = new Result();

            MsEmployee currentMsEmployee = MsEmployeeHandler.ReadOneByID(toCreateTrHeader.MsEmployee.EmployeeID);
            Boolean isEmployeeFound = currentMsEmployee != null;
            if (!isEmployeeFound)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Employe must be exists in database";
                return result;
            }

            List<MsFlower> currentMsFlower = toCreateTrDetail.Select(x => MsFlowerHandler.ReadOneByID(x.MsFlower.FlowerID)).ToList();
            Boolean isFlowerFound = !currentMsFlower.Exists(x => x == null);

            if (!isFlowerFound) {
                result.ErrorCode = "403";
                result.ErrorMessage = "Flower must be exists in database";
                return result;
            }
            
            TrHeader currentTrHeader = TrHeaderHandler.CreateOne(toCreateTrHeader);

            List<TrDetail> currentTrDetail = toCreateTrDetail.Select(x =>
            TrDetailHandler.CreateOne(x)).ToList();

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Pre Order";
            result.Data = currentTrHeader;
            return result;
        }
    }
}