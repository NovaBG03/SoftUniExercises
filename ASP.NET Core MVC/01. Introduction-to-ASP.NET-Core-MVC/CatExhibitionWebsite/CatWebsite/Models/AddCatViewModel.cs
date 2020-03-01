using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CatWebsite.Models
{
    public class AddCatViewModel
    {
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [DisplayName(nameof(Age))]
        public int Age { get; set; }

        [DisplayName(nameof(Breed))]
        public string Breed { get; set; }

        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }
    }
}
