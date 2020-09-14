using System;
using System.Collections.Generic;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDoService.Services
{
    public class CustomerService : ICustomerService
    {

        static List<Customer> newsCusomer = new List<Customer>();
        static List<Customer> contactCustomers = new List<Customer>();
        int i = 1;
        int id = 1;

        public void AddCustomerContact(string name, string email, string description)
        {
            contactCustomers.Add(new Customer { Name = name, Email = email, Id = id, Description = description });
            ++i;
        }

        public void AddCustomerNewsletter(string name, string email)
        {
            newsCusomer.Add(new Customer { Name = name, Email = email, Id = i });
            ++i;
        }

        public List<Customer> GetCustomersContact()
        {
            return contactCustomers;
        }

        public List<Customer> GetCustomersNews()
        {
            return newsCusomer;
        }
    }
}
