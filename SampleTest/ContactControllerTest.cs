using Microsoft.AspNetCore.Mvc;
using Sample;
using Sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleTest
{
    public class ContactControllerTest
    {
        ContactController _contactController;

        public ContactControllerTest()
        {
            _contactController = new ContactController();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = _contactController.GetContacts();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllContacts()
        {
            // Act
            var okResult = _contactController.GetContacts() as OkObjectResult;

            // Assert
            var contacts = Assert.IsType<List<Contact>>(okResult.Value);
            Assert.NotEmpty(contacts);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsSingleContact()
        {
            Contact testContact = new Contact()
            {
                Id = 1,
                Name = "Rayhan",
                Phone = "01708556674"
            };

            // Act
            var okResult = _contactController.GetById(testContact.Id) as OkObjectResult;

            // Assert
            var contact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(testContact.Name, contact.Name);
        }
        
        [Fact]
        public void GetByPhone_WhenCalled_ReturnsSingleContact()
        {
            Contact testContact = new Contact()
            {
                Id = 1,
                Name = "Rayhan",
                Phone = "01708556674"
            };

            // Act
            var okResult = _contactController.GetByPhone(testContact.Phone) as OkObjectResult;

            // Assert
            var contact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(testContact.Name, contact.Name);
        }
    }
}
