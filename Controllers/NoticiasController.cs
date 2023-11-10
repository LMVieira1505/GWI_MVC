using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GWI.Controllers
{
    public class NoticiasController
    {
        public class CarrosController : Controller
        {
            private readonly Repositories.ADO.SQLServer.Noticia repository;

            public CarrosController(IConfiguration configuration) // objeto configuration => parte do framework que permite ler o arquivo appsettings.json - GetConnectionString => método do framework que permite ler a chave ConnectionStrings deste arquivo.
            {
                this.repository = new Repositories.ADO.SQLServer.Noticia(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
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
            public ActionResult Create(Models.Noticias noticias )
            {
                try
                {
                    this.repository.add(Noticia);

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

            // GET: CarrosController/Delete/5
            public ActionResult Delete(int id)
            {
                this.repository.delete(id);
                return RedirectToAction(nameof(Index));
            }

        }
    }

}

