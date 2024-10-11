using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCookie(string value, DateTime expireDate)
        {
            var options = new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = expireDate
            };

            Response.Cookies.Append("UserValue", value, options);

            return Ok("Cookies were added");
        }

        public IActionResult CheckCookie()
        {
            string cookieValue = Request.Cookies["UserValue"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                return Ok("Cookie value: " + cookieValue);
            }
            else
            {
                throw new Exception("Cookie not found");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
