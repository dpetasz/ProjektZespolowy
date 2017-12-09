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
    }
}