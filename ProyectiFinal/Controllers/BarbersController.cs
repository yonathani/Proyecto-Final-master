using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectiFinal.Models;
using System.IO;

namespace ProyectiFinal.Controllers
{
    public class BarbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Barbers
        public ActionResult Index()
        {
            return View(db.Barbers.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Img"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }



        // GET: Barbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // GET: Barbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barbers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,ImagenUrl,Description,Horary,Phone")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                db.Barbers.Add(barber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barber);
        }

        // GET: Barbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,ImagenUrl,Description,Horary,Phone")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barber);
        }

        // GET: Barbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barber barber = db.Barbers.Find(id);
            db.Barbers.Remove(barber);
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
