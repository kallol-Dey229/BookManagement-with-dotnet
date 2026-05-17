


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

        // GET: Show all books
        public ActionResult Index()
        {
            var data = bookService.Get();
            return View(data);
        }

        // GET: Show create form
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Save book
        [HttpPost]
        public ActionResult Create(BookDTO b)
        {
            if (ModelState.IsValid)
            {
                // call service create method
                var result = bookService.Create(b);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(b);
        }












        //......................

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = bookService.Get(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(BookDTO b)
        {
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





        //......................
        public ActionResult Delete(int id)
        {
            bookService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}