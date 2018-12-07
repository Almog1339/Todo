using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public object Login([FromForm] Users usersData) => string.IsNullOrEmpty(usersData.UserName) || string.IsNullOrEmpty(usersData.Pass)
                ? -1
                : Users.ValidateUser(usersData.UserName, usersData.Pass);

        [HttpPut]
        public bool RegisterNewUser([FromForm] Users userData)
        {
            if (string.IsNullOrEmpty(userData.UserName) || string.IsNullOrEmpty(userData.FName) ||
                string.IsNullOrEmpty(userData.LName)) {
                return false;
            }
            else {
                return Users.Register(userData.UserName, userData.Pass, userData.FName, userData.LName, userData.Gender,
                    userData.Date_of_birth);
            }
        }
    }
}