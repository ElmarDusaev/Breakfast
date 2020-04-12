using Breakfast.Models;
using Breakfast.Utils;
using Breakfast.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categories = from i in context.Categories
                                 select new SelectListItem
                                 {
                                     Value = i.Id.ToString(),
                                     Text = i.Name
                                 };

            ViewBag.Status = from i in Enum.GetValues(typeof(ProductStatus)).Cast<ProductStatus>()
                             select new SelectListItem
                             {
                                 Value = ((int)i).ToString(),
                                 Text = i.GetDescription()
                             };

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {

            if (!ModelState.IsValid) return BadRequest();

            context.Products.Add(product);
            context.SaveChanges();

            return Ok();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var product = context.Products.Where(a => a.Id == id).Select(a => a).FirstOrDefault();
            if (product == null) NotFound();

            ViewBag.Categories = from i in context.Categories
                                 select new SelectListItem
                                 {
                                     Value = i.Id.ToString(),
                                     Text = i.Name
                                 };

            ViewBag.Status = from i in Enum.GetValues(typeof(ProductStatus)).Cast<ProductStatus>()
                             select new SelectListItem
                             {
                                 Value = ((int)i).ToString(),
                                 Text = i.GetDescription()
                             };

            return View(product);
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
