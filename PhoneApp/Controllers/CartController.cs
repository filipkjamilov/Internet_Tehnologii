using PhoneApp.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneApp.Controllers
{
    public class CartController : Controller
    {


        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(ChargeDTO chargeDTO)
        {
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_qtxcZhc7axpT1Rsh1jIaanrq00gJmUHsE1";
            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            //var token = model.Token; // Using ASP.NET MVC
            var customerOptions = new CustomerCreateOptions
            {
                Description = chargeDTO.name,
                Name = chargeDTO.name,
                Source = chargeDTO.stripeToken,
                Email = chargeDTO.email,
                Metadata = new Dictionary<string, string>()
                {
                    { "Phone Number", chargeDTO.phone },
                    { "Street", chargeDTO.street }
                }
            };
            var customerService = new CustomerService();
            Customer customer = customerService.Create(customerOptions);


            var options = new ChargeCreateOptions
            {
                Amount = chargeDTO.price * 100,
                Currency = "eur",
                Description = "Charge for " + customer.Email,
                //Source = chargeDTO.stripeToken,
                Customer = customer.Id
            };
                                                  
            var service = new ChargeService();
            Charge charge = service.Create(options);

            var model = new ChargeViewModel();
            model.ChargeId = charge.Id;
            Session["userPhones"] = null;

            return View("OrderStatus", model);


        }


    }
}
