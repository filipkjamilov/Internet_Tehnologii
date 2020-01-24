using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhoneApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        smartPhonesDb db = new smartPhonesDb();
        // GET: ShoppingCart
        public ActionResult Index(int id)
        {

            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            List<Phone> listId = new List<Phone>();

            if (Session["userPhones"] == null)
            {
                Debug.Print("Null e i se kreira nova");
                listId.Add(phone);
                Session["userPhones"] = listId;
                return RedirectToAction("Index", "Phones");
            }
            else
            {

                List<Phone> listPhones = Session["userPhones"] as List<Phone>;

                foreach (Phone p in listPhones.ToList())
                {
                    if (p.id == id)
                    {
                        Debug.WriteLine("Exists");
                        //return Content("<script language='javascript' type='text/javascript'>alert('Already in there! ');</script>");
                        TempData["error"] = "in";
                        return RedirectToAction("Details", "Phones", phone);
                        //return RedirectToAction("Details", "Phones");
                        //return base.View();

                    }
                }


                listId = Session["userPhones"] as List<Phone>;
                listId.Add(phone);
                Session["userPhones"] = listId;
                Debug.Print("Sesijata postoi i dodavame nov tel " + id);

                return RedirectToAction("Index", "Phones");


            }



        }

    public ActionResult showCart()
        {
            if (Session["userPhones"] == null)
            {
                return View();
            }
            else
            {

                ViewBag.total = 0;
                foreach(Phone p in Session["userPhones"] as IEnumerable<Phone>)
                {
                    var sto = (Int32)ViewBag.total;
                    ViewBag.total = p.price + ((Int32)ViewBag.total);

                }
                Session["total"] = (Int32)ViewBag.total;
                return View(Session["userPhones"]);
            }
           
        }
        public ActionResult deleteFromCart(int ID)
        {
                List<Phone> listId = Session["userPhones"] as List<Phone>;

                Phone phone = db.Phones.Find(ID);
                Debug.Print("Ne nosi vo else znaci brisime tel " + phone.name);

                listId.Remove(phone);
                var st = listId.Find(i => i.id==ID);
                listId.Remove(st);

            ViewBag.total = ((Int32)Session["total"]) - phone.price;
            

            return listId.Count == 0 ? View("showCart", Session["userPhones"]=null) : View("showCart", Session["userPhones"] = listId);            

        }
        
    }
}
