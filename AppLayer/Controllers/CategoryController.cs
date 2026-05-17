//using BLL.DTOs;
//using BLL.Services;
//using DAL.EF;
//using DAL.EF.Tables;
//using Microsoft.AspNetCore.Mvc;

//namespace AppLayer.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly CategoryService _categoryService;

//        public CategoryController(CategoryService categoryService)
//        {
//            _categoryService = categoryService;
//        }



//    }
//}














using BLL.DTOs;
using BLL.Services;
using DAL.EF.Tables;
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

        // Show all categories
        public IActionResult Index()
        {
            var data = _categoryService.Get();
            return View(data);
        }

        // Load create page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Insert category
        [HttpPost]
        public IActionResult Create(CategoryDTO category)
        {
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














        //....................................

        // Load edit page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _categoryService.Get(id);

            return View(data);
        }

        // Update category
        [HttpPost]
        public IActionResult Edit(CategoryDTO category)
        {
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

        // Delete category
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
