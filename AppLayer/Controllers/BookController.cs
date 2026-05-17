using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    public class BookController : Controller
    {
        BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        // EVERYONE CAN SEE BOOKS
        public ActionResult Index()
        {
            var data = bookService.Get();
            return View(data);
        }

        // ================= CREATE =================

        [HttpGet]
        public ActionResult Create()
        {
            // ONLY ADMIN
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(BookDTO b)
        {
            // ONLY ADMIN
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                var result = bookService.Create(b);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(b);
        }

        // ================= EDIT =================

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // ONLY ADMIN
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            var data = bookService.Get(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(BookDTO b)
        {
            // ONLY ADMIN
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                var result = bookService.Update(b);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(b);
        }

        // ================= DELETE =================

        public ActionResult Delete(int id)
        {
            // ONLY ADMIN
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            bookService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}