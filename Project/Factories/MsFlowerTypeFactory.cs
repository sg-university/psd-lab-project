using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class MsFlowerTypeFactory
    {
        public MsFlowerType Create(Guid ID, string name)
        {
            MsFlowerType createdMsFlowerType = new MsFlowerType
            {
                FlowerTypeID = ID,
                FlowerTypeName = name
            };

            return createdMsFlowerType;
        }

        public MsFlowerType Create(string name)
        {
            MsFlowerType createdMsFlowerType = new MsFlowerType
            {
                FlowerTypeID = Guid.Empty,
                FlowerTypeName = name
            };

            return createdMsFlowerType;
        }
    }
}