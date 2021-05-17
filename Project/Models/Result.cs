using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Result
    {
        public String SuccessCode;
        public String SucessMessage;
        public String ErrorCode;
        public String ErrorMessage;
        public Object Data;

        public Result()
        {
            this.SuccessCode = null;
            this.SucessMessage = null;
            this.ErrorCode = null;
            this.ErrorMessage = null;
            this.Data = null;
        }

        public Result(string successCode, string sucessMessage, string errorCode, string errorMessage, object data)
        {
            SuccessCode = successCode;
            SucessMessage = sucessMessage;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Data = data;
        }
    }
}