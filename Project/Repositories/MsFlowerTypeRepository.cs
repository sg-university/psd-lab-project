using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class MsFlowerTypeRepository
    {
        readonly NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public List<MsFlowerType> ReadAll()
        {
            List<MsFlowerType> result = db.MsFlowerTypes.ToList();
            return result;
        }
        public MsFlowerType ReadOneByID(int ID)
        {
            MsFlowerType result = this.ReadAll().Where(x => x.FlowerTypeID.Equals(ID)).FirstOrDefault();
            return result;
        }
        public MsFlowerType CreateOne(MsFlowerType toCreateMsFlowerType)
        {
            db.MsFlowerTypes.Add(toCreateMsFlowerType);
            db.SaveChanges();
            MsFlowerType currentMsFlowerType = this.ReadAll().LastOrDefault();
            return currentMsFlowerType;
        }
        public MsFlowerType UpdateOneByID(int ID, MsFlowerType toUpdateMsFlowerType)
        {
            MsFlowerType currentMsFlowerType = this.ReadOneByID(ID);
            currentMsFlowerType.FlowerTypeName = toUpdateMsFlowerType.FlowerTypeName;
            db.SaveChanges();
            return currentMsFlowerType;
        }
        public MsFlowerType DeleteOneByID(int ID)
        {
            MsFlowerType currentMsFlowerType = this.ReadOneByID(ID);
            db.MsFlowerTypes.Remove(currentMsFlowerType);
            db.SaveChanges();
            return currentMsFlowerType;
        }
    }
}
