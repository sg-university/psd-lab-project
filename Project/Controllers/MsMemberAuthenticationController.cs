using Project.Handlers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class MsMemberAuthenticationController
    {
        MsMemberAuthenticationHandler MemberAuthenticationHandler = new MsMemberAuthenticationHandler();

        public Result Register(MsMember toRegisterMsMember)
        {
            Result res = MemberAuthenticationHandler.Register(toRegisterMsMember);
            return res;
        }

        public Result Login(String email, String password)
        {
            Result res = MemberAuthenticationHandler.Login(email, password);
            return res;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result res = MemberAuthenticationHandler.ForgotPassword(email, password, captcha);
            return res;
        }

    }
}