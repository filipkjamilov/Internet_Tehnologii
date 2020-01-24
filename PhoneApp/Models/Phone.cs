using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneApp.Models
{
    public class Phone
    {
        public int id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String img { get; set; }
        public int price { get; set; }
        public int review { get; set; }
        public Manufacturer manufacturer { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
        
    }
}