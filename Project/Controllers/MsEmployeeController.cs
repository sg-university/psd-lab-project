﻿using Project.Handlers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class MsEmployeeController
    {
        readonly MsEmployeeHandler MsEmployeeHandler = new MsEmployeeHandler();

        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Employee";
            result.Data = MsEmployeeHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Employee";
            result.Data = MsEmployeeHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(MsEmployee toCreateMsEmployee)
        {
            Result result = new Result();

            Boolean isEmailValid = toCreateMsEmployee.EmployeeEmail.Contains("@") && toCreateMsEmployee.EmployeeEmail.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(toCreateMsEmployee.EmployeeEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            Boolean isPasswordValid = (3 <= toCreateMsEmployee.EmployeePassword.Length) && (toCreateMsEmployee.EmployeePassword.Length <= 20);
            if (!isPasswordValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password must be length of 3-20 characters";
                return result;
            }

            Boolean isNameValid = (3 <= toCreateMsEmployee.EmployeeName.Length) && (toCreateMsEmployee.EmployeeName.Length <= 20);
            if (!isNameValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be length of 3-20 characters";
                return result;
            }

            Boolean isDateValid = toCreateMsEmployee.EmployeeDOB.GetValueOrDefault() != null;
            if (!isDateValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be valid";
                return result;
            }

            Boolean isDateRangeValid = toCreateMsEmployee.EmployeeDOB.GetValueOrDefault().Year >= 1753;
            if (!isDateRangeValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be in valid range (1753 <= Year <= 9999)";
                return result;
            }

            Boolean isDOBValid = Math.Abs(toCreateMsEmployee.EmployeeDOB.Value.Year - DateTime.Now.Year) >= 17;
            if (!isDOBValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be minimal age of 17 years old";
                return result;
            }

            Boolean isGenderValid = !String.IsNullOrEmpty(toCreateMsEmployee.EmployeeGender) && new List<String> { "other", "male", "female" }.Contains(toCreateMsEmployee.EmployeeGender);
            if (!isGenderValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Gender must be chosen either male, female, or other";
                return result;
            }

            Boolean isPhoneNumberValid = true;
            try
            {
                Decimal.Parse(toCreateMsEmployee.EmployeePhone);
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

            Boolean isAddressValid = toCreateMsEmployee.EmployeeAddress.ToLower().Contains("street");
            if (!isAddressValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Address must be contains 'street'";
                return result;
            }

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Employee";
            result.Data = MsEmployeeHandler.CreateOne(toCreateMsEmployee);
            return result;
        }
        public Result UpdateOneByID(Guid ID, MsEmployee toUpdateMsEmployee)
        {
            Result result = new Result();

            Boolean isEmailValid = toUpdateMsEmployee.EmployeeEmail.Contains("@") && toUpdateMsEmployee.EmployeeEmail.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsEmployeeHandler.ReadAll().Exists(x => x.EmployeeEmail.Equals(toUpdateMsEmployee.EmployeeEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            Boolean isPasswordValid = (3 <= toUpdateMsEmployee.EmployeePassword.Length) && (toUpdateMsEmployee.EmployeePassword.Length <= 20);
            if (!isPasswordValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password must be length of 3-20 characters";
                return result;
            }

            Boolean isNameValid = (3 <= toUpdateMsEmployee.EmployeeName.Length) && (toUpdateMsEmployee.EmployeeName.Length <= 20);
            if (!isNameValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be length of 3-20 characters";
                return result;
            }

            Boolean isDateValid = toUpdateMsEmployee.EmployeeDOB.GetValueOrDefault() != null;
            if (!isDateValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Transaction Date must be valid";
                return result;
            }

            Boolean isDateRangeValid = toUpdateMsEmployee.EmployeeDOB.GetValueOrDefault().Year >= 1753;
            if (!isDateRangeValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Transaction Date must be in valid range (1753 <= Year <= 9999)";
                return result;
            }

            Boolean isDOBValid = Math.Abs(toUpdateMsEmployee.EmployeeDOB.Value.Year - DateTime.Now.Year) >= 17;
            if (!isDOBValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be minimal age of 17 years old";
                return result;
            }

            Boolean isGenderValid = !String.IsNullOrEmpty(toUpdateMsEmployee.EmployeeGender) && new List<String> { "other", "male", "female" }.Contains(toUpdateMsEmployee.EmployeeGender);
            if (!isGenderValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Gender must be chosen either male, female, or other";
                return result;
            }

            Boolean isPhoneNumberValid = true;
            try
            {
                Decimal.Parse(toUpdateMsEmployee.EmployeePhone);
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

            Boolean isAddressValid = toUpdateMsEmployee.EmployeeAddress.ToLower().Contains("street");
            if (!isAddressValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Address must be contains 'street'";
                return result;
            }

            Boolean isSalaryValid = (100 <= toUpdateMsEmployee.EmployeeSalary) && (toUpdateMsEmployee.EmployeeSalary <= 1000);
            if (!isSalaryValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Salary must be in range of 100 to 1000 inclusively";
                return result;
            }

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Employee";
            result.Data = MsEmployeeHandler.UpdateOneByID(ID, toUpdateMsEmployee);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Employee";
            result.Data = MsEmployeeHandler.DeleteOneByID(ID);
            return result;
        }
    }
}