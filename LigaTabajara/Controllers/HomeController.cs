using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LigaTabajara.Models;

namespace LigaTabajara.Controllers
{
    public class HomeController : Controller
    {
        private LigaTabajaraContext db = new LigaTabajaraContext();

        public ActionResult Index()
        {
            var times = db.Times
                          .Include(t => t.Jogadores)
                          .Include(t => t.ComissaoTecnica)
                          .ToList();

            bool ligaApta = times.Count == 20 &&
                            times.All(t => t.Jogadores.Count >= 30) &&
                            times.All(t => t.ComissaoTecnica.Count >= 5 &&
                                           t.ComissaoTecnica.Select(c => c.Cargo).Distinct().Count() == t.ComissaoTecnica.Count);

            ViewBag.LigaStatus = ligaApta ? "✅ Apta para iniciar o campeonato" : "❌ Liga incompleta - Verifique os requisitos";
            return View(times);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
