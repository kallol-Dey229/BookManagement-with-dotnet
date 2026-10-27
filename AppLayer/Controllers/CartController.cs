using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult AddToCart(int id)
        {
            string cart = HttpContext.Session.GetString("cart");

            if (cart == null)
            {
                cart = id.ToString();
            }
            else
            {
                cart += "," + id;
            }

            HttpContext.Session.SetString("cart", cart);

            TempData["msg"] = "Book added to cart successfully";

            return RedirectToAction("Index", "Book");
        }

        public IActionResult MyProducts()
        {
            return View();
        }
    }
}