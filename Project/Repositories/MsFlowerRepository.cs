using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class MsFlowerRepository
    {
        readonly NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public List<MsFlower> ReadAll()
        {
            List<MsFlower> result = db.MsFlowers.ToList();
            return result;
        }
        public MsFlower ReadOneByID(Guid ID)
        {
            MsFlower result = this.ReadAll().Where(x => x.FlowerID.Equals(ID)).FirstOrDefault();
            return result;
        }
        public MsFlower CreateOne(MsFlower toCreateMsFlower)
        {
            db.MsFlowers.Add(toCreateMsFlower);
            db.SaveChanges();
            MsFlower currentMsFlower = this.ReadAll().LastOrDefault();
            return currentMsFlower;
        }
        public MsFlower UpdateOneByID(Guid ID, MsFlower toUpdateMsFlower)
        {
            MsFlower currentMsFlower = this.ReadOneByID(ID);
            currentMsFlower.FlowerName = toUpdateMsFlower.FlowerName;
            currentMsFlower.FlowerTypeID = toUpdateMsFlower.FlowerTypeID;
            currentMsFlower.FlowerDescription = toUpdateMsFlower.FlowerDescription;
            currentMsFlower.FlowerPrice = toUpdateMsFlower.FlowerPrice;
            currentMsFlower.FlowerImage = toUpdateMsFlower.FlowerImage;
            db.SaveChanges();
            return currentMsFlower;
        }
        public MsFlower DeleteOneByID(Guid ID)
        {
            MsFlower currentMsFlower = this.ReadOneByID(ID);
            db.MsFlowers.Remove(currentMsFlower);
            db.SaveChanges();
            return currentMsFlower;
        }
    }
}
