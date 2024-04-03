using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilmesController : ApiController
    {
        private Somee db = new Somee();

        // GET: api/Filmes
        public IQueryable<tb_Filme> Gettb_Filme()
        {
            return db.tb_Filme;
        }

        // GET: api/Filmes/5
        [ResponseType(typeof(tb_Filme))]
        public async Task<IHttpActionResult> Gettb_Filme(int id)
        {
            tb_Filme tb_Filme = await db.tb_Filme.FindAsync(id);
            if (tb_Filme == null)
            {
                return NotFound();
            }

            return Ok(tb_Filme);
        }

        // PUT: api/Filmes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttb_Filme(int id, tb_Filme tb_Filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Filme.Codigo)
            {
                return BadRequest();
            }

            db.Entry(tb_Filme).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_FilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Filmes
        [ResponseType(typeof(tb_Filme))]
        public async Task<IHttpActionResult> Posttb_Filme(tb_Filme tb_Filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_Filme.Add(tb_Filme);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_Filme.Codigo }, tb_Filme);
        }

        // DELETE: api/Filmes/5
        [ResponseType(typeof(tb_Filme))]
        public async Task<IHttpActionResult> Deletetb_Filme(int id)
        {
            tb_Filme tb_Filme = await db.tb_Filme.FindAsync(id);
            if (tb_Filme == null)
            {
                return NotFound();
            }

            db.tb_Filme.Remove(tb_Filme);
            await db.SaveChangesAsync();

            return Ok(tb_Filme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_FilmeExists(int id)
        {
            return db.tb_Filme.Count(e => e.Codigo == id) > 0;
        }
    }
}