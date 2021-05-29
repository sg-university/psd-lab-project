﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factory;
using Project.Repositories;
using Project.Models;
using System.IO;

namespace Project.Handlers
{
    public class MsFlowerHandler
    {
        readonly MsFlowerRepository MsFlowerRepository = new MsFlowerRepository();
        readonly MsFlowerFactory MsFlowerFactory = new MsFlowerFactory();

        public List<MsFlower> ReadAll()
        {
            List<MsFlower> result = MsFlowerRepository.ReadAll();
            return result;
        }
        public MsFlower ReadOneByID(Guid ID)
        {
            MsFlower result = MsFlowerRepository.ReadOneByID(ID);
            return result;
        }
        public MsFlower CreateOne(MsFlower toCreateMsFlower)
        {
            toCreateMsFlower.FlowerID = Guid.NewGuid();
            //toCreateMsFlower.FlowerImage = "~/Assets/Images/" + Guid.NewGuid().ToString();
            MsFlower result = MsFlowerRepository.CreateOne(toCreateMsFlower);
            return result;
        }
        public MsFlower UpdateOneByID(Guid ID, MsFlower toUpdateMsFlower)
        {
            MsFlower result = MsFlowerRepository.UpdateOneByID(ID, toUpdateMsFlower);
            return result;
        }
        public MsFlower DeleteOneByID(Guid ID)
        {
            MsFlower result = MsFlowerRepository.DeleteOneByID(ID);
            return result;
        }
    }
}