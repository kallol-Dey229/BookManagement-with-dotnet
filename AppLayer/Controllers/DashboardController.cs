using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    public class DashboardController : Controller
    {
        UserService userService;
        BookService bookService;
        CategoryService categoryService;

        public DashboardController(
            UserService userService,
            BookService bookService,
            CategoryService categoryService)
        {
            this.userService = userService;
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            // Statistics
            ViewBag.TotalUsers = userService.GetUsers().Count;
            ViewBag.TotalBooks = bookService.Get().Count;
            ViewBag.TotalCategories = categoryService.Get().Count;

            // User List
            var users = userService.GetUsers();

            return View(users);
        }

        public IActionResult DeleteUser(int id)
        {
            userService.DeleteUser(id);

            return RedirectToAction("AdminDashboard");
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}