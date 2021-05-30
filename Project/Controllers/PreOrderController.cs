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

            Boolean isDateValid = toCreateTrHeader.TransactionDate.GetValueOrDefault() != null;
            if (!isDateValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Transaction Date must be valid";
                return result;
            }

            Boolean isDateRangeValid = toCreateTrHeader.TransactionDate.GetValueOrDefault().Year >= 1753;
            if (!isDateRangeValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Transaction Date must be in valid range (1753 <= Year <= 9999)";
                return result;
            }

            Boolean isDiscountPercentageValid = toCreateTrHeader.DiscountPercentage.GetValueOrDefault() != null;
            if (!isDiscountPercentageValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Discount Percentage must be valid";
                return result;
            }

            Boolean isDiscountPercentageRangeValid = toCreateTrHeader.DiscountPercentage.GetValueOrDefault() > 0;
            if (!isDiscountPercentageRangeValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Discount Percentage must be in valid range";
                return result;
            }

            MsEmployee currentMsEmployee = MsEmployeeHandler.ReadOneByID(toCreateTrHeader.EmployeeID.GetValueOrDefault());
            Boolean isEmployeeFound = currentMsEmployee != null;
            if (!isEmployeeFound)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Employe must be exists in database";
                return result;
            }

            toCreateTrDetail = toCreateTrDetail
            .GroupBy(x => x.FlowerID)
            .Select(x => new TrDetail()
            {
                DetailID = x.First().DetailID,
                FlowerID = x.First().FlowerID.GetValueOrDefault(),
                Quantity = x.Sum(y => y.Quantity.GetValueOrDefault())
            }).ToList();

            Boolean isAllFlowerCountValid = toCreateTrDetail.Count > 1;
            if (!isAllFlowerCountValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Flower selected must be atleast 1";
                return result;
            }

            Boolean isQuantityValid = toCreateTrDetail.Select(x => (1 <= x.Quantity) && (x.Quantity <= 100)).ToList().All(x => x == true);
            if (!isQuantityValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Flower selected quantity must be between 1 to 100 inclusively";
                return result;
            }

            List<MsFlower> currentMsFlower = toCreateTrDetail.Select(x => MsFlowerHandler.ReadOneByID(x.FlowerID.GetValueOrDefault())).ToList();
            Boolean isAllFlowerFound = !currentMsFlower.Exists(x => x == null);

            if (!isAllFlowerFound)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Flower selected must be exists in database";
                return result;
            }

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Pre-order";
            result.Data = PreOrderHandler.CreateOne(toCreateTrHeader, toCreateTrDetail);
            return result;
        }
    }
}