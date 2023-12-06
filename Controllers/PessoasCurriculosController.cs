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
        public ActionResult Index(int p_id)
        {
            ViewBag.p_id = p_id;
            return View(this.repository.GetForExps(p_id));
        }

        [HttpGet]
        public ActionResult Create(int p_id)
        {
            ViewBag.p_id = p_id;
            ViewBag.AreasList = this.repository.GetAreas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ForExp forExp, int p_id)
        {
            try
            {
                forExp.fe_p_id = p_id;
                this.repository.CreateForExp(forExp);

                return RedirectToAction(nameof(Index), new { p_id = p_id});
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int fe_id, int p_id) 
        {
            this.repository.DefDelete(fe_id);
            return RedirectToAction(nameof(Create), new { p_id = p_id });
        }

        [HttpGet]
        public ActionResult Delete(int fe_id, int p_id)
        {
            this.repository.DefDelete(fe_id);
            return RedirectToAction(nameof(Index), new { p_id = p_id});
        }

        //[HttpGet]
        //public ActionResult Edit(int id, int p_id)
        //{
        //    ViewBag.p_id = p_id;
        //    ViewBag.AreasList = this.repository.GetAreas();
        //    return View(this.repository.GetByIdForExp(id));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int p_id, ForExpArea forExp)
        //{
        //    try
        //    {
        //        ViewBag.AreasList = this.repository.GetAreas();
        //        this.repository.UpdateForExp(forExp);
        //        return RedirectToAction(nameof(Index), new { p_id = p_id });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion
    }
}
