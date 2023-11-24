using GWI.Models;
using GWI.Services;
using GWI.Repositories.ADO.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        public IActionResult FazerLogin()
        {
            return View();
        }

        public IActionResult Login()
        {
            return this.sessao.getTokenPessoas() == null ?  View() : RedirectToAction("Index", "Pessoas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Models.Pessoas pessoas)
        {

            if (!string.IsNullOrEmpty(pessoas.p_email) && !string.IsNullOrEmpty(pessoas.p_senha))
            {
                if (this.repository.check(pessoas))
                {
                    var loginResultado = repository.getType(pessoas);
                    this.sessao.addTokenPessoas(pessoas);

                    if (loginResultado.TipoUsuario == 1)
                        return RedirectToAction("Index", "Pessoas");
                    return RedirectToAction("Index", "Noticias");
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


        // Métodos de Pessoa //
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
