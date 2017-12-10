using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrzychodniaPOZ.DAL;
using PrzychodniaPOZ.Models;

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

        


        
        public ActionResult SpecjalizacjaMenu()
        {
            var specjalizacja = db.Specjalizacja.ToList();

            return View(specjalizacja);
        }

        

        // GET: WizytaLekarz/DodajWizytaLekarz
        [HttpGet]
        public ActionResult DodajWizytaLekarz(string id)
        {
            int idSpec = Convert.ToInt32(id);
            var wizyty =  (from wl in db.WizytaLekarz
                                where wl.SpecjalizacjaId == idSpec
                                select wl).ToList();

           
            
            /*ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko");
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa");*/
            return View(wizyty);
        }

        // POST: WizytaLekarz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajWizytaLekarz([Bind(Include = "WizytaLekarzId,LekarzId,SpecjalizacjaId,PacjenId,DataWizyty,GodzinaWizyty,Status")] WizytaLekarz wizytaLekarz)
        {
            /*if (ModelState.IsValid)
            {
                wizytaLekarz.Status = false;
                db.WizytaLekarz.Add(wizytaLekarz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LekarzId = new SelectList(db.Lekarz, "LekarzId", "Nazwisko", wizytaLekarz.LekarzId);
            ViewBag.SpecjalizacjaId = new SelectList(db.Specjalizacja, "SpecjalizacjaId", "Nazwa", wizytaLekarz.SpecjalizacjaId);*/
            return View(wizytaLekarz);
        }
    }
}