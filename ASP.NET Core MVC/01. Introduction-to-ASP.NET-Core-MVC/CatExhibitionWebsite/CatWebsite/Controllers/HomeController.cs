using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatWebsite.Data;
using CatWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatWebsite.Controllers
{
    public class HomeController : Controller
    {
        private CatDbContext catDbContext;

        public HomeController(CatDbContext catDbContext)
        {
            this.catDbContext = catDbContext;
        }

        public IActionResult Index()
        {
            var cats = this.catDbContext
                .Cats
                .Select(c => new CatListViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArray();

            return View(cats);
        }
    }
}