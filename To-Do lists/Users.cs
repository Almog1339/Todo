﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;

namespace ToDo
{
    public class Users
    {
        public string TodoText { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public char Gender { get; set; }
        public DateTime Date_of_birth { get; set; }
    }
}
