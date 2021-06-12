using Project.Handlers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class MsMemberController
    {
        readonly MsMemberHandler MsMemberHandler = new MsMemberHandler();
        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Member";
            result.Data = MsMemberHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Member";
            result.Data = MsMemberHandler.ReadOneByID(ID);
            return result;
        }
        public Result CreateOne(string name, DateTime DOB, string gender, string address, string phone, string email, string password)
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

            Boolean isDateValid = DOB != null;
            if (!isDateValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be valid";
                return result;
            }

            Boolean isDateRangeValid = DOB.Year >= 1753;
            if (!isDateRangeValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "TDOB must be in valid range (1753 <= Year <= 9999)";
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

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Member";
            result.Data = MsMemberHandler.CreateOne(name, DOB, gender, address, phone, email, password);
            return result;
        }
        public Result UpdateOneByID(Guid ID, string name, DateTime DOB, string gender, string address, string phone, string email, string password)
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

            Boolean isDateValid = DOB != null;
            if (!isDateValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be valid";
                return result;
            }

            Boolean isDateRangeValid = DOB.Year >= 1753;
            if (!isDateRangeValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be in valid range (1753 <= Year <= 9999)";
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

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Member";
            result.Data = MsMemberHandler.UpdateOneByID(ID, name, DOB, gender, address, phone, email, password);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Member";
            result.Data = MsMemberHandler.DeleteOneByID(ID);
            return result;
        }
    }
}