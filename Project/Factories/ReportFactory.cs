using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Dataset;

namespace Project.Factories
{
    public class ReportFactory
    {

        public MemberTransactionDataset createDataSet(List<TrHeader> memberTransaction)
        {
            MemberTransactionDataset transactionDataset = new MemberTransactionDataset();
            var header = transactionDataset.TrHeader;
            var hMember = transactionDataset.MsMember;
            var hEmployee = transactionDataset.MsEmployee;
            var details = transactionDataset.TrDetail;
            var dFlower = transactionDataset.MsFlower;

            foreach (TrHeader tr in memberTransaction)
            {
                var rowHeader = header.NewRow();
                rowHeader["TransactionID"] = tr.TransactionID;
                rowHeader["EmployeeID"] = tr.EmployeeID;
                rowHeader["MemberID"] = tr.MemberID;
                rowHeader["TransactionDate"] = tr.TransactionDate;
                rowHeader["DiscountPercentage"] = tr.DiscountPercentage;
                header.Rows.Add(rowHeader);

                var rowMember = hMember.NewRow();
                rowMember["MemberName"] = tr.MsMember.MemberName;
                hMember.Rows.Add(rowMember);

                var rowEmployee = hEmployee.NewRow();
                rowEmployee["EmployeeName"] = tr.MsEmployee.EmployeeName;
                hEmployee.Rows.Add(rowEmployee);

                foreach (TrDetail trdetail in tr.TrDetails)
                {
                    var rowDetail = details.NewRow();
                    rowDetail["FlowerID"] = trdetail.FlowerID;
                    rowDetail["Quantity"] = trdetail.Quantity;
                    details.Rows.Add(rowDetail);

                    var rowFlower = dFlower.NewRow();
                    rowFlower["FlowerName"] = trdetail.MsFlower.FlowerName;
                    rowFlower["FlowerPrice"] = trdetail.MsFlower.FlowerPrice;
                    dFlower.Rows.Add(rowFlower);
                }
            }
            return transactionDataset;
        }

    }
}