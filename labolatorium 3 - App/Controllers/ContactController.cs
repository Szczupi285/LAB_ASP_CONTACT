using labolatorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace labolatorium_3___App.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.Organizations = _contactService.FindAllOrganizations()
                .Select(oe => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = oe.Name,
                    Value = oe.Id.ToString(),
                }).ToList();
            model.Organizations.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = "Brak organizacji",
                Value = "",
            });
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Contact model = _contactService.FindById(id);
            model.Organizations = _contactService.FindAllOrganizations()
              .Select(oe => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
              {
                  Text = oe.Name,
                  Value = oe.Id.ToString(),
              }).ToList();
            model.Organizations.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = "Brak organizacji",
                Value = "",
            });

            return View(model);

            
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View(_contactService.FindById(model.Id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid && _contactService.FindById(id) is not null)
            {
                _contactService.Delete(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }
    }




}
