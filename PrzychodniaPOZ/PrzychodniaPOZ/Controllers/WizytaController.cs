using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrzychodniaPOZ.Controllers
{
    public class WizytaController : Controller
    {
        // GET: Wizyta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DostepneWizytaLekarz()
        {
            return Json(new { foo = "bar", baz = "Blech" });
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