using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneApp.Models
{
    public class ChargeDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public long price { get; set; }
        public string street { get; set; }
        public string stripeToken { get; set; }
    }
}