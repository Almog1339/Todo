using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.wwwroot;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        public object Registration([FromForm] Users userData)
        {
            return string.IsNullOrEmpty(userData.UserName) || string.IsNullOrEmpty(userData.Pass) ||
                   string.IsNullOrEmpty(userData.FName) || string.IsNullOrEmpty(userData.LName)
                ? (object) -1
                : DBHelper.Register(userData.UserName, userData.Pass, userData.FName, userData.LName);
        }
    }
}