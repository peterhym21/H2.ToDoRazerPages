using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoService.Models;

namespace ToDoService.Interfaces
{
    public interface IToDoList
    {
        List<ToDos> AddToDos(string toDo, string Description);
        void RemoveToDos(int id);
        ToDos UpdateToDos(string toDo, string Description, int id, bool done);
        List<ToDos> FilterForvard(DateTime date);
        List<ToDos> FilterOlder(DateTime date);


        List<ToDos> GetToDos();
        ToDos GetToDo(int id);

    }
}
