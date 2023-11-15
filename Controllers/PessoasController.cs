using GWI.Models;
using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GWI.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Repositories.ADO.SQLServer.PessoaADO repository;

        public PessoasController(IConfiguration configuration)
        { 
            this.repository = new Repositories.ADO.SQLServer.PessoaADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
           
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
        public ActionResult Create(Models.Pessoas pessoas)
        {
            try
            {
                this.repository.add(pessoas);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            return View(this.repository.getById(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Pessoas pessoas)
        {
            try
            {
                this.repository.update(id, pessoas);
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
            return RedirectToAction(nameof(Index));
        }

    }
}
