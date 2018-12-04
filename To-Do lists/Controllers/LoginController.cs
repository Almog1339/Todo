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
        [HttpGet]
        public object Get([FromForm]Users usersData)
        {
            if (string.IsNullOrEmpty(usersData.UserName)){
                return -1;
            }
            else {
                return Users.GetTasks(usersData.UserName);
            }
        }

        [HttpPost]
        public object Login([FromForm]Users usersData)
        {
            if (string.IsNullOrEmpty(usersData.UserName) || string.IsNullOrEmpty(usersData.Pass)) {
                return -1;
            }
            else {
                return Users.ValidateUser(usersData.UserName,usersData.Pass) ;
            }
        }
    }
}