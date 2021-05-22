using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Handlers;

namespace Project.Controllers
{
    public class MsFlowerController
    {
        readonly MsFlowerHandler MsFlowerHandler = new MsFlowerHandler();

        public Result CreateOne(MsFlower toCreateMsFlower)
        {
            Result result = new Result();
            if (String.IsNullOrEmpty(toCreateMsFlower.FlowerName) || toCreateMsFlower.FlowerName.Length < 5)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be filled and minimal length is 5 characters!";
                return result;
            }
            if (String.IsNullOrEmpty(toCreateMsFlower.FlowerImage) || !toCreateMsFlower.FlowerImage.ToLower().EndsWith(".jpg"))
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Image must be uploaded and only image with .jpg are allowed!";
                return result;
            }
            if (String.IsNullOrEmpty(toCreateMsFlower.FlowerDescription) || toCreateMsFlower.FlowerDescription.Length < 50)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Description must be filled and longer than 50 characters!";
                return result;
            }
            if (String.IsNullOrEmpty(toCreateMsFlower.FlowerPrice.ToString()) || toCreateMsFlower.FlowerPrice < 20 || toCreateMsFlower.FlowerPrice > 100)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Price must be filled and between 20 and 100 inclusively!";
                return result;
            }
            //MsFlowerHandler.AddNewFlower(name, description, type, int.Parse(price));

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Flower";
            result.Data = MsFlowerHandler.CreateOne(toCreateMsFlower);
            return result;
        }
    }
}