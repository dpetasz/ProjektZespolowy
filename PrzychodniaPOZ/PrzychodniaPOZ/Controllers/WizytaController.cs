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
using PrzychodniaPOZ.ViewModel;

namespace PrzychodniaPOZ.Controllers
{
    public class WizytaController : Controller
    {
        PrzychodniaContext db = new PrzychodniaContext();
        // GET: Wizyta
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult DostepneWizytaLekarz()
        {
            //var wizytaLekarz = db.WizytaLekarz.Include(w => w.Lekarz);
            var wizytaLekarz = (from wl in db.WizytaLekarz
                                where wl.Status == false
                                select wl).ToList();
            return View(wizytaLekarz);
        }

        [HttpGet]
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

            Session["LekarzId"] = wizytaLekarz.LekarzId;
            Session["WizytaLekarzId"] = wizytaLekarz.WizytaLekarzId;
            Session["SpecjalizacjaId"] = wizytaLekarz.SpecjalizacjaId;
            Session["DataWizyty"] = wizytaLekarz.DataWizyty;
            Session["GodzinaWizyty"] = wizytaLekarz.GodzinaWizyty;


            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WizytaLekarz wizytaLekarz)
        {
            if (ModelState.IsValid)
            {
                wizytaLekarz.LekarzId = (int)Session["LekarzId"];
                wizytaLekarz.SpecjalizacjaId = (int)Session["SpecjalizacjaId"];
                wizytaLekarz.PacjenId = (int)Session["PacjentId"];
                wizytaLekarz.GodzinaWizyty = (TimeSpan)Session["GodzinaWizyty"];
                wizytaLekarz.DataWizyty = (DateTime)Session["DataWizyty"];


                wizytaLekarz.Status = true;


                db.Entry(wizytaLekarz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }

        public ActionResult DostepneBadania()
        {
            return Json(new { foo = "bar", baz = "Blech" });
        }

        public ActionResult ZapiszWizytaLekarz()
        {
            return View();
        }

        public ActionResult UsunWizytaLekarz()
        {
            return View();
        }

        public ActionResult ZapiszBadanie()
        {
            return View();
        }

        public ActionResult UsunBadanie()
        {
            return View();
        }

        public ActionResult Zalogowany()
        {
            return View();
        }

        public ActionResult HistoriaWizytaLekarz()
        {
            return Json(new { foo = "bar", baz = "Blech" });
        }

        public ActionResult HistoriaBadanie()
        {
            return Json(new { foo = "bar", baz = "Blech" });
        }
    }
}