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


        public Result ReadAll()
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read all Flower";
            result.Data = MsFlowerHandler.ReadAll();
            return result;
        }
        public Result ReadOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to read one Flower";
            result.Data = MsFlowerHandler.ReadOneByID(ID);
            return result;
        }
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

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to create one Flower";
            result.Data = MsFlowerHandler.CreateOne(toCreateMsFlower);

            return result;
        }
        public Result UpdateOneByID(Guid ID, MsFlower toUpdateMsFlower)
        {
            Result result = new Result();

            if (String.IsNullOrEmpty(toUpdateMsFlower.FlowerName) || toUpdateMsFlower.FlowerName.Length < 5)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Name must be filled and minimal length is 5 characters!";
                return result;
            }
            if (String.IsNullOrEmpty(toUpdateMsFlower.FlowerImage) || !toUpdateMsFlower.FlowerImage.ToLower().EndsWith(".jpg"))
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Image must be uploaded and only image with .jpg are allowed!";
                return result;
            }
            if (String.IsNullOrEmpty(toUpdateMsFlower.FlowerDescription) || toUpdateMsFlower.FlowerDescription.Length < 50)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Description must be filled and longer than 50 characters!";
                return result;
            }
            if (String.IsNullOrEmpty(toUpdateMsFlower.FlowerPrice.ToString()) || toUpdateMsFlower.FlowerPrice < 20 || toUpdateMsFlower.FlowerPrice > 100)
            {
                result.ErrorCode = "403";
                result.ErrorMessage = "Price must be filled and between 20 and 100 inclusively!";
                return result;
            }

            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to update one Flower";
            result.Data = MsFlowerHandler.UpdateOneByID(ID, toUpdateMsFlower);
            return result;
        }
        public Result DeleteOneByID(Guid ID)
        {
            Result result = new Result();
            result.SuccessCode = "200";
            result.SucessMessage = "Succeed to delete one Flower";
            result.Data = MsFlowerHandler.DeleteOneByID(ID);
            return result;
        }
    }
}