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

            Boolean isEmailValid = toRegisterMsMember.MemberEmail.Contains("@") && toRegisterMsMember.MemberEmail.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(toRegisterMsMember.MemberEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            Boolean isPasswordValid = (3 <= toRegisterMsMember.MemberPassword.Length) && (toRegisterMsMember.MemberPassword.Length <= 20);
            if (!isPasswordValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password must be length of 3-20 characters";
                return result;
            }

            Boolean isNameValid = (3 <= toRegisterMsMember.MemberName.Length) && (toRegisterMsMember.MemberName.Length <= 20);
            if (!isNameValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be length of 3-20 characters";
                return result;
            }

            Boolean isDOBValid = Math.Abs(toRegisterMsMember.MemberDOB.Value.Year - DateTime.Now.Year) >= 17;
            if (!isDOBValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be minimal age of 17 years old";
                return result;
            }

            Boolean isGenderValid = !String.IsNullOrEmpty(toRegisterMsMember.MemberGender) && new List<String> { "other", "male", "female" }.Contains(toRegisterMsMember.MemberGender);
            if (!isGenderValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Gender must be chosen either male, female, or other";
                return result;
            }

            Boolean isPhoneNumberValid = true;
            try
            {
                Decimal.Parse(toRegisterMsMember.MemberPhone);
            }
            catch
            {
                isPhoneNumberValid = false;
            }

            if (!isPhoneNumberValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Phone Number must be numeric";
                return result;
            }

            Boolean isAddressValid = toRegisterMsMember.MemberAddress.ToLower().Contains("street");
            if (!isAddressValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Address must be contains 'street'";
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

            Boolean isEmailValid = email.Contains("@") && email.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

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

            Boolean isEmailValid = email.Contains("@") && email.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

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