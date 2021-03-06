﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.WebApp.Areas.Shop.Controllers
{
    [Area("shop")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderListService _orderListService;

        public HomeController(IProductService productService, IOrderService orderService, IOrderListService orderListService)
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
            IEnumerable<OrderListDTO> ordersList = Enumerable.Empty<OrderListDTO>();

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

                ordersList = await _orderListService.GetByOrderId(order.Id);

                if (!ordersList.Any())
                {
                    OrderListDTO orderList = new OrderListDTO
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = 1
                    };

                    await _orderListService.Create(orderList);
                }
                else
                {
                    foreach (var item in ordersList)
                        if (item.ProductId == product.Id)
                        {
                            item.Quantity++;
                            await _orderListService.Update(item);
                        }
                        else
                            await _orderListService.Create(item);
                }

                HttpContext.Session.SetInt32("OrderId", order.Id);
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
    }
}
