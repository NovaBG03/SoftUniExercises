using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Domain
{
    public class PandaUser : IdentityUser<string>
    {
        public PandaUser()
        {
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
