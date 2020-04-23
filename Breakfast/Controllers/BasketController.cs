using Breakfast.Models;
using Breakfast.Utils;
using Breakfast.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Controllers
{
    /// <summary>
    /// API для корзины
    /// </summary>
    public class BasketController:Controller
    {
        BreakfastDbContext context;

        public BasketController(BreakfastDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Корзина клиента
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        {
            var client = Request.GetClient(context);
            var basket = from b in context.Basket where b.ClientId == client.Id
                            from p in context.Products where p.Id == b.ProductId
                                select new BasketViewModel {
                                Id = b.Id,
                                ProductId = b.ProductId,
                                Name = p.Name,
                                Price = p.Price,
                                Qty = b.Qty
                                };
            return Json(basket);
        }


        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody]int? id)
        {
            if (id == null) return BadRequest();
            
            var client = Request.GetClient(context);
            if (client == null) return BadRequest();

            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            var inBasket = (from i in context.Basket where i.ClientId == client.Id && i.ProductId == id select i).FirstOrDefault();
            if (inBasket != null)
                inBasket.Qty++;
            else
            {
                inBasket = new OrderBasket { Price = product.Price, ProductId = product.Id, ClientId = client.Id, Qty = 1 };
                context.Basket.Add(inBasket);
            }

            context.SaveChanges();
            var totalInBasket = (from i in context.Basket where i.ClientId == client.Id select i).Count();
            return Json(new { inBasket = inBasket.Qty, totalInBasket });
        }

        [HttpPost]
        public IActionResult Increase([FromBody]int? id)
        {
            var client = Request.GetClient(context);
            if (client == null) return BadRequest();
            var product = context.Basket.FirstOrDefault(a => a.Id == id && a.ClientId == client.Id);
            if (product == null) return NotFound(); ;
            product.Qty++;
            context.SaveChanges();
            return Json(product.Qty);
        }

        [HttpPost]
        public IActionResult Decrease([FromBody]int? id)
        {
            var client = Request.GetClient(context);
            if (client == null) return BadRequest();
            var product = context.Basket.FirstOrDefault(a => a.Id == id && a.ClientId == client.Id);
            if (product == null) return BadRequest();
            if (product.Qty == 1) return NotFound(); ;
            product.Qty--;
            context.SaveChanges();
            return Json(product.Qty);
        }

        [HttpPost]
        public IActionResult Remove([FromBody] int? id)
        {
            var client = Request.GetClient(context);
            if (client == null) return BadRequest();
            var product = context.Basket.FirstOrDefault(a => a.Id == id && a.ClientId == client.Id);
            if(product == null) return NotFound();
            context.Basket.Remove(product);
            context.SaveChanges();
            return Json(true);
        }
    }
}
