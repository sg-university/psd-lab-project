using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factory;
using Project.Repositories;
using Project.Models;

namespace Project.Handlers
{
    public class TrDetailHandler
    {
        readonly TrDetailRepository TrDetailRepository = new TrDetailRepository();
        readonly TrDetailFactory TrDetailFactory = new TrDetailFactory();

        public List<TrDetail> ReadAll()
        {
            List<TrDetail> result = TrDetailRepository.ReadAll();
            return result;
        }
        public TrDetail ReadOneByID(Guid ID)
        {
            TrDetail result = TrDetailRepository.ReadOneByID(ID);
            return result;
        }
        public TrDetail CreateOne(TrDetail toCreateTrDetail)
        {
            TrDetail currentTrDetail = TrDetailFactory.Create(Guid.NewGuid(), toCreateTrDetail.TransactionID.GetValueOrDefault(), toCreateTrDetail.FlowerID.GetValueOrDefault(), toCreateTrDetail.Quantity.GetValueOrDefault());

            TrDetail result = TrDetailRepository.CreateOne(currentTrDetail);

            return result;
        }
        public TrDetail UpdateOneByID(Guid ID, TrDetail toUpdateTrDetail)
        {
            TrDetail currentTrDetail = TrDetailFactory.Create(toUpdateTrDetail.TransactionID.GetValueOrDefault(), toUpdateTrDetail.FlowerID.GetValueOrDefault(), toUpdateTrDetail.Quantity.GetValueOrDefault());

            TrDetail result = TrDetailRepository.UpdateOneByID(ID, currentTrDetail);

            return result;
        }
        public TrDetail DeleteOneByID(Guid ID)
        {
            TrDetail result = TrDetailRepository.DeleteOneByID(ID);
            return result;
        }
    }
}