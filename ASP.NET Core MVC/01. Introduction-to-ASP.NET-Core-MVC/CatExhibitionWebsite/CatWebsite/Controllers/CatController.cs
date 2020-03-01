using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatWebsite.Data;
using CatWebsite.Domain;
using CatWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatWebsite.Controllers
{
    public class CatController : Controller
    {
        private CatDbContext catDbContext;

        public CatController(CatDbContext catDbContext)
        {
            this.catDbContext = catDbContext;
        }

        public IActionResult Info(int catId)
        {
            var cat = this.catDbContext.Cats.Find(catId);

            var catViewModel = new CatInfoViewModel
            {
                Name = cat.Name,
                Age = cat.Age,
                Breed = cat.Breed,
                ImageUrl = cat.ImageUrl
            };

            return View(catViewModel);
        }

        public IActionResult Add(AddCatViewModel inputCat)
        {
            if (string.IsNullOrEmpty(inputCat.Name))
            {
                return View(inputCat);
            }

            var cat = new Cat
            {
                Name = inputCat.Name,
                Age = inputCat.Age,
                Breed = inputCat.Breed,
                ImageUrl = inputCat.ImageUrl
            };

            this.catDbContext.Cats.Add(cat);
            this.catDbContext.SaveChanges();

            return Redirect("/");
        }
    }
}