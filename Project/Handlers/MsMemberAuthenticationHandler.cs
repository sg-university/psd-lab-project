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
        public MsMember Register(MsMember toRegisterMsMember)
        {
            MsMember registeredMsMember = MsMemberHandler.CreateOne(toRegisterMsMember);

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