using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.General;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.General;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public object Session { get; private set; }

        public UserController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        public async Task<IActionResult> UserForm()
        {
            UserDTO user = null;

            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");

                if (userId == null)
                    throw new Exception("USerId is null! Cannot get data.");

                user = await _userService.Get((int)userId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return View(user);
        }

        public async Task<IActionResult> Login(UserDTO user)
        {
            int loggedUserId = -1;
            OrderDTO order = null;

            try
            {
                loggedUserId = await _userService.Login(user.FirstName, user.LastName);

                if (loggedUserId < 1)
                    throw new Exception("Login Failed. Data not found.");

                order = await _orderService.Get(loggedUserId);

                HttpContext.Session.SetInt32("UserId", loggedUserId);
                HttpContext.Session.SetString("Login", user.FirstName);
                HttpContext.Session.SetInt32("OrderId", order.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
