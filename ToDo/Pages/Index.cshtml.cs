using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly ICustomerService _customerService;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IToDoList ToDoService, ICustomerService customerService)
        {
            _logger = logger;
            this._configuration = configuration;
            this._ToDoService = ToDoService;
            this._customerService = customerService;
        }

        public List<ToDos> ToDosList { get; set; }
        public List<ToDos> ToDosListDone { get; set; }
        public string NewItem { get; set; }



        [BindProperty]
        public string ToDoName { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        public string Email { get; set; }


        public void OnGet()
        {
            ToDosList = _ToDoService.GetToDos();
            ToDosListDone = _ToDoService.GetDoneToDos();
        }

        public void OnPost()
        {
            ToDosList = _ToDoService.AddToDos(ToDoName, Description);
            ToDoName = "";
            Description = "";
            ModelState.Clear();
        }

        public void OnPostGetUnDoneToDos()
        {
            ToDosList = _ToDoService.GetToDos();
        }

        public void OnPostNewsLetter()
        {
            _customerService.AddCustomerNewsletter(Name, Email);
        }

    }
}
