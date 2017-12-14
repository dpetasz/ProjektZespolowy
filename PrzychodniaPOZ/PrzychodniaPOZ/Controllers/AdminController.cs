﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrzychodniaPOZ.DAL;
using PrzychodniaPOZ.Models;
using System.Net;

namespace PrzychodniaPOZ.Controllers
{
    public class AdminController : Controller
    {
        private PrzychodniaContext db = new PrzychodniaContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logowanie()
        {
            Pracownik model = new Pracownik();
            return View(model);
        }
        [HttpPost]
        public ActionResult Logowanie(Pracownik model)
        {
            using (PrzychodniaContext db = new PrzychodniaContext())
            {
                var pracownikDetal = db.Pracownik.FirstOrDefault(x => x.Login == model.Login && x.Haslo == model.Haslo);
                if (pracownikDetal == null)
                {
                    ViewBag.DuplicateMessage = "Zły email lub hasło";
                    return View("Logowanie", model);
                }
                else
                {
                    Session["PracownikId"] = pracownikDetal.PracownikId;
                    Session["Name"] = pracownikDetal.Imie + " " + pracownikDetal.Nazwisko;
                    return RedirectToAction("Index", "Admin");
                }
            }
        }




        public ActionResult Wyloguj()
        {
            int user = (int)Session["PracownikID"];
            Session.Abandon();
            return RedirectToAction("Logowanie", "Admin");
        }


        //Wyswietla listę specjalizacji w layoutdostepnewizlekarz
        public ActionResult ListaWizytaLekarzMenu()
        {

            return View();
        }

        public ActionResult SpecjalizacjaLista()
        {
            var specjalizacja = db.Specjalizacja.ToList();
            return PartialView("_DostepneWizLekSpecjalizacjaLista", specjalizacja);
        }

        public ActionResult DostepneWizytyLekarzLista(int? id)
        {
            return View();
        }
        //


        public ActionResult DodajWizytaLekarzMenu()
        {

            return View();
        }

        public ActionResult DodajWizytaBadanieMenu()
        {

            return View();
        }

        public ActionResult DodajWizytaBadaniaListaMenu()
        {
            var badania = db.Badanie.ToList();
            return PartialView("_DodajWizytaBadaniaListaMenu", badania);
        }

        [ChildActionOnly]
        public ActionResult BadaniaMenu()
        {
            var badania = db.Badanie.ToList();
            return PartialView("_BadaniaMenu", badania);
        }

        //Widok dla dostępnych wizyt na badania z layautDostepneWizytaBadanie
        public ActionResult DostepneWizytaBadaniaMenu()
        {
            return View();
        }
        public ActionResult _BadaniaLista()
        {
            var badania = db.Badanie.ToList();
            return PartialView("_BadaniaLista", badania);
        }

        public ActionResult _WizytaLekarzLista()
        {
            var specjalizacja = db.Specjalizacja.ToList();
            return PartialView("_DodajWizytaLekarzLista", specjalizacja);
        }

        [HttpGet]
        public ActionResult DodajWizytaBadanie(int? idBadanie)
        {

            Session["idBad"] = idBadanie;

            return View();
        }


        [HttpPost]
        public ActionResult DodajWizytaBadanie(WizytaBadanie wizytaBadanie)
        {
            if (ModelState.IsValid)
            {
                wizytaBadanie.PacjentId = null;
                wizytaBadanie.BadanieId = (Int32)Session["idBad"];
                wizytaBadanie.Status = false;
                db.WizytaBadanie.Add(wizytaBadanie);
                db.SaveChanges();
                return RedirectToAction("DostepneWizytaBadaniaMenu");
            }

            return View(wizytaBadanie);
        }

        public ActionResult DostepneWizytaBadanie(int? idBadanie)
        {
            if (idBadanie == null)
            {
                return HttpNotFound();
            }
            //var wizytaLekarz = db.WizytaLekarz.Include(w => w.Lekarz);
            var wizytaBadanie = (from wb in db.WizytaBadanie
                                 where wb.BadanieId == idBadanie
                                 select wb).ToList();
            return View(wizytaBadanie);
        }

        // GET: WizytaLekarz/DodajWizytaLekarz
        [HttpGet]
        public ActionResult DodajWizytaLekarz(int? id)
        {
            Session["idspec"] = id;
            var lekarzWidok = (from l in db.Lekarz
                               join ls in db.LekSpec on l.LekarzId equals ls.LekarzId
                               where ls.SpecjalizacjaId == id
                               select l
                               ).ToList();
            SelectList lista = new SelectList(lekarzWidok, "LekarzId", "Nazwisko");

            //ViewBag.LekarzListaNazwisko = lista;

            ViewBag.LekarzId = new SelectList(lekarzWidok, "LekarzId", "Nazwisko");
            //ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa");
            return View();
        }

        // POST: WizytaLekarz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajWizytaLekarz([Bind(Include = "WizytaLekarzId,LekarzId,SpecjalizacjaId,PacjenId,DataWizyty,GodzinaWizyty,Status")] WizytaLekarz wizytaLekarz)
        {
            if (ModelState.IsValid)
            {
                wizytaLekarz.PacjenId = null;
                wizytaLekarz.SpecjalizacjaId = (Int32)Session["idspec"];
                wizytaLekarz.Status = false;
                db.WizytaLekarz.Add(wizytaLekarz);
                db.SaveChanges();
                return RedirectToAction("DostepneWizytaLekarz");
            }

            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);
            return View(wizytaLekarz);
        }
        public ActionResult DostepneWizytaLekarz(int? id)
        {
            //var wizytaLekarz = db.WizytaLekarz.Include(w => w.Lekarz);
            var wizytaLekarz = (from wl in db.WizytaLekarz
                                where wl.SpecjalizacjaId == id
                                orderby wl.DataWizyty
                                select wl).ToList();
            return View(wizytaLekarz);
        }

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
            return RedirectToAction("DostepneWizytaLekarz");
        }

    }
}