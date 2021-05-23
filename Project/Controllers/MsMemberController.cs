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
        public Result CreateOne(MsMember toCreateMsMember)
        {
            Result result = new Result();

            Boolean isEmailValid = toCreateMsMember.MemberEmail.Contains("@") && toCreateMsMember.MemberEmail.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(toCreateMsMember.MemberEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            Boolean isPasswordValid = (3 <= toCreateMsMember.MemberPassword.Length) && (toCreateMsMember.MemberPassword.Length <= 20);
            if (!isPasswordValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password must be length of 3-20 characters";
                return result;
            }

            Boolean isNameValid = (3 <= toCreateMsMember.MemberName.Length) && (toCreateMsMember.MemberName.Length <= 20);
            if (!isNameValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be length of 3-20 characters";
                return result;
            }

            Boolean isDOBValid = Math.Abs(toCreateMsMember.MemberDOB.Value.Year - DateTime.Now.Year) >= 17;
            if (!isDOBValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be minimal age of 17 years old";
                return result;
            }

            Boolean isGenderValid = !String.IsNullOrEmpty(toCreateMsMember.MemberGender) && new List<String> { "other", "male", "female" }.Contains(toCreateMsMember.MemberGender);
            if (!isGenderValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Gender must be chosen either male, female, or other";
                return result;
            }

            Boolean isPhoneNumberValid = true;
            try
            {
                Decimal.Parse(toCreateMsMember.MemberPhone);
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

            Boolean isAddressValid = toCreateMsMember.MemberAddress.ToLower().Contains("street");
            if (!isAddressValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Address must be contains 'street'";
                return result;
            }

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Member";
            result.Data = MsMemberHandler.CreateOne(toCreateMsMember);
            return result;
        }
        public Result UpdateOneByID(Guid ID, MsMember toUpdateMsMember)
        {
            Result result = new Result();

            Boolean isEmailValid = toUpdateMsMember.MemberEmail.Contains("@") && toUpdateMsMember.MemberEmail.Contains(".");
            if (!isEmailValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be contains '@' and '.'";
                return result;
            }

            Boolean isEmailRegistered = MsMemberHandler.ReadAll().Exists(x => x.MemberEmail.Equals(toUpdateMsMember.MemberEmail));
            if (isEmailRegistered)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Email must be unique and not registered";
                return result;
            }

            Boolean isPasswordValid = (3 <= toUpdateMsMember.MemberPassword.Length) && (toUpdateMsMember.MemberPassword.Length <= 20);
            if (!isPasswordValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Password must be length of 3-20 characters";
                return result;
            }

            Boolean isNameValid = (3 <= toUpdateMsMember.MemberName.Length) && (toUpdateMsMember.MemberName.Length <= 20);
            if (!isNameValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be length of 3-20 characters";
                return result;
            }

            Boolean isDOBValid = Math.Abs(toUpdateMsMember.MemberDOB.Value.Year - DateTime.Now.Year) >= 17;
            if (!isDOBValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "DOB must be minimal age of 17 years old";
                return result;
            }

            Boolean isGenderValid = !String.IsNullOrEmpty(toUpdateMsMember.MemberGender) && new List<String> { "other", "male", "female" }.Contains(toUpdateMsMember.MemberGender);
            if (!isGenderValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Gender must be chosen either male, female, or other";
                return result;
            }

            Boolean isPhoneNumberValid = true;
            try
            {
                Decimal.Parse(toUpdateMsMember.MemberPhone);
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

            Boolean isAddressValid = toUpdateMsMember.MemberAddress.ToLower().Contains("street");
            if (!isAddressValid)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Address must be contains 'street'";
                return result;
            }

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Member";
            result.Data = MsMemberHandler.UpdateOneByID(ID, toUpdateMsMember);
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