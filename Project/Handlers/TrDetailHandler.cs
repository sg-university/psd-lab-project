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
            toCreateTrDetail.TransactionID = Guid.NewGuid();
            TrDetail result = TrDetailRepository.CreateOne(toCreateTrDetail);
            return result;
        }
        public TrDetail UpdateOneByID(Guid ID, TrDetail toUpdateTrDetail)
        {
            TrDetail result = TrDetailRepository.UpdateOneByID(ID, toUpdateTrDetail);
            return result;
        }
        public TrDetail DeleteOneByID(Guid ID)
        {
            TrDetail result = TrDetailRepository.DeleteOneByID(ID);
            return result;
        }
    }
}