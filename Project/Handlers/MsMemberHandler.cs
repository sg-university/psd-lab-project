using Project.Factory;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MsMemberHandler
    {
        readonly MsMemberRepository MsMemberRepository = new MsMemberRepository();
        readonly MsMemberFactory MsMemberFactory = new MsMemberFactory();

        public List<MsMember> ReadAll()
        {
            List<MsMember> result = MsMemberRepository.ReadAll();
            return result;
        }
        public MsMember ReadOneByID(Guid ID)
        {
            MsMember result = MsMemberRepository.ReadOneByID(ID);
            return result;
        }
        public MsMember CreateOne(string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            MsMember currentMsMember = MsMemberFactory.Create(Guid.NewGuid(), name, DOB, gender, address, phone, email, password);

            MsMember result = MsMemberRepository.CreateOne(currentMsMember);
            return result;
        }
        public MsMember UpdateOneByID(Guid ID, string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            MsMember currentMsMember = MsMemberFactory.Create(name, DOB, gender, address, phone, email, password);

            MsMember result = MsMemberRepository.UpdateOneByID(ID, currentMsMember);

            return result;
        }
        public MsMember DeleteOneByID(Guid ID)
        {
            MsMember result = MsMemberRepository.DeleteOneByID(ID);
            return result;
        }
    }
}