using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class TrDetailRepository
    {
        readonly NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public List<TrDetail> ReadAll()
        {
            List<TrDetail> result = db.TrDetails.ToList();
            return result;
        }
        public TrDetail ReadOneByID(int ID)
        {
            TrDetail result = this.ReadAll().Where(x => x.TransactionID.Equals(ID)).FirstOrDefault();
            return result;
        }
        public TrDetail CreateOne(TrDetail toCreateTrDetail)
        {
            db.TrDetails.Add(toCreateTrDetail);
            db.SaveChanges();
            TrDetail currentTrDetail = this.ReadAll().LastOrDefault();
            return currentTrDetail;
        }
        public TrDetail UpdateOneByID(int ID, TrDetail toUpdateTrDetail)
        {
            TrDetail currentTrDetail = this.ReadOneByID(ID);
            currentTrDetail.FlowerID = toUpdateTrDetail.FlowerID;
            currentTrDetail.Quantity = toUpdateTrDetail.Quantity;
            db.SaveChanges();
            return currentTrDetail;
        }
        public TrDetail DeleteOneByID(int ID)
        {
            TrDetail currentTrDetail = this.ReadOneByID(ID);
            db.TrDetails.Remove(currentTrDetail);
            db.SaveChanges();
            return currentTrDetail;
        }
    }
}
