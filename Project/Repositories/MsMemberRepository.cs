using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class MsMemberRepository
    {
        readonly NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public List<MsMember> ReadAll()
        {
            List<MsMember> result = db.MsMembers.ToList();
            return result;
        }
        public MsMember ReadOneByID(int ID)
        {
            MsMember result = this.ReadAll().Where(x => x.MemberID.Equals(ID)).FirstOrDefault();
            return result;
        }
        public MsMember CreateOne(MsMember toCreateMsMember)
        {
            db.MsMembers.Add(toCreateMsMember);
            db.SaveChanges();
            MsMember currentMsMember = this.ReadAll().LastOrDefault();
            return currentMsMember;
        }
        public MsMember UpdateOneByID(int ID, MsMember toUpdateMsMember)
        {
            MsMember currentMsMember = this.ReadOneByID(ID);
            currentMsMember.MemberName = toUpdateMsMember.MemberName;
            currentMsMember.MemberDOB = toUpdateMsMember.MemberDOB;
            currentMsMember.MemberGender = toUpdateMsMember.MemberGender;
            currentMsMember.MemberAddress = toUpdateMsMember.MemberAddress;
            currentMsMember.MemberPhone = toUpdateMsMember.MemberPhone;
            currentMsMember.MemberEmail = toUpdateMsMember.MemberEmail;
            currentMsMember.MemberPassword = toUpdateMsMember.MemberPassword;
            db.SaveChanges();
            return currentMsMember;
        }
        public MsMember DeleteOneByID(int ID)
        {
            MsMember currentMsMember = this.ReadOneByID(ID);
            db.MsMembers.Remove(currentMsMember);
            db.SaveChanges();
            return currentMsMember;
        }
    }
}
