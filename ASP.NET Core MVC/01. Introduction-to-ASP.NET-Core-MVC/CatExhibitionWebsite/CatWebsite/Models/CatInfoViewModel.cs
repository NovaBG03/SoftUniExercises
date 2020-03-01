using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CatWebsite.Models
{
    public class CatInfoViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string ImageUrl { get; set; }
    }
}
