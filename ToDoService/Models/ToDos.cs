using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoService.Models
{
    public class ToDos
    {
        public string ToDoName { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public bool Done { get; set; }

        public DateTime Date { get; set; }

    }
}
