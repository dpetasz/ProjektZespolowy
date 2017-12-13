using PrzychodniaPOZ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PrzychodniaPOZ.Controllers
{
    public class ListaController : Controller
    {
        PrzychodniaContext db = new PrzychodniaContext();
        // GET: Lista
        
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult _BadaniaLista()
        {
            var badania = db.Badanie.ToList();
            return PartialView("_BadaniaLista",badania);
        }

        public ActionResult ListaBadanie(string nazwa)
        {
           
                return View();
            
        }

        [ChildActionOnly]
        public ActionResult BadaniaMenu()
        {
            var badania = db.Badanie.ToList();
            return PartialView("_BadaniaMenu", badania);
        }

        
        public ActionResult WyswietlBadanie(int id)
        {
            var wynik = (from wb in db.WizytaBadanie join b in db.Badanie
                                                         on wb.BadanieId equals b.BadanieId
                             where b.BadanieId == id 
                             select wb).ToList();
            return View(wynik);
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
    }
}