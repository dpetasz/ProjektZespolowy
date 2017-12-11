using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrzychodniaPOZ.DAL;
using PrzychodniaPOZ.Models;

namespace PrzychodniaPOZ.Controllers
{
    public class WizytaLekarzsController : Controller
    {
        private PrzychodniaContext db = new PrzychodniaContext();

        // GET: WizytaLekarzs
        public ActionResult Index()
        {
            var wizytaLekarz = db.WizytaLekarz.Include(w => w.Lekarz).Include(w => w.Specjalizacja);
            return View(wizytaLekarz.ToList());
        }

        // GET: WizytaLekarzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WizytaLekarz wizytaLekarz = db.WizytaLekarz.Find(id);
            if (wizytaLekarz == null)
            {
                return HttpNotFound();
            }
            return View(wizytaLekarz);
        }

        // GET: WizytaLekarzs/Create
        public ActionResult Create()
        {
            var lekarzWidok = (from l in db.Lekarz
                               join ls in db.LekSpec on l.LekarzId equals ls.LekarzId
                               where ls.SpecjalizacjaId == 1
                               select l).ToList();
            
            ViewBag.LekarzId = new SelectList(lekarzWidok, "LekarzId", "Nazwisko");
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa");
            return View();
        }

        // POST: WizytaLekarzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WizytaLekarzId,LekarzId,SpecjalizacjaId,PacjenId,DataWizyty,GodzinaWizyty,Status")] WizytaLekarz wizytaLekarz)
        {
            if (ModelState.IsValid)
            {
                db.WizytaLekarz.Add(wizytaLekarz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }

        // GET: WizytaLekarzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WizytaLekarz wizytaLekarz = db.WizytaLekarz.Find(id);
            if (wizytaLekarz == null)
            {
                return HttpNotFound();
            }
            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }

        // POST: WizytaLekarzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WizytaLekarzId,LekarzId,SpecjalizacjaId,PacjenId,DataWizyty,GodzinaWizyty,Status")] WizytaLekarz wizytaLekarz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wizytaLekarz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }

        // GET: WizytaLekarzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WizytaLekarz wizytaLekarz = db.WizytaLekarz.Find(id);
            if (wizytaLekarz == null)
            {
                return HttpNotFound();
            }
            return View(wizytaLekarz);
        }

        // POST: WizytaLekarzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WizytaLekarz wizytaLekarz = db.WizytaLekarz.Find(id);
            db.WizytaLekarz.Remove(wizytaLekarz);
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
