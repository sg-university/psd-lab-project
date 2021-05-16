using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Factories
{
    public class FlowerFactory
    {
        public static MsFlower CreateFlower(string name, string image, string description, string typeid, int price)
        {
            MsFlower NewFlower = new MsFlower();
            NewFlower.FlowerName = name;
            NewFlower.FlowerImage = image;
            NewFlower.FlowerDescription = description;
            //NewFlower.FlowerTypeID = typeid;
            NewFlower.FlowerPrice = price;
            return NewFlower;
        }
    }
}