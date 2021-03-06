﻿using System;
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
        public ActionResult ZapiszWizytaLekarz(int? id)
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

        [HttpGet]
        public ActionResult ZapiszWizytaBadanie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WizytaBadanie wizytaBadanie = db.WizytaBadanie.Find(id);
            if (wizytaBadanie == null)
            {
                return HttpNotFound();
            }

            Session["BadanieId"] = wizytaBadanie.Badanie.BadanieId;
            Session["WizytaBadanieId"] = wizytaBadanie.WizytaBadanieId;
            Session["DataBadania"] = wizytaBadanie.DataBadanie;
            Session["GodzinaBadania"] = wizytaBadanie.GodzinaBadanie;

            ViewBag.BadanieId = new SelectList(db.Badanie, "BadanieId", "Nazwa", wizytaBadanie.Badanie.BadanieId);

            return View(wizytaBadanie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ZapiszWizytaLekarz(WizytaLekarz wizytaLekarz)
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
                return RedirectToAction("DostepneWizytaLekarz");
            }
            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }

        [HttpGet]
        public ActionResult UsunWizytaLekarz(int? id)
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
        public ActionResult UsunWizytaLekarz(WizytaLekarz wizytaLekarz)
        {
            if (ModelState.IsValid)
            {
                wizytaLekarz.LekarzId = (int)Session["LekarzId"];
                wizytaLekarz.SpecjalizacjaId = (int)Session["SpecjalizacjaId"];
                wizytaLekarz.PacjenId = null;
                wizytaLekarz.GodzinaWizyty = (TimeSpan)Session["GodzinaWizyty"];
                wizytaLekarz.DataWizyty = (DateTime)Session["DataWizyty"];


                wizytaLekarz.Status = false;


                db.Entry(wizytaLekarz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HistoriaWizytaLekarz");
            }
            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }
        public ActionResult DostepneWizytaBadanie()
        {
            var wizytaBadanie = (from wb in db.WizytaBadanie
                                where wb.Status == false
                                select wb).ToList();
            return View(wizytaBadanie);
        }

       [HttpGet]
        public ActionResult UsunWizytaBadanie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WizytaBadanie wizytaBadanie = db.WizytaBadanie.Find(id);
            if (wizytaBadanie == null)
            {
                return HttpNotFound();
            }

            Session["BadanieId"] = wizytaBadanie.BadanieId;
            Session["WizytaBadanieId"] = wizytaBadanie.WizytaBadanieId;
            Session["DataBadania"] = wizytaBadanie.DataBadanie;
            Session["GodzinaBadania"] = wizytaBadanie.GodzinaBadanie;


            ViewBag.BadanieId = new SelectList(db.Badanie, "BadanieId", "Nazwa", wizytaBadanie.BadanieId);
            return View(wizytaBadanie);
        }

       [HttpPost]
       public ActionResult UsunWizytaBadanie(WizytaBadanie wizytaBadanie)
       {
           if (ModelState.IsValid)
           {
               wizytaBadanie.BadanieId = (int)Session["BadanieId"];
               wizytaBadanie.PacjentId = null;
               wizytaBadanie.GodzinaBadanie = (TimeSpan)Session["GodzinaBadania"];
               wizytaBadanie.DataBadanie = (DateTime)Session["DataBadania"];


               wizytaBadanie.Status = false;


               db.Entry(wizytaBadanie).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("HistoriaWizytaBadanie");
           }
           ViewBag.BadanieId = new SelectList(db.Badanie, "BadanieId", "Nazwa", wizytaBadanie.BadanieId);
           return View(wizytaBadanie);
       }


       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult ZapiszWizytaBadanie(WizytaBadanie wizytaBadanie)
       {
           if (ModelState.IsValid)
           {
               wizytaBadanie.BadanieId = (int)Session["BadanieId"];
               wizytaBadanie.PacjentId = (int)Session["PacjentId"];
               wizytaBadanie.GodzinaBadanie = (TimeSpan)Session["GodzinaBadania"];
               wizytaBadanie.DataBadanie = (DateTime)Session["DataBadania"];


               wizytaBadanie.Status = true;


               db.Entry(wizytaBadanie).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("DostepneWizytaBadanie");
           }
           ViewBag.BadanieId = new SelectList(db.Badanie, "BadanieId", "Nazwa", wizytaBadanie.BadanieId);
           return View(wizytaBadanie);
       }


        public ActionResult Zalogowany()
        {
            return View();
        }

        public ActionResult HistoriaWizytaLekarz()
        {
            int id = (Int32)Session["PacjentId"];
            var wizytaLekarz = (from wl in db.WizytaLekarz
                                where wl.PacjenId == id
                                select wl).ToList();
            return View(wizytaLekarz);
        }

        public ActionResult HistoriaWizytaBadanie()
        {
            int id = (Int32)Session["PacjentId"];
            var wizytaBadanie = (from wb in db.WizytaBadanie
                                 where wb.PacjentId == id
                                 select wb).ToList();
            return View(wizytaBadanie);
        }
    }
}