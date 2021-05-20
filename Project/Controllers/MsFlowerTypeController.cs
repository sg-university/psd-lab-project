using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Handlers;

namespace Project.Controllers
{
    public class MsFlowerTypeController
    {
        readonly MsFlowerTypeHandler MsFlowerTypeHandler = new MsFlowerTypeHandler();

        public List<MsFlowerType> GetAllType()
        {
            return MsFlowerTypeHandler.ReadAll();
        }
    }
}