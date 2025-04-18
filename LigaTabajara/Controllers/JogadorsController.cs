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
    public class JogadorsController : Controller
    {
        private LigaTabajaraContext db = new LigaTabajaraContext();

        // GET: Jogadors
        public ActionResult Index()
        {
            var jogadores = db.Jogadores
                .Include(j => j.Time)
                .Select(j => new Jogador
                {
                    JogadorId = j.JogadorId,
                    Nome = j.Nome,
                    Posicao = j.Posicao,
                    NumeroCamisa = j.NumeroCamisa,
                    PePreferido = j.PePreferido,
                    Time = new Time
                    {
                        Nome = j.Time.Nome
                    }
                }).ToList();

            return View(jogadores);
        }

        // GET: Jogadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jogador jogador = db.Jogadores
                .Include(j => j.Time)
                .FirstOrDefault(j => j.JogadorId == id);

            if (jogador == null)
                return HttpNotFound();

            return View(jogador);
        }

        // GET: Jogadors/Create
        public ActionResult Create()
        {
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome");
            return View();
        }

        // POST: Jogadors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogadorId,Nome,DataNascimento,Nacionalidade,Posicao,NumeroCamisa,Altura,Peso,PePreferido,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Jogadores.Add(jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // GET: Jogadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jogador jogador = db.Jogadores
                .Include(j => j.Time)
                .FirstOrDefault(j => j.JogadorId == id);

            if (jogador == null)
                return HttpNotFound();

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // POST: Jogadors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogadorId,Nome,DataNascimento,Nacionalidade,Posicao,NumeroCamisa,Altura,Peso,PePreferido,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // GET: Jogadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jogador jogador = db.Jogadores
                .Include(j => j.Time)
                .FirstOrDefault(j => j.JogadorId == id);

            if (jogador == null)
                return HttpNotFound();

            return View(jogador);
        }

        // POST: Jogadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogador jogador = db.Jogadores.Find(id);
            db.Jogadores.Remove(jogador);
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
