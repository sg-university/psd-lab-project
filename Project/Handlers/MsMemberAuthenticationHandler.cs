using Project.Factory;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MsMemberAuthenticationHandler
    {
        readonly MsMemberHandler MsMemberHandler = new MsMemberHandler();
        readonly MsMemberFactory MsMemberFactory = new MsMemberFactory();

        public MsMember Register(MsMember toRegisterMsMember)
        {
            MsMember currentMsMember = MsMemberFactory.Create(toRegisterMsMember.MemberName, toRegisterMsMember.MemberDOB.GetValueOrDefault(), toRegisterMsMember.MemberGender, toRegisterMsMember.MemberAddress, toRegisterMsMember.MemberPhone, toRegisterMsMember.MemberEmail, toRegisterMsMember.MemberPassword);

            MsMember registeredMsMember = MsMemberHandler.CreateOne(currentMsMember);

            return registeredMsMember;
        }

        public MsMember Login(String email, String password)
        {
            MsMember currentMsMember = MsMemberHandler.ReadAll().Find(x => x.MemberEmail.Equals(email) && x.MemberPassword.Equals(password));

            return currentMsMember;
        }

        public MsMember ForgotPassword(String email, String password, String captcha)
        {
            MsMember currentMsMember = MsMemberHandler.ReadAll().Find(x => x.MemberEmail.Equals(email));

            currentMsMember.MemberPassword = password;

            MsMember updatedMsMember = MsMemberHandler.UpdateOneByID(currentMsMember.MemberID, currentMsMember);

            return updatedMsMember;
        }
    }
}