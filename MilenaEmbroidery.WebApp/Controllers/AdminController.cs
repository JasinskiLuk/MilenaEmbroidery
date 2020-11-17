using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> products = Enumerable.Empty<ProductDTO>();

            try
            {
                products = await _productService.Get();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return View(products);
        }

        public IActionResult BasicForm()
        {
            return View();
        }
    }
}
