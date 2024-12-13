using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Negocio;
using Entidades;

namespace Presentacion.Controllers
{
    public class EstatusAlumnosController : Controller
    {
        private readonly NEstatusAlumnos _nEstatusAlumnos;

        public EstatusAlumnosController()
        {
            _nEstatusAlumnos = new NEstatusAlumnos(new HttpClient());
        }

        // GET: EstatusAlumnos
        public async Task<ActionResult> Index()
        {
            var estatusAlumnos = await _nEstatusAlumnos.Consultar();
            return View(estatusAlumnos);
        }

        // GET: EstatusAlumnos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var estatusAlumnos = await _nEstatusAlumnos.Consultar(id);
            return View(estatusAlumnos);
        }

        // GET: EstatusAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstatusAlumnos/Create
        [HttpPost]
        public async Task<ActionResult> Create(EstatusAlumnos estatusAlumnos)
        {
            if (ModelState.IsValid)
            {
                await _nEstatusAlumnos.Agregar(estatusAlumnos);
                return RedirectToAction("Index");
            }

            return View(estatusAlumnos);
        }

        // GET: EstatusAlumnos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var estatusAlumnos = await _nEstatusAlumnos.Consultar(id);
            return View(estatusAlumnos);
        }

        // POST: EstatusAlumnos/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EstatusAlumnos estatusAlumnos)
        {
            if (ModelState.IsValid)
            {
                await _nEstatusAlumnos.Actualizar(estatusAlumnos);
                return RedirectToAction("Index");
            }

            return View(estatusAlumnos);
        }

        // GET: EstatusAlumnos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var estatusAlumnos = await _nEstatusAlumnos.Consultar(id);
            return View(estatusAlumnos);
        }

        // POST: EstatusAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _nEstatusAlumnos.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
