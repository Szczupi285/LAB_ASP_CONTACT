using labolatorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace labolatorium_3___App.Controllers
{
    public class ForumController : Controller
    {

        private readonly IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            return View(_forumService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Forum model)
        {
            if (ModelState.IsValid)
            {
                _forumService.Add(model);
                return RedirectToAction("Index", "Forum");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_forumService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Forum model)
        {
            if (ModelState.IsValid)
            {
                _forumService.Update(model);
                return RedirectToAction("Index", "Forum");
            }
            return View(_forumService.FindById(model.Id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_forumService.FindById(id));
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid && _forumService.FindById(id) is not null)
            {
                _forumService.Delete(id);
            }

            return RedirectToAction("Index", "Forum");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_forumService.FindById(id));
        }
        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index", "Forum");
        }
    }
}
