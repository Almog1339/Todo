using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo
{
    public class Users
    {
        public int user_id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime Date_of_birth { get; set; }
        public DateTime Created_at { get; set; }
        public int List_id { get; set; }

    }
}