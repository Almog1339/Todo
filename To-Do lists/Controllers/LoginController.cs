using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.wwwroot;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public object NewTask([FromForm]Users userData)
        {
            if (!string.IsNullOrEmpty(userData.TodoText))
            {
                return DBHelper.AddNewTask(userData.UserName, userData.TodoText);
                
            } return -1;

        }

        [HttpPost]
        public object Login([FromForm] Users usersData) => string.IsNullOrEmpty(usersData.UserName) || string.IsNullOrEmpty(usersData.Pass)
                ? -1
                : DBHelper.ValidateUser(usersData.UserName, usersData.Pass);

        [HttpPut]
        public bool RegisterNewUser([FromForm] Users userData)
        {
            if (string.IsNullOrEmpty(userData.UserName) || string.IsNullOrEmpty(userData.FName) ||
                string.IsNullOrEmpty(userData.LName)) {
                return false;
            }
            else {
                return DBHelper.Register(userData.UserName, userData.Pass, userData.FName, userData.LName, userData.Gender,
                    userData.Date_of_birth);
            }
        }
    }
}