using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ambrosium.Models;

namespace Ambrosium.Controllers
{
    public class UtilizadorsController : Controller
    {
        private ambrosium_bdEntities2 db = new ambrosium_bdEntities2();

        // GET: Utilizadors
        public ActionResult Index()
        {
            var utilizador = db.Utilizador.Include(u => u.Regime1);
            return View(utilizador.ToList());
        }

        // GET: Utilizadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        public ActionResult Historico()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Request()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Estabelecimentos()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        // GET: Utilizadors/Create
        public ActionResult Create()
        {
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome");
            return View();
        }

        // POST: Utilizadors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,imagem,sugestoes,denuncias,suspensao,penalidade,regime")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Utilizador.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", utilizador.regime);
            return View(utilizador);
        }

        // GET: Utilizadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", utilizador.regime);
            return View(utilizador);
        }

        // POST: Utilizadors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,imagem,sugestoes,denuncias,suspensao,penalidade,regime")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", utilizador.regime);
            return View(utilizador);
        }

        // GET: Utilizadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizador.Find(id);
            db.Utilizador.Remove(utilizador);
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
