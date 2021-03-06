﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        [HttpPost]
        public object NewTask([FromForm]Users userData)
        {
            return !string.IsNullOrEmpty(userData.TodoText) ? DBHelper.AddNewTask(userData.UserName, userData.TodoText) : (object)-1;
        }

        [HttpDelete]
        public object DeleteTask([FromForm]Users userData)
        {
            return string.IsNullOrEmpty(userData.UserName) || string.IsNullOrEmpty(userData.TodoText)
                ? (object) -1
                : DBHelper.DeleteTasks(userData.UserName, userData.TodoText);
        }

    }
}