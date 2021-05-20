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
        public MsMember CreateOne(MsMember toCreateMsMember)
        {
            toCreateMsMember.MemberID = Guid.NewGuid();
            MsMember result = MsMemberRepository.CreateOne(toCreateMsMember);
            return result;
        }
        public MsMember UpdateOneByID(Guid ID, MsMember toUpdateMsMember)
        {
            MsMember result = MsMemberRepository.UpdateOneByID(ID, toUpdateMsMember);
            return result;
        }
        public MsMember DeleteOneByID(Guid ID)
        {
            MsMember result = MsMemberRepository.DeleteOneByID(ID);
            return result;
        }
    }
}