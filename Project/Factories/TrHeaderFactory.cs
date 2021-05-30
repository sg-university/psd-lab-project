using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class TrHeaderFactory
    {
        public TrHeader Create(Guid ID, Guid memberID, Guid employeeID, DateTime transactionDate, decimal discountPercentage)
        {
            TrHeader createdTrHeader = new TrHeader
            {
                TransactionID = ID,
                MemberID = memberID,
                EmployeeID = employeeID,
                TransactionDate = transactionDate,
                DiscountPercentage = discountPercentage,
            };

            return createdTrHeader;
        }

        public TrHeader Create(Guid memberID, Guid employeeID, DateTime transactionDate, decimal discountPercentage)
        {
            TrHeader createdTrHeader = new TrHeader
            {
                TransactionID = Guid.Empty,
                MemberID = memberID,
                EmployeeID = employeeID,
                TransactionDate = transactionDate,
                DiscountPercentage = discountPercentage,
            };

            return createdTrHeader;
        }
    }
}