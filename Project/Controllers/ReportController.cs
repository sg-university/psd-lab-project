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
        ReportHandler reportHandler = new ReportHandler();

        public MemberTransactionDataset createDataSet()
        {
            return reportHandler.createDataSet();
        }
    }
}