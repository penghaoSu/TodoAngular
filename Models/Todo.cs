using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAngular.Models
{
    public class TodoResule
    {
        
    }


    public class Todo
    {
        public string text { get; set; }

        public bool done { get; set; }
    }

    public class TodoList
    {
        public List<Todo> Todolist { get; set; }
    }
}
