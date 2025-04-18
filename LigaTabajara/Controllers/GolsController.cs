using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LigaTabajara.Models;

namespace LigaTabajara.Controllers
{
    public class GolsController : Controller
    {
        private LigaTabajaraContext db = new LigaTabajaraContext();

        // GET: Gols
        public ActionResult Index()
        {
            var gols = db.Gols.Include(g => g.Jogador).Include(g => g.Partida);
            return View(gols.ToList());
        }

        // GET: Gols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gol gol = db.Gols.Find(id);
            if (gol == null)
            {
                return HttpNotFound();
            }
            return View(gol);
        }

        // GET: Gols/Create
        public ActionResult Create()
        {
            ViewBag.JogadorId = new SelectList(db.Jogadores, "JogadorId", "Nome");
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Estadio");
            return View();
        }

        // POST: Gols/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GolId,PartidaId,JogadorId,Minuto")] Gol gol)
        {
            if (ModelState.IsValid)
            {
                db.Gols.Add(gol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JogadorId = new SelectList(db.Jogadores, "JogadorId", "Nome", gol.JogadorId);
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Estadio", gol.PartidaId);
            return View(gol);
        }

        // GET: Gols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gol gol = db.Gols.Find(id);
            if (gol == null)
            {
                return HttpNotFound();
            }
            ViewBag.JogadorId = new SelectList(db.Jogadores, "JogadorId", "Nome", gol.JogadorId);
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Estadio", gol.PartidaId);
            return View(gol);
        }

        // POST: Gols/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GolId,PartidaId,JogadorId,Minuto")] Gol gol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JogadorId = new SelectList(db.Jogadores, "JogadorId", "Nome", gol.JogadorId);
            ViewBag.PartidaId = new SelectList(db.Partidas, "PartidaId", "Estadio", gol.PartidaId);
            return View(gol);
        }

        // GET: Gols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gol gol = db.Gols.Find(id);
            if (gol == null)
            {
                return HttpNotFound();
            }
            return View(gol);
        }

        // POST: Gols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gol gol = db.Gols.Find(id);
            db.Gols.Remove(gol);
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
