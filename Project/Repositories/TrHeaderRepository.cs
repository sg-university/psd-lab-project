using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class TrHeaderRepository
    {
        readonly NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public List<TrHeader> ReadAll()
        {
            List<TrHeader> result = db.TrHeaders.ToList();
            return result;
        }
        public TrHeader ReadOneByID(Guid ID)
        {
            TrHeader result = this.ReadAll().Where(x => x.TransactionID.Equals(ID)).FirstOrDefault();
            return result;
        }
        public TrHeader CreateOne(TrHeader toCreateTrHeader)
        {
            db.TrHeaders.Add(toCreateTrHeader);
            db.SaveChanges();
            TrHeader currentTrHeader = this.ReadAll().LastOrDefault();
            return currentTrHeader;
        }
        public TrHeader UpdateOneByID(Guid ID, TrHeader toUpdateTrHeader)
        {
            TrHeader currentTrHeader = this.ReadOneByID(ID);
            currentTrHeader.MemberID = toUpdateTrHeader.MemberID;
            currentTrHeader.EmployeeID = toUpdateTrHeader.EmployeeID;
            currentTrHeader.TransactionDate = toUpdateTrHeader.TransactionDate;
            currentTrHeader.DiscountPercentage = toUpdateTrHeader.DiscountPercentage;
            db.SaveChanges();
            return currentTrHeader;
        }
        public TrHeader DeleteOneByID(Guid ID)
        {
            TrHeader currentTrHeader = this.ReadOneByID(ID);
            db.TrHeaders.Remove(currentTrHeader);
            db.SaveChanges();
            return currentTrHeader;
        }
    }
}
