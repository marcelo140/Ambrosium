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
    public class Sugestao_ProdutoController : Controller
    {
        private ambrosium_bdEntities2 db = new ambrosium_bdEntities2();

        // GET: Sugestao_Produto
        public ActionResult Index()
        {
            var sugestao_Produto = db.Sugestao_Produto.Include(s => s.Produto1).Include(s => s.Regime1).Include(s => s.Utilizador1);
            return View(sugestao_Produto.ToList());
        }

        // GET: Sugestao_Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sugestao_Produto sugestao_Produto = db.Sugestao_Produto.Find(id);
            if (sugestao_Produto == null)
            {
                return HttpNotFound();
            }
            return View(sugestao_Produto);
        }

        // GET: Sugestao_Produto/Create
        public ActionResult Create()
        {
            ViewBag.produto = new SelectList(db.Produto, "id", "nome");
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome");
            ViewBag.utilizador = new SelectList(db.Utilizador, "id", "nome");
            return View();
        }

        // POST: Sugestao_Produto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,data,regime,utilizador,produto")] Sugestao_Produto sugestao_Produto)
        {
            if (ModelState.IsValid)
            {
                db.Sugestao_Produto.Add(sugestao_Produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.produto = new SelectList(db.Produto, "id", "nome", sugestao_Produto.produto);
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", sugestao_Produto.regime);
            ViewBag.utilizador = new SelectList(db.Utilizador, "id", "nome", sugestao_Produto.utilizador);
            return View(sugestao_Produto);
        }

        // GET: Sugestao_Produto/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Sugestao_Produto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,data,regime,utilizador,produto")] Sugestao_Produto sugestao_Produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sugestao_Produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.produto = new SelectList(db.Produto, "id", "nome", sugestao_Produto.produto);
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", sugestao_Produto.regime);
            ViewBag.utilizador = new SelectList(db.Utilizador, "id", "nome", sugestao_Produto.utilizador);
            return View(sugestao_Produto);
        }

        // GET: Sugestao_Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sugestao_Produto sugestao_Produto = db.Sugestao_Produto.Find(id);
            if (sugestao_Produto == null)
            {
                return HttpNotFound();
            }
            return View(sugestao_Produto);
        }

        // POST: Sugestao_Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sugestao_Produto sugestao_Produto = db.Sugestao_Produto.Find(id);
            db.Sugestao_Produto.Remove(sugestao_Produto);
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
