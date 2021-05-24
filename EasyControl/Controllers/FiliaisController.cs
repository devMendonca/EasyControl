using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyControl.Data;
using EasyControl.Models;

namespace EasyControl.Controllers
{
    public class FiliaisController : Controller
    {
        private EasyControlContext db = new EasyControlContext();

        

        // GET: Filiais
        public ActionResult Index()
        {
            return View(db.Filials.ToList());
        }
        

        // GET: Filiais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.Filials.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }
       
        // GET: Filiais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filiais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilialId,Nome,Estado")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                db.Filials.Add(filial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filial);
        }
        

        // GET: Filiais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.Filials.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }

        // POST: Filiais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilialId,Nome,Estado")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filial);
        }
       

        // GET: Filiais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.Filials.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }
    

        // POST: Filiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filial filial = db.Filials.Find(id);
            db.Filials.Remove(filial);
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
