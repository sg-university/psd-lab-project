using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class TrDetailFactory
    {
        public TrDetail Create(Guid transactionID, Guid flowerID, decimal quantity)
        {
            TrDetail createdTrDetail = new TrDetail
            {
                TransactionID = transactionID,
                FlowerID = flowerID,
                Quantity = quantity,
            };

            return createdTrDetail;
        }
    }
}