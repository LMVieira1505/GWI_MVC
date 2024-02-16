using GWI.Services;
using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GWI.Models.Pessoas;
using System.Linq.Expressions;

namespace GWI.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoaADO repository;
        private readonly ISessao sessao;

        public PessoasController(IConfiguration configuration, ISessao sessao)
        { 
            this.repository = new PessoaADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        //  Métodos de Login  //
        #region

        public IActionResult Login()
        {
            return this.sessao.getTokenPessoas() == null ?  View() : RedirectToAction("Index", "Pessoas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Pessoas pessoas)
        {

            if (!string.IsNullOrEmpty(pessoas.p_email) && !string.IsNullOrEmpty(pessoas.p_senha))
            {
                if (this.repository.check(pessoas))
                {
                    var loginResultado = repository.getType(pessoas);
                    this.sessao.addTokenPessoas(pessoas);

                    switch (loginResultado.TipoUsuario) {
                        case 1:
                            return RedirectToAction(nameof(AcessarPerfilAdm), new { id = pessoas.p_id });
                        case 4:
                            return RedirectToAction(nameof(AcessarPerfilUsuario), new { id = pessoas.p_id });
                    }
                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");
            }
            ViewBag.Error = "Usuario não detectado";
            return View();
        }

        public IActionResult Logout()
        {
            this.sessao.deleteTokenPessoas();
            return RedirectToAction("Index", "Noticias");
        }
        #endregion


        // Crud de Pessoa //
        #region
        [HttpGet]
        public ActionResult Index()
        {
            return View(this.repository.get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("CreateByAdm")]
        public ActionResult Create(int nv, int us_id)
        {
            ViewBag.nvUser = nv;
            ViewBag.idUser = us_id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoas pessoas, int nv, int us_id)
        {
            try
            {
                this.repository.add(pessoas);
                switch (nv)
                {
                    case 1:
                        return RedirectToAction(nameof(AcessarPerfilAdm), new { id = us_id });

                    default:
                        return RedirectToAction(nameof(Login));
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id, int nv, int us_id)
        {
            ViewBag.nvUser = nv;
            ViewBag.idUser = us_id;
            return View(this.repository.GetById(id));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int nv, int us_id, Pessoas pessoas)
        {
            try
            {
                this.repository.update(id, pessoas);
                switch (nv)
                {
                    case 1:
                        return RedirectToAction(nameof(AcessarPerfilAdm), new { id = us_id });

                    default:
                        return RedirectToAction(nameof(AcessarPerfilUsuario), new { id = id });
                }
            }
            catch
            {
                return View();
            }
        }
       
        public ActionResult Delete(int p_id, int nv, int us_id)
        {
            this.repository.delete(p_id);
            switch (nv)
            {
                case 1:
                    return RedirectToAction(nameof(AcessarPerfilAdm), new { id = us_id });

                default:
                    return RedirectToAction("Index", "Noticias");
            }
        }
        #endregion


        // Métodos de Perfil //
        #region

        #region"Padrão"

                public IActionResult AcessarPerfilUsuario(int id)
                {
                    return View(this.repository.GetById(id));
                }

                #endregion

        #region"ADM"

        public IActionResult AcessarPerfilAdm(int id)
        {
            List<List<Pessoas>> pessoas = this.repository.get();
            ViewBag.ListPadrao = pessoas[0];
            ViewBag.ListAutor = pessoas[1];
            ViewBag.ListAdm = pessoas[2];
            return View(this.repository.GetById(id));
        }

        #endregion

        #endregion
    }
}