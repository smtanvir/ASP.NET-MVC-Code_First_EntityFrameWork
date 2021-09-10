using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_EntityFramework.Models;

namespace ASP.NET_MVC_EntityFramework.Controllers
{
    [Authorize]
    public class PublishersController : Controller
    {
        private BookDbContext db = new BookDbContext();

        //Get Publishers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var data = db.Publishers.ToList();
            return View(data);
        }

        //Insert:Publishers
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return PartialView("_Success");
            }
            else
            {
                return PartialView("_Error");
            }
        }

        //Update:Publishers
        public ActionResult Edit(int? id)
        {
            var data = db.Publishers.First(p => p.Id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Publisher p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Publishers");
            }
            return View(p);
        }

        //Delete:Publishers
        public ActionResult Delete(int id)
        {
            var data = db.Publishers.First(p => p.Id == id);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var publisher = new Publisher { Id = id };
            db.Entry(publisher).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index", "Publishers");
        }
    }
}
