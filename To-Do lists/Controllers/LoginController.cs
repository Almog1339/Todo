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
        // POST api/Login
        [HttpPost]
        public string Login([FromForm]Users usersData)
        {
            if (string.IsNullOrEmpty(usersData.UserName) || string.IsNullOrEmpty(usersData.Pass)) {
                return "worng";
            }
            else {
                return Users.ValidateUser(usersData.UserName,usersData.Pass) ;
            }
        }
    }
}