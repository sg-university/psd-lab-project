﻿using Project.Handlers;
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


        public Result Register(String name, DateTime DOB, String gender, String address, String phone, String role, Decimal salary, String email, String password)
        {
            Result result = new Result();

            Boolean isEmailValid = email.Contains("@") && email.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(email));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            Boolean isPasswordValid = (3 <= password.Length) && (password.Length <= 20);
            if (!isPasswordValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password must be length of 3-20 characters";
                return result;
            }

            Boolean isNameValid = (3 <= name.Length) && (name.Length <= 20);
            if (!isNameValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be length of 3-20 characters";
                return result;
            }

            Boolean isDOBValid = Math.Abs(DOB.Year - DateTime.Now.Year) >= 17;
            if (!isDOBValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be minimal age of 17 years old";
                return result;
            }

            Boolean isGenderValid = !String.IsNullOrEmpty(gender) && new List<String> { "other", "male", "female" }.Contains(gender);
            if (!isGenderValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Gender must be chosen either male, female, or other";
                return result;
            }

            Boolean isPhoneNumberValid = true;
            try
            {
                Decimal.Parse(phone);
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

            Boolean isAddressValid = address.ToLower().Contains("street");
            if (!isAddressValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Address must be contains 'street'";
                return result;
            }

            MsEmployee registeredMsEmployee = MsEmployeeAuthenticationHandler.Register(name, DOB, gender, address, phone, role, salary, email, password);
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to register a Employee";
            result.Data = registeredMsEmployee;

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

            Boolean isEmailValid = email.Contains("@") && email.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(email));
            if (!isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be registered";
                return result;
            }

            int alpha, digit, i;
            alpha = digit = i = 0;
            while (i != captcha.Length)
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

            Boolean isCaptchaConsistsOfThreeRandomLettersAndNumbers = (alpha >= 3) && (digit >= 3);
            if (!isCaptchaConsistsOfThreeRandomLettersAndNumbers)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Captcha must be consists of atleast 3 letters and 3 numbers";
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

            MsEmployee updatedMsEmployee = MsEmployeeHandler.UpdateOneByID(currentMsEmployee.EmployeeID, currentMsEmployee.EmployeeName, currentMsEmployee.EmployeeDOB.GetValueOrDefault(), currentMsEmployee.EmployeeGender, currentMsEmployee.EmployeeAddress, currentMsEmployee.EmployeePhone, currentMsEmployee.EmployeeRole, currentMsEmployee.EmployeeSalary.GetValueOrDefault(), currentMsEmployee.EmployeeEmail, currentMsEmployee.EmployeePassword);

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to reset password a Employee";
            result.Data = updatedMsEmployee;

            return result;
        }
    }
}