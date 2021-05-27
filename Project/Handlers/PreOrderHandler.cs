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
            TrHeader currentTrHeader = TrHeaderHandler.CreateOne(toCreateTrHeader);
            List<TrDetail> currentTrDetail = toCreateTrDetail.Select(x =>
            TrDetailHandler.CreateOne(x)).ToList();

            return currentTrHeader;
        }
    }
}