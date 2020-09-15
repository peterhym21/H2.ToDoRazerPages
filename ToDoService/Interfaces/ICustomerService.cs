using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoService.Models;

namespace ToDoService.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomerNewsletter(string name, string email);
        void AddCustomerContact(string name, string email, string description);

        void SendEmailNews(string name, string email);
        void SendEmailContact(string name, string email, string description);


        List<Customer> GetCustomersNews();

        List<Customer> GetCustomersContact();

    }
}
