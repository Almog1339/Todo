using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ToDo.wwwroot
{
    public class ListAndTasks
    {
        public string Content { get; set; }

        public ListAndTasks(string Content)
        {
            
            this.Content = Content;
        }
    }
}
