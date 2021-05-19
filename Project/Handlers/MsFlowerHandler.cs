using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factory;
using Project.Repositories;
using Project.Models;

namespace Project.Handlers
{
    
    public class MsFlowerHandler
    {
        static MsFlowerRepository flowerRepo = new MsFlowerRepository();
        static MsFlowerTypeRepository typeRepo = new MsFlowerTypeRepository();
        static MsFlowerFactory flowerFac = new MsFlowerFactory();

        public static void AddNewFlower(string name, string description, string type, int price)
        {
            Guid id = new Guid();
            Guid typeid = typeRepo.ReadOneByTypeName(type).FlowerTypeID;
            MsFlower newFlower = flowerFac.Create(id, name, typeid, description, price, "~/Image/"+name);
            flowerRepo.CreateOne(newFlower);
        }
        
    }
}