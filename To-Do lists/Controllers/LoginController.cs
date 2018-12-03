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
        //api/GetTasks
        [HttpGet]
        public static string GetTasks([FromBody]Users usersData)
        {
            if (string.IsNullOrEmpty(usersData.UserName)) {
                return "you are missing username";
            }
            else {
                return Users.GetTasks(usersData.UserName);
            }
        }

        // POST api/Login
        [HttpPost]
        public object Login([FromForm]Users usersData)
        {
            if (string.IsNullOrEmpty(usersData.UserName) || string.IsNullOrEmpty(usersData.Pass)) {
                return "You are missing something....";
            }
            else {
                return Users.ValidateUser(usersData.UserName,usersData.Pass) ;
            }
        }
    }
}