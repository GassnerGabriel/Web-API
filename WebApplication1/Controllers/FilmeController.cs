using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilmeController : Controller
    {
        private Somee db = new Somee();

        // GET: Filme
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_Filme.ToListAsync());
        }

        // GET: Filme/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Filme tb_Filme = await db.tb_Filme.FindAsync(id);
            if (tb_Filme == null)
            {
                return HttpNotFound();
            }
            return View(tb_Filme);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Filme/Api
        public ActionResult Api()
        {
            return View();
        }

        // POST: Filme/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Codigo,Titulo,Ano,Genero,Produtora")] tb_Filme tb_Filme)
        {
            if (ModelState.IsValid)
            {
                db.tb_Filme.Add(tb_Filme);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_Filme);
        }

        // GET: Filme/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Filme tb_Filme = await db.tb_Filme.FindAsync(id);
            if (tb_Filme == null)
            {
                return HttpNotFound();
            }
            return View(tb_Filme);
        }

        // POST: Filme/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Codigo,Titulo,Ano,Genero,Produtora")] tb_Filme tb_Filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Filme).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_Filme);
        }

        // GET: Filme/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Filme tb_Filme = await db.tb_Filme.FindAsync(id);
            if (tb_Filme == null)
            {
                return HttpNotFound();
            }
            return View(tb_Filme);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_Filme tb_Filme = await db.tb_Filme.FindAsync(id);
            db.tb_Filme.Remove(tb_Filme);
            await db.SaveChangesAsync();
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
