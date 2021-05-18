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
        MsEmployeeAuthenticationHandler EmployeeAuthenticationHandler = new MsEmployeeAuthenticationHandler();
        
        public Result Register(MsEmployee toRegisterMsEmployee)
        {
            Result res = EmployeeAuthenticationHandler.Register(toRegisterMsEmployee);
            return res;
        }

        public Result Login(String email, String password)
        {
            Result res = EmployeeAuthenticationHandler.Login(email, password);
            return res;
        }

        public Result ForgotPassword(String email, String password, String captcha)
        {
            Result res = EmployeeAuthenticationHandler.ForgotPassword(email, password, captcha);
            return res;
        }

    }
}