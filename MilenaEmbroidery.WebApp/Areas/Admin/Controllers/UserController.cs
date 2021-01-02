using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.General;
using MilenaEmbroidery.IServices.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDTO> users = Enumerable.Empty<UserDTO>();

            try
            {
                users = await _userService.Get();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return View(users);
        }

        public async Task<IActionResult> BasicForm(int? id)
        {
            UserDTO user = null;

            try
            {
                if (id == null)
                    return View();

                user = await _userService.Get((int)id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return View(user);
        }

        public async Task<IActionResult> Create(UserDTO user)
        {
            try
            {
                await _userService.Create(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(UserDTO user)
        {
            try
            {
                await _userService.Update(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            UserDTO user = null;

            try
            {
                user = await _userService.Get(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return View(user);
        }

        /*
        public async Task<IActionResult> Delete(int id)
        {
            bool check = false;

            try
            {
                check = await _userService.CheckIfExists(id);

                if (!check)
                    throw new Exception("User not found");

                await _userService.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
        }
        */
    }
}
