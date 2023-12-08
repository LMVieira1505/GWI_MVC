using GWI.Services;
using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GWI.Models.Curriculos;
using GWI.Models.Noticias;
using GWI.Models;

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

        // Curriculo Completo //
        #region
        public ActionResult CurriculoCompleto(int p_id)
        {
            ViewBag.CnhList = this.repository.GetCnhs();
            ViewBag.HabilidadeList = this.repository.GetHabilidades();
            ViewBag.FeList = this.repository.GetForExps(p_id);
            ViewBag.Pessoa = this.repository.GetByIdPessoa(p_id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CurriculoCompleto(CurriculoCompleto cr, int p_id)
        {
            try
            {
                cr.P_Id = p_id;
                this.repository.CreateCurriculo(cr);
                return RedirectToAction(nameof(GetCurriculo), new { cr = cr });
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult GetCurriculo(CurriculoCompleto cr)
        {
            this.repository.GetCurriculo();
            return View();
        }
        #endregion

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
