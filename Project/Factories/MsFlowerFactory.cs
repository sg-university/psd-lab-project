using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class MsFlowerFactory
    {
        public MsFlower Create(Guid ID, string name, Guid typeID, string description, decimal price, string image)
        {
            MsFlower createdMsFlower = new MsFlower
            {
                FlowerID = ID,
                FlowerName = name,
                FlowerTypeID = typeID,
                FlowerDescription = description,
                FlowerPrice = price,
                FlowerImage = image,
            };

            return createdMsFlower;
        }
        public MsFlower Create(string name, Guid typeID, string description, decimal price, string image)
        {
            MsFlower createdMsFlower = new MsFlower
            {
                FlowerID = Guid.Empty,
                FlowerName = name,
                FlowerTypeID = typeID,
                FlowerDescription = description,
                FlowerPrice = price,
                FlowerImage = image,
            };

            return createdMsFlower;
        }
    }
}