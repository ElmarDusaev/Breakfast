using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Models;
using Breakfast.Utils;
using Breakfast.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Breakfast.controllers
{
    /// <summary>
    /// API главной страницы
    /// </summary>
    public class MainController : Controller
    {
        BreakfastDbContext context;

        public MainController(BreakfastDbContext context)
        {
            this.context = context;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            //var graphReport = from i in context.OrderHdrs where 
            var orders = context.OrderHdrs.ToList();
            var dashboard = new DashboardViewModel()
            {
                OrdersTotal = orders.Count(),
                OrdersToday = orders.Where(a => a.DeliveryDateTime.ToShortDateString() == DateTime.Now.ToShortDateString()).Count(),
                CompleteTotal = orders.Where(a => a.Status == OrderHdrStatus.Done).Count(),
                CompleteToday = orders.Where(a => a.DeliveryDateTime.ToShortDateString() == DateTime.Now.ToShortDateString() && a.Status == OrderHdrStatus.Done).Count(),
                DeliveryTotal = orders.Where(a => a.Status == OrderHdrStatus.Delivery).Count(),
                DeliveryToday = orders.Where(a => a.Status == OrderHdrStatus.Delivery && a.DeliveryDateTime.ToShortDateString() == DateTime.Now.ToShortDateString()).Count(),
                RejectedTotal = orders.Where(a => a.Status == OrderHdrStatus.Rejected).Count(),
                RejectedToday = orders.Where(a => a.Status == OrderHdrStatus.Rejected && a.DeliveryDateTime.ToShortDateString() == DateTime.Now.ToShortDateString()).Count()
            };

            return View(dashboard);
        }

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        {
            var client = Request.GetClient(context);
            var products = from p in context.Products where p.Status == ProductStatus.Active
                           select new MainViewVodel {
                               Id = p.Id,
                               Name = p.Name,
                               Image = p.Image,
                               Price = p.Price,
                               CategoryId = p.CategoryId,
                               Stars = p.Stars,
                               InBasket = (from b in context.Basket where b.ProductId == p.Id && b.ClientId == client.Id select b.Qty).FirstOrDefault()
                           };
            return Json(products.ToList());
        }
    }
}