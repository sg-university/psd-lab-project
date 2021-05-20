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
            res.SucessMessage = "Succeed to register a Member";
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
            res.SucessMessage = "Succeed to login a Member";
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

            int alpha, digit, i;
            alpha = digit = i = 0;
            while (captcha[i] != '\0')
            {
                if ((captcha[i] >= 'a' && captcha[i] <= 'z') || (captcha[i] >= 'A' && captcha[i] <= 'Z'))
                {
                    alpha++;
                }
                else if (captcha[i] >= '0' && captcha[i] <= '9')
                {
                    digit++;
                }
                i++;
            }

            Boolean isCaptchaConsistsOfThreeRandomLettersAndNumbers = (alpha == 3) && (digit == 3);
            if (!isCaptchaConsistsOfThreeRandomLettersAndNumbers)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Captcha must be consists of 3 letters and 3 numbers";
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
            res.SucessMessage = "Succeed to reset password a Member";
            res.Data = passwordResetedMsMember;

            return res;
        }
    }
}