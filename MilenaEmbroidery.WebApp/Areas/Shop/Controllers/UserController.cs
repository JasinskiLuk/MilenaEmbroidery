using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.General;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.General;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Areas.Shop.Controllers
{
    [Area("shop")]
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
            UserDTO loggedUser = null;
            OrderDTO order = null;

            try
            {
                loggedUser = await _userService.Login(user.FirstName, user.LastName);

                if (loggedUser is NullUserDTO)
                    throw new Exception("Login Failed. Data not found.");

                order = await _orderService.Get(loggedUser.Id);

                HttpContext.Session.SetInt32("UserId", loggedUser.Id);
                HttpContext.Session.SetString("Login", loggedUser.FirstName);
                HttpContext.Session.SetInt32("OrderId", order.Id);
                HttpContext.Session.SetString("IsAdmin", loggedUser.IsAdmin.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
        }
    }
}
