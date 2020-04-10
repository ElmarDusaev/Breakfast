using Breakfast.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Utils;
using Microsoft.AspNetCore.Authorization;
using Breakfast.ViewModels;

namespace Breakfast.Controllers
{
    /// <summary>
    /// API для заказа
    /// </summary>
    public class OrderController: Controller
    {
        BreakfastDbContext context;

        public OrderController(BreakfastDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Создать заказ
        /// переносится с корзины все позиции товаров клиента
        /// формируется заказ
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] OrderInformation orderInformation)
        {

            if (!ModelState.IsValid) return BadRequest();


            var client = Request.GetClient(context);
            var basket = (from i in context.Basket where i.ClientId == client.Id select new OrderDtl { Price = i.Price, Product = i.Product, Qty = i.Qty, Status = OrderDtlStatus.Wait }).ToList();

            //Todo: нужно подключить Automapper
            OrderHdr orderHdr = new OrderHdr();
            orderHdr.Client = client;
            orderHdr.CreatedDate = DateTime.Now;
            orderHdr.Status = OrderHdrStatus.Requested;
            orderHdr.ClientName = orderInformation.ClientName;
            orderHdr.Phone = orderInformation.Phone;
            orderHdr.Address = orderInformation.Address;
            orderHdr.Latitude = orderInformation.Latitude;
            orderHdr.Longtitude = orderInformation.Longtitude;
            orderHdr.Sum = basket.Sum(a => a.Price*a.Qty);
            orderHdr.DeliveryDateTime = orderInformation.DeliveryDateTime.LocalDateTime;
            orderHdr.OrderDtls = basket;

            context.OrderHdrs.Add(orderHdr);

            context.Basket.RemoveRange(context.Basket.Where(a => a.ClientId == client.Id));

            context.SaveChanges();

            return Json(new { OrderID = orderHdr.Id, ClientName = orderHdr.ClientName, Sum = orderHdr.Sum, Address = orderHdr.Address, Vishes = "Приятного аппетита!!!"});
        }


        [Authorize]
        public IActionResult Index()
        {
            var orders = from i in context.OrderHdrs.ToList()
                         orderby i.DeliveryDateTime descending
                         group i by i.DeliveryDateTime.ToString("dd-MM-yyyy") into g
                         select new OrderViewModel { Date = g.Key, OrderHdrs = g.Select(a => a).ToList() };
            return View(orders);
        }


    }
}
