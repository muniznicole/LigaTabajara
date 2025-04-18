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
    public class ComissaoTecnicasController : Controller
    {
        private LigaTabajaraContext db = new LigaTabajaraContext();

        // GET: ComissaoTecnicas
        public ActionResult Index()
        {
            var comissoesTecnicas = db.ComissoesTecnicas.Include(c => c.Time);
            return View(comissoesTecnicas.ToList());
        }

        // GET: ComissaoTecnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ComissaoTecnica comissaoTecnica = db.ComissoesTecnicas.Include(c => c.Time)
                                                                  .FirstOrDefault(c => c.ComissaoTecnicaId == id);
            if (comissaoTecnica == null)
                return HttpNotFound();

            return View(comissaoTecnica);
        }

        // GET: ComissaoTecnicas/Create
        public ActionResult Create()
        {
            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome");
            return View();
        }

        // POST: ComissaoTecnicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComissaoTecnicaId,Nome,Cargo,DataNascimento,TimeId")] ComissaoTecnica comissaoTecnica)
        {
            // 🔒 Verifica se já existe esse cargo para o mesmo time
            bool cargoExiste = db.ComissoesTecnicas.Any(ct =>
                ct.TimeId == comissaoTecnica.TimeId &&
                ct.Cargo == comissaoTecnica.Cargo);

            if (cargoExiste)
            {
                ModelState.AddModelError("", "Este cargo já está ocupado neste time.");
            }

            if (ModelState.IsValid)
            {
                db.ComissoesTecnicas.Add(comissaoTecnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", comissaoTecnica.TimeId);
            return View(comissaoTecnica);
        }

        // GET: ComissaoTecnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ComissaoTecnica comissaoTecnica = db.ComissoesTecnicas.Find(id);
            if (comissaoTecnica == null)
                return HttpNotFound();

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", comissaoTecnica.TimeId);
            return View(comissaoTecnica);
        }

        // POST: ComissaoTecnicas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComissaoTecnicaId,Nome,Cargo,DataNascimento,TimeId")] ComissaoTecnica comissaoTecnica)
        {
            // 🔒 Evita duplicidade de cargos no mesmo time, exceto o próprio registro
            bool cargoExiste = db.ComissoesTecnicas.Any(ct =>
                ct.TimeId == comissaoTecnica.TimeId &&
                ct.Cargo == comissaoTecnica.Cargo &&
                ct.ComissaoTecnicaId != comissaoTecnica.ComissaoTecnicaId);

            if (cargoExiste)
            {
                ModelState.AddModelError("", "Este cargo já está ocupado neste time.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(comissaoTecnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "TimeId", "Nome", comissaoTecnica.TimeId);
            return View(comissaoTecnica);
        }

        // GET: ComissaoTecnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ComissaoTecnica comissaoTecnica = db.ComissoesTecnicas.Include(c => c.Time)
                                                                  .FirstOrDefault(c => c.ComissaoTecnicaId == id);
            if (comissaoTecnica == null)
                return HttpNotFound();

            return View(comissaoTecnica);
        }

        // POST: ComissaoTecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComissaoTecnica comissaoTecnica = db.ComissoesTecnicas.Find(id);
            db.ComissoesTecnicas.Remove(comissaoTecnica);
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
