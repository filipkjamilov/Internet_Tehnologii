using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneApp.Models
{
    public class smartPhonesDb : DbContext
    {
        public smartPhonesDb() : base("name=DefaultConnection")
        {

        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}