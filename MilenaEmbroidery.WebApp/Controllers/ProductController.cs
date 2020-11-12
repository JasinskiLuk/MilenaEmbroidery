using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using MilenaEmbroidery.WebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get()
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

            return Json(products);
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
