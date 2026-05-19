using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    public class DashboardController : Controller
    {
        UserService userService;

        public DashboardController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

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