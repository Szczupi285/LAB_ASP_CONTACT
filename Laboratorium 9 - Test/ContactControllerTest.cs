using labolatorium_3___App.Controllers;
using labolatorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_9___Test
{
    public class ContactControllerTest
    {
        private ContactController _contactController;
        private IContactService _contactService;
        private IDateTimeProvidercs _dateTimeProvider;

        public ContactControllerTest()
        {
            _dateTimeProvider = new CurrentDateTimeProvider();
            _contactService = new MemoryContactService(_dateTimeProvider);
            _contactService.Add(new Contact() { Id = 1 });
            _contactService.Add(new Contact() { Id = 2 });
            _contactService.Add(new Contact() { Id = 3 });

            _contactController = new ContactController(_contactService);
        }

        [Fact]
        public void IndexTest()
        {
            var res = _contactController.Index();
            Assert.IsType<ViewResult>(res);
            var view = res as ViewResult;
            var model = view.Model as List<Contact>;
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void DetailsTest()
        {
            var res = _contactController.Details(1);
            Assert.IsType<ViewResult>(res);
            var view = res as ViewResult;
            var model = view.Model as Contact;
            Assert.Equal(_contactService.FindById(1), model);
        }

        [Fact]

        public void DetailsTestNotFound()
        {
            var res = _contactController.Details(4);
            Assert.IsType<NotFoundResult>(res);
            
        }
    }
}