using GWI.Services;
using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GWI.Models.Curriculos;

namespace GWI.Controllers
{
    public class PessoasCurriculosController : Controller
    {
        private readonly Repositories.ADO.SQLServer.PessoasCurriculosADO repository;
        private readonly Services.ISessao sessao;

        public PessoasCurriculosController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.PessoasCurriculosADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        // Crud de Formação e Experiência Profissional //
        #region
        [HttpGet]
        public IActionResult Index(int p_id)
        {
            return View(this.repository.GetForExps(p_id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ForExp forExp)
        {
            try
            {
                this.repository.CreateForExp(forExp);

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
            return View(this.repository.GetByIdForExp(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ForExp forExp)
        {
            try
            {
                this.repository.UpdateForExp(id, forExp);
                return RedirectToAction(nameof(Index), new { p_id = id });
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
