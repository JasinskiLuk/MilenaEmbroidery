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

        public async Task<IActionResult> BasicForm(int? id)
        {
            ProductDTO product = null;

            try
            {
                if (id == null)
                    return View();

                product = await _productService.Get((int)id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return View(product);
        }

        public async Task<IActionResult> Create(ProductDTO product)
        {
            try
            {
                await _productService.Create(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(ProductDTO product)
        {
            try
            {
                await _productService.Update(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool check = false;

            try
            {
                check = await _productService.CheckIfExists(id);

                if (!check)
                    throw new Exception("Product not found");

                await _productService.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
        }
    }
}
