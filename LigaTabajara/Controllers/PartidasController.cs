using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LigaTabajara.Models;

namespace LigaTabajara.Controllers
{
    public class PartidasController : Controller
    {
        private LigaTabajaraContext db = new LigaTabajaraContext();

        // GET: Partidas
        public ActionResult Index()
        {
            var partidas = db.Partidas
                .Include(p => p.TimeCasa)
                .Include(p => p.TimeFora)
                .ToList();
            return View(partidas);
        }

        // GET: Partidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var partida = db.Partidas
                .Include(p => p.TimeCasa)
                .Include(p => p.TimeFora)
                .FirstOrDefault(p => p.PartidaId == id);

            if (partida == null)
                return HttpNotFound();

            return View(partida);
        }

        // GET: Partidas/Create
        public ActionResult Create()
        {
            ViewBag.TimeCasaId = new SelectList(db.Times, "TimeId", "Nome");
            ViewBag.TimeForaId = new SelectList(db.Times, "TimeId", "Nome");
            return View();
        }

        // POST: Partidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartidaId,TimeCasaId,TimeForaId,DataHora,Estadio,PlacarTimeCasa,PlacarTimeFora,Rodada")] Partida partida)
        {
            if (partida.TimeCasaId == partida.TimeForaId)
            {
                ModelState.AddModelError("", "O time da casa e o time visitante não podem ser o mesmo.");
            }

            if (ModelState.IsValid)
            {
                db.Partidas.Add(partida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeCasaId = new SelectList(db.Times, "TimeId", "Nome", partida.TimeCasaId);
            ViewBag.TimeForaId = new SelectList(db.Times, "TimeId", "Nome", partida.TimeForaId);
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var partida = db.Partidas.Find(id);
            if (partida == null)
                return HttpNotFound();

            ViewBag.TimeCasaId = new SelectList(db.Times, "TimeId", "Nome", partida.TimeCasaId);
            ViewBag.TimeForaId = new SelectList(db.Times, "TimeId", "Nome", partida.TimeForaId);
            return View(partida);
        }

        // POST: Partidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartidaId,TimeCasaId,TimeForaId,DataHora,Estadio,PlacarTimeCasa,PlacarTimeFora,Rodada")] Partida partida)
        {
            if (partida.TimeCasaId == partida.TimeForaId)
            {
                ModelState.AddModelError("", "O time da casa e o time visitante não podem ser o mesmo.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(partida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeCasaId = new SelectList(db.Times, "TimeId", "Nome", partida.TimeCasaId);
            ViewBag.TimeForaId = new SelectList(db.Times, "TimeId", "Nome", partida.TimeForaId);
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var partida = db.Partidas
                .Include(p => p.TimeCasa)
                .Include(p => p.TimeFora)
                .FirstOrDefault(p => p.PartidaId == id);

            if (partida == null)
                return HttpNotFound();

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var partida = db.Partidas.Find(id);
            db.Partidas.Remove(partida);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
