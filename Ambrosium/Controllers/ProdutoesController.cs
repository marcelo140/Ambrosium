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
    public class ProdutoesController : Controller
    {
        private ambrosium_bdEntities2 db = new ambrosium_bdEntities2();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produto = db.Produto.Include(p => p.Estabelecimento1).Include(p => p.Regime1);
            return View(produto.ToList());
        }

       
       

        // POST: Produtoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,imagem,estabelecimento,regime,ativo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estabelecimento = new SelectList(db.Estabelecimento, "id", "nome", produto.estabelecimento);
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", produto.regime);
            return View(produto);
        }

        public ActionResult Review()
        {
            return View();
        }

        

        // POST: Produtoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,imagem,estabelecimento,regime,ativo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estabelecimento = new SelectList(db.Estabelecimento, "id", "nome", produto.estabelecimento);
            ViewBag.regime = new SelectList(db.Regime, "nome", "nome", produto.regime);
            return View(produto);
        }

        

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
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
