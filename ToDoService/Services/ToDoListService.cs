using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDoService.Services
{
    public class ToDoListService : IToDoList
    {
        #region list and propetys
        private static List<ToDos> ToDoList = new List<ToDos>();
        private List<ToDos> FilteredToDoL = new List<ToDos>();
        private ToDos Todos = new ToDos();
        static int i = 1;
        #endregion

        #region methoead that manipulate data
        public List<ToDos> AddToDos(string toDo, string description)
        {
            ToDoList.Add(new ToDos { ToDoName = toDo, Done = false, Description = description, Id = i, Date = DateTime.Now.Date });
            ++i;
            return ToDoList;
        }

        public ToDos moveToDos(string toDo, string Description, int id)
        {
            foreach (ToDos toDos in ToDoList)
            {
                if (id == toDos.Id)
                {
                    toDos.Done = true;
                }
            }
            return Todos;
        }


        public ToDos UpdateToDos(string toDo, string Description, int id, bool done)
        {
            foreach (ToDos toDos in ToDoList)
            {
                if (id == toDos.Id)
                {
                    if (toDo != null)
                        toDos.ToDoName = toDo;
                    if (Description != null)
                        toDos.Description = Description;
                    toDos.Done = done;
                    Todos = toDos;
                }
            }
            return Todos;
        }

        public void RemoveToDos(int id)
        {
            ToDoList.RemoveAt(--id);

        }

        public List<ToDos> FilterForvard(DateTime date)
        {
            foreach (ToDos toDos in ToDoList)
            {
                if (date <= toDos.Date)
                {
                    FilteredToDoL.Add(toDos);

                }
            }
            return FilteredToDoL;
        }

        List<ToDos> IToDoList.FilterOlder(DateTime date)
        {
            foreach (ToDos toDos in ToDoList)
            {
                if (date >= toDos.Date)
                {
                    FilteredToDoL.Add(toDos);

                }
            }
            return FilteredToDoL;

        }

        #endregion

        #region Get metoder


        public List<ToDos> GetToDos()
        {
            return ToDoList;
        }

        public ToDos GetToDo(int id)
        {
            foreach (ToDos todo in ToDoList)
            {
                if (id == todo.Id)
                {
                    Todos = todo;
                }
            }
            return Todos;
        }

        #endregion

    }
}
