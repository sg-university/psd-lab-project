using Project.Handlers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class MsEmployeeAuthenticationController
    {
        readonly MsEmployeeAuthenticationHandler MsEmployeeAuthenticationHandler = new MsEmployeeAuthenticationHandler();
        readonly MsEmployeeHandler MsEmployeeHandler = new MsEmployeeHandler();


        public Result Register(MsEmployee toRegisterMsEmployee)
        {
            Result result = new Result();
            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(toRegisterMsEmployee.EmployeeEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            MsEmployee registeredMsEmployee = MsEmployeeHandler.CreateOne(toRegisterMsEmployee);
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to register a Employee";
            result.Data = registeredMsEmployee;

            return result;
        }

        public Result Login(String email, String password)
        {
            Result result = new Result();
            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(email));
            if (!isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be registered";
                return result;
            }

            Boolean isCredentialsValid = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(email) && x.EmployeePassword.Equals(password));
            if (!isCredentialsValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Invalid credentials";
                return result;
            }

            MsEmployee currentMsEmployee = MsEmployeeHandler.ReadAll().Find(x => x.EmployeeEmail.Equals(email) && x.EmployeePassword.Equals(password));

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to login a Employee";
            result.Data = currentMsEmployee;

            return result;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result result = new Result();
            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(email));
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

            MsEmployee currentMsEmployee = MsEmployeeHandler.ReadAll().Find(x => x.EmployeeEmail.Equals(email));

            currentMsEmployee.EmployeePassword = password;

            MsEmployee updatedMsEmployee = MsEmployeeHandler.UpdateOneByID(currentMsEmployee.EmployeeID, currentMsEmployee);

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to reset password a Employee";
            result.Data = updatedMsEmployee;

            return result;
        }
    }
}