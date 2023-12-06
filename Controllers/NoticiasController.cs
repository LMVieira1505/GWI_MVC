using Microsoft.AspNetCore.Mvc;
using GWI.Repositories.ADO.SQLServer;
using GWI.Models.Noticias;
using GWI.Models.Imagens;
using System.Configuration;

namespace GWI.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly Repositories.ADO.SQLServer.NoticiaADO repository;

        public NoticiasController(IConfiguration configuration)
        { 
            this.repository = new Repositories.ADO.SQLServer.NoticiaADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        // Crud de Notícia //
        #region
        [HttpGet]
        public ActionResult Index()
        {
            return View(this.repository.get());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(this.repository.GetById(id));
        }

        [HttpGet]
        public ActionResult Create(int p_id)
        {
            ViewBag.p_id = p_id;
            ViewBag.CategoriasList = this.repository.GetCategorias();
            ViewBag.SubcategoriasList = this.repository.GetSubcategorias();
            ViewBag.ImagensList = this.repository.GetImagens();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Noticias noticias)
        {
            try
            {
                this.repository.add(noticias);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Noticias noticias)
        {
            try
            {
                this.repository.update(id, noticias);
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.repository.delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}