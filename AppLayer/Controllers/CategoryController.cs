using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        public IActionResult Index()
        {
            var data = _categoryService.Get();
            return View(data);
        }

       

        [HttpGet]
        public IActionResult Create()
        {
            
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO category)
        {
           
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                bool result = _categoryService.Create(category);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

      

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            var data = _categoryService.Get(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CategoryDTO category)
        {
            
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                var result = _categoryService.Update(category);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        

        public IActionResult Delete(int id)
        {
            
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }

            _categoryService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}