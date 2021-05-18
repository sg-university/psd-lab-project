using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MsEmployeeAuthenticationHandler
    {
        MsEmployeeRepository MsEmployeeRepository = new MsEmployeeRepository();
        public Result Register(MsEmployee toRegisterMsEmployee)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsEmployeeRepository.ReadAll().Exists(x => x.EmployeeEmail.Equals(toRegisterMsEmployee.EmployeeEmail));
            if (isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be unique and not registered";
                return res;
            }

            MsEmployee registeredMsEmployee = MsEmployeeRepository.CreateOne(toRegisterMsEmployee);
            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to register a MsEmployee";
            res.Data = registeredMsEmployee;

            return res;
        }

        public Result Login(String email, String password)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsEmployeeRepository.ReadAll().Exists(x => x.EmployeeEmail.Equals(email));
            if (!isEmailRegistered)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Email must be registered";
                return res;
            }

            Boolean isCredentialsValid = MsEmployeeRepository.ReadAll().Exists(x => x.EmployeeEmail.Equals(email) && x.EmployeePassword.Equals(password));
            if (!isCredentialsValid)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Invalid credentials";
                return res;
            }

            MsEmployee currentMsEmployee = MsEmployeeRepository.ReadAll().Find(x => x.EmployeeEmail.Equals(email) && x.EmployeePassword.Equals(password));

            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to login a MsEmployee";
            res.Data = currentMsEmployee;

            return res;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result res = new Result();
            Boolean isEmailRegistered = MsEmployeeRepository.ReadAll().Exists(x => x.EmployeeEmail.Equals(email));
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

            MsEmployee currentMsEmployee = MsEmployeeRepository.ReadAll().Find(x => x.EmployeeEmail.Equals(email));

            currentMsEmployee.EmployeePassword = password;

            MsEmployee updatedMsEmployee = MsEmployeeRepository.UpdateOneByID(currentMsEmployee.EmployeeID, currentMsEmployee);

            res.SuccessCode = "200";
            res.SucessMessage = "Succeed to reset password a MsEmployee";
            res.Data = updatedMsEmployee;

            return res;
        }

    }
}