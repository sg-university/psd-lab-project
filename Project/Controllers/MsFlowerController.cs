using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    public class MsFlowerController
    {
        public static Result InsertFlower(string name, string uploadedImage, string description, string type, string price)
        {
            Result res = new Result();
            if(String.IsNullOrEmpty(name) || name.Length < 5)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Name must be filled and minimal length is 5 characters!";
                return res;
            }
            if (String.IsNullOrEmpty(uploadedImage) || !uploadedImage.ToLower().EndsWith(".jpg"))
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Only image with .jpg are allowed!";
                return res;
            }
            if (String.IsNullOrEmpty(description) || description.Length < 50)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Description must be filled and longer than 50 characters!";
                return res;
            }
            if(String.IsNullOrEmpty(price) || int.Parse(price) < 20 || int.Parse(price) > 100)
            {
                res.ErrorCode = "403";
                res.ErrorMessage = "Price must be filled and between 20 and 100 inclusively!";
                return res;
            }

            
            res.SuccessCode = "200";
            res.SucessMessage = "Flower Added!";
            return res;
        }
    }
}