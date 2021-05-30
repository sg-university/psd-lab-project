using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class TrDetailFactory
    {
        public TrDetail Create(Guid ID, Guid transactionID, Guid flowerID, decimal quantity)
        {
            TrDetail createdTrDetail = new TrDetail
            {
                DetailID = ID,
                TransactionID = transactionID,
                FlowerID = flowerID,
                Quantity = quantity,
            };

            return createdTrDetail;
        }

        public TrDetail Create(Guid transactionID, Guid flowerID, decimal quantity)
        {
            TrDetail createdTrDetail = new TrDetail
            {
                DetailID = Guid.Empty,
                TransactionID = transactionID,
                FlowerID = flowerID,
                Quantity = quantity,
            };

            return createdTrDetail;
        }
    }
}