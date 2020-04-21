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

            var orders = context.OrderHdrs.Where(a=>a.DeliveryDateTime.Year == DateTime.Now.Year).ToList();
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


            var graphReport = from i in orders
                              orderby i.DeliveryDateTime
                              group i by i.DeliveryDateTime.Month into g
                              select new { labels = g.Key, data = g.Distinct().Count(), Month = (Months)g.Key};

            dashboard.MonthName = graphReport.Select(a => a.Month.ToString()).ToArray();
            dashboard.MonthValue = graphReport.Select(a => a.data).ToArray();


            var profits = from i in orders
                          group i by i.Status into g
                          select new { Status = g.Key.GetDescription(), Sum = g.Sum(a=>a.Sum)};

            dashboard.PipeStatus = profits.Select(a => a.Status).ToArray();
            dashboard.PipeSum = profits.Select(a => a.Sum).ToArray();


            return View(dashboard);
        }


    }



}