using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class TrHeaderFactory
    {
        public TrHeader Create(Guid transactionID, Guid memberID, Guid employeeID, DateTime transactionDate, decimal discountPercentage)
        {
            TrHeader createdTrHeader = new TrHeader
            {
                TransactionID = transactionID,
                MemberID = memberID,
                EmployeeID = employeeID,
                TransactionDate = transactionDate,
                DiscountPercentage = discountPercentage,
            };

            return createdTrHeader;
        }
    }
}