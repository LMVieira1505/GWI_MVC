using GWI.Services;
using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GWI.Models.Pessoas;

namespace GWI.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Repositories.ADO.SQLServer.PessoaADO repository;
        private readonly Services.ISessao sessao;

        public PessoasController(IConfiguration configuration, Services.ISessao sessao)
        { 
            this.repository = new Repositories.ADO.SQLServer.PessoaADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
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

                    if (loginResultado.TipoUsuario == 1)
                        return RedirectToAction("Index", "Pessoas");
                    else if (loginResultado.TipoUsuario == 4)
                        return RedirectToAction(nameof(AcessarPerfilUsuario), new {id = pessoas.p_id});
                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");

            }
            ViewBag.Error = "Usuario não detectado";
            return View();
        }

        public IActionResult Logout()
        {
            this.sessao.deleteTokenPessoas();
            return RedirectToAction("Noticias", "Index");
        }
        #endregion



        // Crud de Pessoa //
        #region
        [HttpGet]
        public ActionResult Index()
        {
            return View(this.repository.get());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoas pessoas)
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.repository.GetById(id));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoas pessoas)
        {
            try
            {
                this.repository.update(id, pessoas);
                return RedirectToAction(nameof(AcessarPerfilUsuario), new { id = id });
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
        #endregion



        // Métodos de Perfil //
        #region

        public IActionResult AcessarPerfilUsuario(int id)
        {
            return View(this.repository.GetById(id));
        }

        #endregion
    }
}