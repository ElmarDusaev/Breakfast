using Breakfast.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Controllers
{
    [Authorize]
    public class ProductController:Controller
    {
        BreakfastDbContext dbContext;

        public ProductController(BreakfastDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Products);
        }
    }
}
