﻿using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class MsFlowerFactory
    {
        public static MsFlower Create(Guid ID, string name, Guid typeID, string description, decimal price, string image)
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
    }
}