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
            Result result = new Result();
            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(toRegisterMsMember.MemberEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            MsMember registeredMsMember = MsMemberAuthenticationHandler.Register(toRegisterMsMember);
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to register a Member";
            result.Data = registeredMsMember;
            return result;
        }

        public Result Login(String email, String password)
        {
            Result result = new Result();
            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(email));
            if (!isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be registered";
                return result;
            }

            Boolean isCredentialsValid = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(email) && x.MemberPassword.Equals(password));
            if (!isCredentialsValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Invalid credentials";
                return result;
            }

            MsMember currentMsMember = MsMemberAuthenticationHandler.Login(email, password);

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to login a Member";
            result.Data = currentMsMember;

            return result;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result result = new Result();
            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(email));
            if (!isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be registered";
                return result;
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
                result.ErrorCode = "403";
                result.ErrorMessage = "Captcha must be consists of 3 letters and 3 numbers";
                return result;
            }

            Boolean isPasswordEqualsCaptcha = password.Equals(captcha);
            if (!isPasswordEqualsCaptcha)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password and captcha must be equals";
                return result;
            }

            MsMember passwordResetedMsMember = MsMemberAuthenticationHandler.ForgotPassword(email, password, captcha);

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to reset password a Member";
            result.Data = passwordResetedMsMember;

            return result;
        }
    }
}