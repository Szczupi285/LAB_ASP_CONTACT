using labolatorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace labolatorium_3___App.Controllers
{
    public class ContactController : Controller
    {

        static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();

        static int index = 1;

        public IActionResult Index()
        {
            return View(_contacts.Values.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid) 
            {
                model.Id = index++;
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
                
                // save object to database/collection or execute an operation
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View(_contacts[model.Id]);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            return View(_contacts[id]);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid && _contacts.ContainsKey(id))
            {
                _contacts.Remove(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contacts[id]);
        }
        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }

      
    }

 
}
