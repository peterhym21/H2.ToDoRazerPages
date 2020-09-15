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
        ToDos moveToDos(string toDo, string Description, int id);
        void RemoveToDos(int id);
        ToDos EdditToDos(string toDo, string Description, int id);
        List<ToDos> FilterForvard(DateTime date);
        List<ToDos> FilterOlder(DateTime date);


        List<ToDos> GetToDos();
        List<ToDos> GetDoneToDos();
        ToDos GetToDoForEdit(int id);
        ToDos GetDoneToDoForEdit(int id);

    }
}
