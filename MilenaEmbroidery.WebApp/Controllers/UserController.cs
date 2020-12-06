using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.General;
using MilenaEmbroidery.IServices.General;
using System;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public object Session { get; private set; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        public async Task<IActionResult> Login(UserDTO user)
        {
            try
            {
                HttpContext.Session.SetInt32("UserId", 2);
                HttpContext.Session.SetString("Login", user.FirstName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
