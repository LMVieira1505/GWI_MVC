using Microsoft.AspNetCore.Mvc;
using GWI.Models;
using GWI.Repositories.ADO.SQLServer;

namespace GWI.Controllers
{
    public class ImagensController : Controller
    {
        private readonly Repositories.ADO.SQLServer.ImagemADO repository;

        public ImagensController(IConfiguration configuration) // objeto configuration => parte do framework que permite ler o arquivo appsettings.json - GetConnectionString => método do framework que permite ler a chave ConnectionStrings deste arquivo.
        {
            this.repository = new Repositories.ADO.SQLServer.ImagemADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            //Configurations.Appsettings.getKeyConnectionString => nossa classe de configuração para trazer a chave que deve ser lida, neste caso: DefaultConnection.
        }

        // GET: CarrosController
        [HttpGet]
        public ActionResult Index()
        {
            return View(this.repository.get());
        }

        // GET: CarrosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Imagens imagens)
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

        // GET: CarrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(this.repository.getById(id));
        }

        // POST: CarrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Imagens imagens)
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

        // GET: CarrosController/Delete/5
        public ActionResult Delete(int id)
        {
            this.repository.delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
