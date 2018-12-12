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
        [HttpPost]
        public object Login([FromForm] Users usersData) => string.IsNullOrEmpty(usersData.UserName) || string.IsNullOrEmpty(usersData.Pass)
                ? -1
                : DBHelper.ValidateUser(usersData.UserName, usersData.Pass);
    }
}