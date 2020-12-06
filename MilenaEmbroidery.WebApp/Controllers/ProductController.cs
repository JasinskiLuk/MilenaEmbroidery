using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using MilenaEmbroidery.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderListService _orderListService;

        public ProductController(IProductService productService, IOrderService orderService, IOrderListService orderListService)
        {
            _productService = productService;
            _orderService = orderService;
            _orderListService = orderListService;
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

        public async Task<IActionResult> AddOrder(ProductDTO product)
        {
            OrderDTO order = null;

            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");

                if (userId == null)
                    return RedirectToAction("LoginForm", "User");

                order = await _orderService.Get((int)userId);

                if (order is NullOrderDTO)
                {
                    order = new OrderDTO
                    {
                        UserId = (int)userId,
                        OrderStatusId = 1
                    };

                    order.Id = await _orderService.Create(order);
                }

                OrderListDTO orderList = new OrderListDTO
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = 1
                };

                int orderListId = await _orderListService.Create(orderList);

                HttpContext.Session.SetInt32("OrderListId", orderListId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

            return RedirectToAction("Index");
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
