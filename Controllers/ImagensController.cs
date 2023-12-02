using Microsoft.AspNetCore.Mvc;
using GWI.Repositories.ADO.SQLServer;
using GWI.Models.Imagens.Imagens.Imagens;
using GWI.Models.Imagens.Imagens;
using GWI.Models.Imagens;

namespace GWI.Controllers
{
    public class ImagensController : Controller
    {
        private readonly Repositories.ADO.SQLServer.ImagemADO repository;

        public ImagensController(IConfiguration configuration) 
        {
            this.repository = new Repositories.ADO.SQLServer.ImagemADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
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
        public ActionResult Create(Imagens imagens)
        {
            try
            {
                this.repository.add(imagens);

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
        public ActionResult Edit(int id, Imagens imagens)
        {
            try
            {
                this.repository.update(id, imagens);
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
