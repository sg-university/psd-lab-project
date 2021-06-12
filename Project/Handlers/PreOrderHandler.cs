using Project.Factory;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class PreOrderHandler
    {
        readonly MsMemberHandler MsMemberHandler = new MsMemberHandler();
        readonly MsEmployeeHandler MsEmployeeHandler = new MsEmployeeHandler();
        readonly MsFlowerHandler MsFlowerHandler = new MsFlowerHandler();
        readonly TrHeaderHandler TrHeaderHandler = new TrHeaderHandler();
        readonly TrDetailHandler TrDetailHandler = new TrDetailHandler();

        public TrHeader CreateOne(TrHeader toCreateTrHeader, List<TrDetail> toCreateTrDetail)
        {
            TrHeader currentTrHeader = TrHeaderHandler.CreateOne(toCreateTrHeader.MemberID.GetValueOrDefault(), toCreateTrHeader.EmployeeID.GetValueOrDefault(), toCreateTrHeader.TransactionDate.GetValueOrDefault(), toCreateTrHeader.DiscountPercentage.GetValueOrDefault());
            List<TrDetail> currentTrDetail = toCreateTrDetail.Select(x =>
            {
                x.TransactionID = currentTrHeader.TransactionID;
                return TrDetailHandler.CreateOne(x.TransactionID.GetValueOrDefault(), x.FlowerID.GetValueOrDefault(), x.Quantity.GetValueOrDefault());
            }).ToList();

            return currentTrHeader;
        }
    }
}