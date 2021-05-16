using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class MsMemberFactory
    {
        public MsMember Create(Guid ID, string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            MsMember createdMsMember = new MsMember
            {
                MemberID = ID,
                MemberName = name,
                MemberDOB = DOB,
                MemberGender = gender,
                MemberAddress = address,
                MemberPhone = phone,
                MemberEmail = email,
                MemberPassword = password
            };

            return createdMsMember;
        }
    }
}