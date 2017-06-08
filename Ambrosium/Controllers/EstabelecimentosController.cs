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
    public class EstabelecimentosController : Controller
    {
        private ambrosium_bdEntities2 db = new ambrosium_bdEntities2();

        // GET: Estabelecimentos
        public ActionResult Index()
        {
            return View(db.Estabelecimento.ToList());
        }

        // GET: Estabelecimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        //GET: Estabelecimentos/Menus/5
        public ActionResult Menus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento e = db.Estabelecimento.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }

            return View(e);
        }


        // GET: Estabelecimentos/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update()
        {
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=41.5609804,-8.3966431&radius=6000&rankby=prominence&type=restaurant&key=AIzaSyA_cNufnfv4_Mad0We1ZQZxWyHG6zE_x44");
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string content = reader.ReadToEnd();
            JObject jContent = JObject.Parse(content);

            var places = jContent
                .SelectTokens("$.results[*].place_id")
                .Select(t => (string)t)
                .ToList();

            foreach (var place_id in places)
            {
                Estabelecimento e = new Estabelecimento();
                e.load(place_id);
                db.Estabelecimento.Add(e);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Estabelecimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,descricao,telefone,rating,localizacao,ativo,sugestoes")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Estabelecimento.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,descricao,telefone,rating,localizacao,ativo,sugestoes")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            db.Estabelecimento.Remove(estabelecimento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
