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

        public MemberTransactionDataSet createDataSet(List<TrHeader> TrHeader)
        {
            MemberTransactionDataSet MemberTransactionDataSet = new MemberTransactionDataSet();
            var header = MemberTransactionDataSet.TrHeader;
            var hMember = MemberTransactionDataSet.MsMember;
            var hEmployee = MemberTransactionDataSet.MsEmployee;
            var details = MemberTransactionDataSet.TrDetail;
            var dFlower = MemberTransactionDataSet.MsFlower;

            List<TrHeader> cleanedTrHeader = TrHeader.GroupBy(x => x.TransactionID)
                         .Select(x => new TrHeader()
                         {
                             TransactionID = x.First().TransactionID,
                             MemberID = x.First().MemberID.GetValueOrDefault(),
                             EmployeeID = x.First().EmployeeID.GetValueOrDefault(),
                             TransactionDate = x.First().TransactionDate.GetValueOrDefault(),
                             DiscountPercentage = x.First().DiscountPercentage.GetValueOrDefault(),
                             TrDetails = x.First().TrDetails,
                             MsMember = x.First().MsMember,
                             MsEmployee = x.First().MsEmployee,
                         }).ToList();

            foreach (TrHeader trh in cleanedTrHeader)
            {
                var rowHeader = header.NewRow();
                rowHeader["TransactionID"] = trh.TransactionID;
                rowHeader["MemberID"] = trh.MemberID.GetValueOrDefault();
                rowHeader["EmployeeID"] = trh.EmployeeID.GetValueOrDefault();
                rowHeader["TransactionDate"] = trh.TransactionDate.GetValueOrDefault();
                rowHeader["DiscountPercentage"] = trh.DiscountPercentage.GetValueOrDefault();

                var rowMember = hMember.NewRow();
                rowMember["MemberID"] = trh.MsMember.MemberID;
                rowMember["MemberName"] = trh.MsMember.MemberName;
                hMember.Rows.Add(rowMember);

                var rowEmployee = hEmployee.NewRow();
                rowEmployee["EmployeeID"] = trh.MsEmployee.EmployeeID;
                rowEmployee["EmployeeName"] = trh.MsEmployee.EmployeeName;
                hEmployee.Rows.Add(rowEmployee);

                Decimal grandTotalPrice = 0;
                Decimal rowDetailPrice = 0;

                List<TrDetail> cleanedTrDetail = trh.TrDetails.GroupBy(x => x.FlowerID)
                         .Select(x => new TrDetail()
                         {
                             DetailID = x.First().DetailID,
                             TransactionID = x.First().TransactionID,
                             FlowerID = x.First().FlowerID.GetValueOrDefault(),
                             Quantity = x.Sum(y => y.Quantity.GetValueOrDefault()),
                             MsFlower = x.First().MsFlower,
                             TrHeader = x.First().TrHeader
                         }).ToList();

                foreach (TrDetail trd in cleanedTrDetail)
                {
                    var rowDetail = details.NewRow();
                    rowDetail["TransactionID"] = trd.TransactionID.GetValueOrDefault();
                    rowDetail["FlowerID"] = trd.FlowerID.GetValueOrDefault();
                    rowDetail["Quantity"] = trd.Quantity.GetValueOrDefault();
                    rowDetailPrice = trd.Quantity.GetValueOrDefault() * trd.MsFlower.FlowerPrice.GetValueOrDefault();
                    grandTotalPrice += rowDetailPrice;
                    rowDetail["Total"] = rowDetailPrice;
                    details.Rows.Add(rowDetail);

                    var rowFlower = dFlower.NewRow();
                    rowFlower["FlowerID"] = trd.MsFlower.FlowerID;
                    rowFlower["FlowerName"] = trd.MsFlower.FlowerName;
                    rowFlower["FlowerPrice"] = trd.MsFlower.FlowerPrice.GetValueOrDefault();
                    dFlower.Rows.Add(rowFlower);
                }

                rowHeader["GrandTotal"] = grandTotalPrice;
                header.Rows.Add(rowHeader);
            }

            return MemberTransactionDataSet;
        }

    }
}