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
        // GET: Admin
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
                    Session["PacjentId"] = pracownikDetal.PracownikId;
                    Session["Name"] = pracownikDetal.Imie + " " + pracownikDetal.Nazwisko;
                    return RedirectToAction("Index", "Admin");
                }
            }
        }

        public ActionResult PokazWizytyLekarz()
        {
            return Json(new { foo = "bar", baz = "Blech" });
        }

        public ActionResult DodajWizyteLekarz()
        {
            return View();
        }

        public ActionResult EdytujWizyteLekarz()
        {
            return View();
        }

        public ActionResult UsunWizyteLekarz()
        {
            return View();
        }

        public ActionResult PokazBadanie()
        {
            return View();
        }

        public ActionResult DodajBadanie()
        {
            return View();
        }

        public ActionResult EdytujBadanie()
        {
            return View();
        }

        public ActionResult UsunBadanie()
        {
            return View();
        }

        public ActionResult EdytujDanePacjenta()
        {
            return View();
        }

        public ActionResult UsunPacjenta()
        {
            return View();
        }

        public ActionResult Index()
        {
            throw new NotImplementedException();
        }


    }
}