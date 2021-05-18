using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Repositories;

namespace Project.Controllers
{
    public class Validation
    {
       public static string FlowerValidation(string name, string description, string price)
        {
            if (String.IsNullOrEmpty(name) || name.Length < 5)
            {
                return "Name must be filled and minimal length is 5 characters!";
            }

            if (description.Length < 50)
            {
                return "Description must be longer than 50 characters!";
            }

            if (int.Parse(price) < 20 || int.Parse(price) > 100)
            {
                return "Price must be between 20 and 100 inclusively!";
            }

            return null;
        }



    }
}