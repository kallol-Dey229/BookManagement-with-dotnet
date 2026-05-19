using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    public class UserController : Controller
    {
        UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }

        

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserDTO dto)
        {
           
            if (ModelState.IsValid)
            {
                var result = service.Register(dto);

                if (result)
                {
                    return RedirectToAction("Login");
                }
            }

            return View(dto);
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public IActionResult Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                var user = service.Login(dto.Email, dto.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("Role", user.Role);
                    HttpContext.Session.SetString("Name", user.Name);

                    if (user.Role == "Admin")
                    {
                        return RedirectToAction(
                            "AdminDashboard",
                            "Dashboard");
                    }

                    return RedirectToAction(
                        "UserDashboard",
                        "Dashboard");
                }

                ViewBag.Msg = "Invalid Email or Password";
            }

            return View(dto);
        }





        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Index",
                "Home");
        }
    }
}