using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class ContactController : Controller
    {
        List<Contact> contacts = new List<Contact>
        {
            new Contact()
            {
                Id = 1,
                Name = "Rayhan",
                Phone = "01708556674",
                Email = "r.hasnat@gmail.com",

            },
            new Contact()
            {
                Id = 2,
                Name = "Mishal",
                Phone = "018286398682",
                Email = "mishal@host.com"
            },
            new Contact()
            {
                Id = 3,
                Name = "Shawon",
                Phone = "0267268283",
                Email = "shawon@host.com"
            },
            new Contact()
            {
                Id = 4,
                Name = "Ahsan",
                Phone = "872674628",
                Email = "ahsan@host.com"
            },
        };

        [Route("/")]
        public IActionResult Index()
        {
            return Ok("This is a sample project");
        }

        [Route("populate-contacts")]
        public IActionResult PopulateContacts()
        {
           using (var db = new ContactContext())
           {
               List<Contact> contacts = new List<Contact>
               {
                    new Contact()
                    {
                        Name = "Rayhan",
                        Phone = "01708556674",
                        Email = "r.hasnat@gmail.com",

                    },
                    new Contact()
                    {
                        Name = "Mishal",
                        Phone = "018286398682",
                        Email = "mishal@host.com"
                    },
                    new Contact()
                    {
                        Name = "Shawon",
                        Phone = "0267268283",
                        Email = "shawon@host.com"
                    },
                    new Contact()
                    {
                        Id = 4,
                        Name = "Ahsan",
                        Phone = "872674628",
                        Email = "ahsan@host.com"
                    },
               };

               db.AddRange(contacts);
               db.SaveChanges();
           }

           return Ok("Contact populated");
        }

        [Route("get-contacts")]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }

        [Route("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            Contact contact = contacts.Where(c => c.Id == id).First();
            return Ok(contact);
        }

        [Route("get-by-phone/{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            Contact contact = contacts.Where(c => c.Phone == phone).First();
            return Ok(contact);
        }
    }
}
