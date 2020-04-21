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
    [Authorize]
    public class OrderController : Controller
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
        [AllowAnonymous]
        public IActionResult Create([FromBody] OrderInformation orderInformation)
        {

            if (!ModelState.IsValid) return BadRequest();


            var client = Request.GetClient(context);
            var basket = (from i in context.Basket where i.ClientId == client.Id select new OrderDtl { Price = i.Price, Product = i.Product, Qty = i.Qty, Status = OrderDtlStatus.Wait }).ToList();

            if (basket.Count == 0) return BadRequest();

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
            orderHdr.Sum = basket.Sum(a => a.Price * a.Qty);
            orderHdr.DeliveryDateTime = orderInformation.DeliveryDateTime.LocalDateTime;
            orderHdr.OrderDtls = basket;

            context.OrderHdrs.Add(orderHdr);

            context.Basket.RemoveRange(context.Basket.Where(a => a.ClientId == client.Id));

            context.SaveChanges();

            return Json(new { orderID = orderHdr.Id, clientName = orderHdr.ClientName, sum = orderHdr.Sum, address = orderHdr.Address, orderDate = orderHdr.DeliveryDateTime.ToString("dd-MM-yyyy"), orderTime = orderHdr.DeliveryDateTime.ToString("hh:mm") });
        }



        public IActionResult Index(bool all)
        {
            ViewBag.AllOrders = !all;
            IEnumerable<OrderViewModel> orders = null;
            if (all)
            {
                orders = from i in context.OrderHdrs.ToList()
                         orderby i.DeliveryDateTime descending
                         group i by i.DeliveryDateTime.ToString("dd-MM-yyyy") into g
                         select new OrderViewModel { Date = g.Key, OrderHdrs = g.OrderBy(a => a.DeliveryDateTime).Select(a => a).ToList() };
            }
            else
            {
                orders = from i in context.OrderHdrs.ToList()
                          where i.DeliveryDateTime.ToShortDateString() == DateTime.Now.ToShortDateString()
                          orderby i.DeliveryDateTime descending
                          group i by i.DeliveryDateTime.ToString("dd-MM-yyyy") into g
                          select new OrderViewModel { Date = g.Key, OrderHdrs = g.OrderBy(a => a.DeliveryDateTime).Select(a => a).ToList() };
            }

            return View(orders);
        }


        [HttpGet]
        public IActionResult Info(int? id)
        {
            var products = from i in context.OrderDtls
                           where i.OrderHdrId == id
                           join p in context.Products on i.ProductId equals p.Id
                           select new { i.Id, p.Name, i.Qty, i.Status };
            return Json(products);
        }

        [HttpPost]
        public IActionResult ChangeOrderDtlSatus([FromBody] int? id)
        {
            if (id == null) return BadRequest();

            var client = Request.GetClient(context);

            var result = (from d in context.OrderDtls where d.Id == id select d).FirstOrDefault();

            if (result == null) return NotFound();

            if (result.Status == OrderDtlStatus.Wait)
                result.Status = OrderDtlStatus.Done;
            else if(result.Status == OrderDtlStatus.Done)
                result.Status = OrderDtlStatus.Wait;


            var order = (from i in context.OrderHdrs where i.Id == result.OrderHdrId select i).FirstOrDefault();

            if (order == null) return NotFound();

            order.Status = OrderHdrStatus.InProgress;

            context.SaveChanges();
            return Ok(result.Status);
        }

        [HttpPost]
        public IActionResult ChangeOrderHdrStatus([FromBody] int? id)
        {

            if (id == null) return BadRequest();

            var CanClose = (from i in context.OrderDtls where i.OrderHdrId == id && i.Status == OrderDtlStatus.Wait select i).Count();
            if (CanClose > 0) return BadRequest();

            var order = (from i in context.OrderHdrs where i.Id == id select i).FirstOrDefault();

            if (order == null) return NotFound();

            order.Status = OrderHdrStatus.Done;
            context.SaveChanges();

            return Json("OK");
        }

        [HttpPost]
        public IActionResult CancelOrder([FromBody] int? id)
        {
            var order = (from i in context.OrderHdrs where i.Id == id select i).FirstOrDefault();

            if (order == null) return NotFound();

            order.Status = OrderHdrStatus.Rejected;
            context.SaveChanges();

            return Json("Ok");
        }
    }
}
