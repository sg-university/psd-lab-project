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
        readonly MsMemberAuthenticationHandler MsMemberAuthenticationHandler = new MsMemberAuthenticationHandler();
        readonly MsMemberHandler MsMemberHandler = new MsMemberHandler();

        public Result Register(MsMember toRegisterMsMember)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(toRegisterMsMember.MemberEmail));
            if (isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be unique and not registered";
                return res;
            }

            MsMember registeredMsMember = MsMemberAuthenticationHandler.Register(toRegisterMsMember);
            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to register a MsMember";
            res.Data = registeredMsMember;
            return res;
        }

        public Result Login(String email, String password)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(email));
            if (!isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be registered";
                return res;
            }

            Boolean isCredentialsValid = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(email) && x.MemberPassword.Equals(password));
            if (!isCredentialsValid)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Invalid credentials";
                return res;
            }

            MsMember currentMsMember = MsMemberAuthenticationHandler.Login(email, password);

            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to login a MsMember";
            res.Data = currentMsMember;

            return res;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(email));
            if (!isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be registered";
                return res;
            }

            Boolean isPasswordEqualsCaptcha = password.Equals(captcha);
            if (!isPasswordEqualsCaptcha)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Password and captcha must be equals";
                return res;
            }

            MsMember passwordResetedMsMember = MsMemberAuthenticationHandler.ForgotPassword(email, password, captcha);

            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to reset password a MsMember";
            res.Data = passwordResetedMsMember;

            return res;
        }
    }
}