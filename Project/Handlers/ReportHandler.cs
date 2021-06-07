using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Dataset;
using Project.Repositories;
using Project.Factories;

namespace Project.Handlers
{
    public class ReportHandler
    {
        TrHeaderRepository TrHeaderRepository = new TrHeaderRepository();
        ReportFactory ReportFactory = new ReportFactory();

        public MemberTransactionDataset createDataSet()
        {
            return ReportFactory.createDataSet(TrHeaderRepository.ReadAll());
        }
       
    }
}