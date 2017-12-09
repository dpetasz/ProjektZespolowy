using PrzychodniaPOZ.DAL;
using PrzychodniaPOZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrzychodniaPOZ.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            PrzychodniaContext db = new PrzychodniaContext();
            var list = db.Lekarz.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Logowanie()
        {
            Pacjent model = new Pacjent();
            return View(model);
        }
        [HttpPost]
        public ActionResult Logowanie(Pacjent model)
        {
            using (PrzychodniaContext db = new PrzychodniaContext())
            {
                var pacjentDetal = db.Pacjent.FirstOrDefault(x => x.Email == model.Email && x.Haslo == model.Haslo);
                if (pacjentDetal == null)
                {
                    ViewBag.DuplicateMessage = "Zły email lub hasło";
                    return View("Logowanie", model);
                }
                else
                {
                    Session["PacjentId"] = pacjentDetal.PacjentId;
                    Session["Name"] = pacjentDetal.Imie + " " + pacjentDetal.Nazwisko;
                    return RedirectToAction("Index", "Wizyta");
                }
            }

        }

        [HttpGet]
        public ActionResult Rejestracja(int id = 0)
        {
            Pacjent model = new Pacjent();
            return View(model);
        }

        [HttpPost]
        public ActionResult Rejestracja(Pacjent model)
        {
            using (PrzychodniaContext db = new PrzychodniaContext())
            {
                if (db.Pacjent.Any(x => x.Email == model.Email))
                {
                    ViewBag.DuplicateMessage = "Taki email jest zarejestrowany";
                    return View("Rejestracja", model);
                }
                else
                {
                    db.Pacjent.Add(model);
                    db.SaveChanges();
                    var pacjentDetal = db.Pacjent.Where(x => x.Email == model.Email && x.Haslo == model.Haslo).FirstOrDefault();
                    if (pacjentDetal == null)
                    {
                        ViewBag.DuplicateMessage = "Zły email lub hasło";
                        return View("Logowanie", model);
                    }
                    else
                    {
                        Session["PacjentId"] = pacjentDetal.PacjentId;
                        Session["Name"] = pacjentDetal.Imie + " " + pacjentDetal.Nazwisko;
                        
                    }
                    
                }

            }

            
            ModelState.Clear();

            return RedirectToAction("Index", "Wizyta");
        }

        public ActionResult Wyloguj()
        {
            int user = (int)Session["PacjentID"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}