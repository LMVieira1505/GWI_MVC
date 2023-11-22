using Microsoft.AspNetCore.Mvc;
using GWI.Models;
using GWI.Repositories.ADO.SQLServer;

namespace GWI.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly Repositories.ADO.SQLServer.NoticiaADO repository;

        public NoticiasController(IConfiguration configuration)
        { 
            this.repository = new Repositories.ADO.SQLServer.NoticiaADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(this.repository.get());
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Noticias noticias)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Noticias noticias)
        {
            try
            {
                this.repository.update(id, noticias);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            this.repository.delete(id);
            return RedirectToPage("Noticias","Index");
        }

        public ActionResult Details(int id)
        {
            return View(this.repository.Details(id));
        }
    }

        
}

