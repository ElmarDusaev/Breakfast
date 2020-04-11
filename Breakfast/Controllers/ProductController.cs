using Breakfast.Models;
using Breakfast.Utils;
using Breakfast.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Controllers
{
    [Authorize]
    public class ProductController:Controller
    {
        BreakfastDbContext context;

        public ProductController(BreakfastDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Products.Include(a=>a.Category).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ProductsList()
        {
            var client = Request.GetClient(context);
            var categories = context.Categories.ToList();
            categories.Insert(0, new Category { Id = 0, Name = "Все" });
            var products = (from p in context.Products
                           where p.Status == ProductStatus.Active
                           select new ProductListViewModel
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Image = p.Image,
                               Price = p.Price,
                               CategoryId = p.CategoryId,
                               Stars = p.Stars,
                               InBasket = client == null ? 0 : (from b in context.Basket where b.ProductId == p.Id && b.ClientId == client.Id select b.Qty).FirstOrDefault()
                           }).ToList();



            return Json(new MainViewVodel { categories = categories, products = products });
        }
    }
}
