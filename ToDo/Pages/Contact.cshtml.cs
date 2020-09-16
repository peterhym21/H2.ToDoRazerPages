using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDo.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IToDoList _ToDoService;
        private readonly ICustomerService _customerService;

        public ContactModel(IConfiguration configuration, IToDoList ToDoService, ICustomerService customerService)
        {
            this._configuration = configuration;
            this._ToDoService = ToDoService;
            this._customerService = customerService;
        
        }

        #region Property
        public List<Customer> Customers { get; set; }
        public List<Customer> NewsLetterSubs { get; set; }


        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Description { get; set; }

        #endregion
        public void OnGet()
        {
        }

        // check om all creterier der det i text felterne
        // add til en contact list og send en email
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {

            }
            else
            {
                _customerService.AddCustomerContact(Name, Email, Description);
                _customerService.SendEmailContact(Name, Email, Description);
            }



        }
        // få alle kontakts
        public void OnPostKontakt()
        {
            Customers = _customerService.GetCustomersContact();
        }

        // få en list af alle subscribers til newsletter
        public void OnPostNewslettersSubs()
        {
            NewsLetterSubs = _customerService.GetCustomersNews();
        }

    }
}
