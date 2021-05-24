using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyControl.Data;
using EasyControl.Models;

namespace EasyControl.Controllers
{
  
    public class ProdutosController : Controller
    {
        private EasyControlContext db = new EasyControlContext();

        // GET: Produtos

        [Authorize]
        public ActionResult Index()
        {
            var produtoes = db.Produtoes.Include(p => p.Filial).Include(p => p.Fornecedor);
            return View(produtoes.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FilialId = new SelectList(db.Filials, "FilialId", "Nome");
            ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Preco,FornecedorId,FilialId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilialId = new SelectList(db.Filials, "FilialId", "Nome", produto.FilialId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "Nome", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilialId = new SelectList(db.Filials, "FilialId", "Nome", produto.FilialId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "Nome", produto.FornecedorId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Preco,FornecedorId,FilialId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilialId = new SelectList(db.Filials, "FilialId", "Nome", produto.FilialId);
            ViewBag.FornecedorId = new SelectList(db.Fornecedors, "FornecedorId", "Nome", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
