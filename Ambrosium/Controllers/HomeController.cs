using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ambrosium.Models;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Ambrosium.Controllers
{
    public class HomeController : Controller
    {
        private ambrosium_bdEntities2 db = new ambrosium_bdEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resultados()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Registar()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}