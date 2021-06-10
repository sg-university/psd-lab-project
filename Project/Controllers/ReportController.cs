using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Dataset;
using Project.Handlers;

namespace Project.Controllers
{
    public class ReportController
    {
        ReportHandler ReportHandler = new ReportHandler();

        public MemberTransactionDataSet CreateDataSet()
        {
            return ReportHandler.CreateDataSet();
        }
    }
}