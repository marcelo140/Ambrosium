﻿using System;
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

        [HttpPost]
        public ActionResult Search(string origin, string search)
        {
            List<Estabelecimento> es = db.Estabelecimento.ToList();
            List<Produto> nearby = new List<Produto>();
            
            foreach(Estabelecimento e in es)
            {
                if (e.GetDistance(origin) < 5000)
                {
                    List<Produto> ps = e.getProdutos(search);

                    foreach (Produto p in ps)
                        nearby.Add(p);
                }
            }

            return View(nearby);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}