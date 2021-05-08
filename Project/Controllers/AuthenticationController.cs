using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class AuthenticationController
    {
        public UserRepository userRepository = new UserRepository();

        public Object Login(AuthCredentials authCredentials)
        {
            Object user = userRepository.ReadAll();
            //.Select(x->x.email == authCredentials.email && x.password == authCredentials.password);
            return user;
        }
    }
}