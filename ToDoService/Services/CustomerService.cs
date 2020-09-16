using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDoService.Services
{
    public class CustomerService : ICustomerService
    {
        #region
        static List<Customer> newsCusomer = new List<Customer>();
        static List<Customer> contactCustomers = new List<Customer>();
        static int i = 1;
        static int id = 1;
        #endregion

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

        #region Mail
        public async void SendEmailContact(string name, string email, string description)
        {
            SmtpClient clienta = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("todonewsletter@gmail.com", "Todonews"),
                EnableSsl = true
            };
            await clienta.SendMailAsync("todonewsletter@gmail.com", email, "Contact", "Hej " + name + "\n Tak fordi du Kontaktede os, vi vil kontakte dig med en opføling snarst muligt");

            SmtpClient clientb = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("SmtpclientPH.meh@gmail.com", "pete102c"),
                EnableSsl = true
            };
            await clientb.SendMailAsync("SmtpclientPH.meh@gmail.com", "todonewsletter@gmail.com", name , name + " Har har følgende beskrivelse: \n " + description + "\n skriv hurtigs mugligt tilbage på:" + email);

        }

        public async void SendEmailNews(string name, string email)
        {
            //Todonews
            //todonewsletter@gmail.com
            SmtpClient clienta = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("todonewsletter@gmail.com", "Todonews"),
                EnableSsl = true
            };
            await clienta.SendMailAsync("todonewsletter@gmail.com", email, "News Letter", "Hej " + name + "\n Tak fordi du signed op til ToDos news Letter");

        }

        #endregion

    }
}
