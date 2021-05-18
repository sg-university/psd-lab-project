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
        MsMemberRepository MsMemberRepository = new MsMemberRepository();
        public Result Register(MsMember toRegisterMsMember)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsMemberRepository.ReadAll().Exists(x => x.MemberEmail.Equals(toRegisterMsMember.MemberEmail));
            if (isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be unique and not registered";
                return res;
            }

            MsMember registeredMsMember = MsMemberRepository.CreateOne(toRegisterMsMember);
            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to register a MsMember";
            res.Data = registeredMsMember;

            return res;
        }

        public Result Login(String email, String password)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsMemberRepository.ReadAll().Exists(x => x.MemberEmail.Equals(email));
            if (!isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be registered";
                return res;
            }

            Boolean isCredentialsValid = MsMemberRepository.ReadAll().Exists(x => x.MemberEmail.Equals(email) && x.MemberPassword.Equals(password));
            if (!isCredentialsValid)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Invalid credentials";
                return res;
            }

            MsMember currentMsMember = MsMemberRepository.ReadAll().Find(x => x.MemberEmail.Equals(email) && x.MemberPassword.Equals(password));

            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to login a MsMember";
            res.Data = currentMsMember;

            return res;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsMemberRepository.ReadAll().Exists(x => x.MemberEmail.Equals(email));
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

            MsMember currentMsMember = MsMemberRepository.ReadAll().Find(x => x.MemberEmail.Equals(email));

            currentMsMember.MemberPassword = password;

            MsMember updatedMsMember = MsMemberRepository.UpdateOneByID(currentMsMember.MemberID, currentMsMember);

            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to reset password a MsMember";
            res.Data = updatedMsMember;

            return res;
        }

    }
}