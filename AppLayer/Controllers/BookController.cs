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

        
        public ActionResult Index(string search)
        {
            var data = new List<BookDTO>();

            if (!string.IsNullOrEmpty(search))
            {
                data = bookService.Search(search);
            }
            else
            {
                data = bookService.Get();
            }

            return View(data);
        }

        

        [HttpGet]
        public ActionResult Create()
        {
           
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(BookDTO b)
        {
           
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

        

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
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

        

        public ActionResult Delete(int id)
        {
            
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            bookService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}