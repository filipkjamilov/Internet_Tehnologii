using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneApp.Models;

namespace PhoneApp.Controllers
{
    public class PhonesController : Controller
    {
        private smartPhonesDb db = new smartPhonesDb();

        // GET: Phones

        public ActionResult Index()
        {
            //var model = db.Phones.ToList();
            var model = db.Phones.Include(r => r.manufacturer).ToList();

            return View(model);
        }

        // GET: Phones/Details/5
        public ActionResult Details(int? id)
        {
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"].ToString();

            }
            string ip = Request.UserHostAddress;
            //One like per user!
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Phone tel = db.Phones.Include(r => r.manufacturer).Where(r => r.id == id).First();
            //Phone tel = db.Phones.Find(id);
            if (tel == null)
            {
                return HttpNotFound();
            }
            

            return View(tel);
        }

        // GET: Phones/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = db.Manufacturers.ToList();
            ViewBag.manufacturers = model;


            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Phone phone)
        {
            
            Debug.WriteLine(phone.manufacturer.id);
            if (ModelState.IsValid)
            {
                Manufacturer man = db.Manufacturers.Find(phone.manufacturer.id);
                
                phone.manufacturer = man;

               db.Phones.Add(phone);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone);
        }

        // GET: Phones/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("handler","error");
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteComment(int? id, int phoneId)
        {
            
            Comment comment = db.Comments.Find(id);
            if (comment!=null)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
            }

            Phone phone = db.Phones.Find(phoneId);
            return RedirectToAction("Details", "Phones", phone);

        }

        // GET: Phones/Like/5
        [Authorize (Roles = "Admin, User")]
        [HttpPost]
        public ActionResult Like(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            phone.review = phone.review + 1;
            db.SaveChanges();

            return RedirectToAction("Details" , "Phones", phone);
        }


        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Comment(int? id, String comment, String user)
        {
            Debug.WriteLine("Adding new comment with txt: " + comment + ", and user: " + user);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);

            Comment c1 = new Comment { email = user, text = comment, phone = phone };
            db.Comments.Add(c1);
            db.SaveChanges();

            if (phone == null)
            {
                return HttpNotFound();
            }
            

            return RedirectToAction("Details", "Phones", phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "id,name,description,img,price,review")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone);
        }

        // GET: Phones/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Include(r => r.manufacturer).Where(r => r.id == id).First();
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
