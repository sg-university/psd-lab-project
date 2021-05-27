using Project.Factory;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MsFlowerTypeHandler
    {
        readonly MsFlowerTypeRepository MsFlowerTypeRepository = new MsFlowerTypeRepository();
        readonly MsFlowerTypeFactory MsFlowerTypeFactory = new MsFlowerTypeFactory();
        public List<MsFlowerType> ReadAll()
        {
            List<MsFlowerType> result = MsFlowerTypeRepository.ReadAll();
            return result;
        }
        public MsFlowerType ReadOneByID(Guid ID)
        {
            MsFlowerType result = MsFlowerTypeRepository.ReadOneByID(ID);
            return result;
        }
        public MsFlowerType CreateOne(MsFlowerType toCreateMsFlowerType)
        {
            toCreateMsFlowerType.FlowerTypeID = Guid.NewGuid();
            MsFlowerType result = MsFlowerTypeRepository.CreateOne(toCreateMsFlowerType);
            return result;
        }
        public MsFlowerType UpdateOneByID(Guid ID, MsFlowerType toUpdateMsFlowerType)
        {
            MsFlowerType result = MsFlowerTypeRepository.UpdateOneByID(ID, toUpdateMsFlowerType);
            return result;
        }
        public MsFlowerType DeleteOneByID(Guid ID)
        {
            MsFlowerType result = MsFlowerTypeRepository.DeleteOneByID(ID);
            return result;
        }
    }
}