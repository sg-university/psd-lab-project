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
        public MsMember CreateOne(MsMember toCreateMsMember)
        {
            MsMember currentMsMember = MsMemberFactory.Create(Guid.NewGuid(), toCreateMsMember.MemberName, toCreateMsMember.MemberDOB.GetValueOrDefault(), toCreateMsMember.MemberGender, toCreateMsMember.MemberAddress, toCreateMsMember.MemberPhone, toCreateMsMember.MemberEmail, toCreateMsMember.MemberPassword);

            MsMember result = MsMemberRepository.CreateOne(currentMsMember);
            return result;
        }
        public MsMember UpdateOneByID(Guid ID, MsMember toUpdateMsMember)
        {
            MsMember currentMsMember = MsMemberFactory.Create(toUpdateMsMember.MemberName, toUpdateMsMember.MemberDOB.GetValueOrDefault(), toUpdateMsMember.MemberGender, toUpdateMsMember.MemberAddress, toUpdateMsMember.MemberPhone, toUpdateMsMember.MemberEmail, toUpdateMsMember.MemberPassword);

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