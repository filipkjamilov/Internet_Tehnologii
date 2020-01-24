using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneApp.Models
{
    public class Comment
    {
        public int id { get; set; }

        public String email { get; set; }
       
        public String text { get; set; }

        public virtual Phone phone { get; set; }

    }
}