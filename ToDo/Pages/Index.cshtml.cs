using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IToDoList _ToDoService;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IToDoList ToDoService)
        {
            _logger = logger;
            this._configuration = configuration;
            this._ToDoService = ToDoService;
        }

        public List<ToDos> ToDosList { get; set; }
        public List<ToDos> ToDosListDone { get; set; }

        [BindProperty]
        public string ToDoName { get; set; }
        [BindProperty]
        public string Decription { get; set; }


        public void OnGet()
        {
            ToDosList = _ToDoService.GetToDos();
            ToDosListDone = _ToDoService.GetDoneToDos();
        }

        public void OnPost()
        {
            ToDosList = _ToDoService.AddToDos(ToDoName, Decription);
        }

        public void OnPostGetUnDoneToDos()
        {
            ToDosList = _ToDoService.GetToDos();
        }

    }
}
