using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using GWI.Models;
using GWI.Repositories.ADO.SQLServer;

namespace GWI.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.LoginADO repository;
        private readonly Services.ISessao sessao;

        public LoginController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.LoginADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Login()
        {
            // Se o usuário não estiver logado retorna a View() senão retorna para a página de início.
            return this.sessao.getTokenLogin() == null ? View() : RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Models.Login login)
        {

            if (!string.IsNullOrEmpty(login.Usuario) && !string.IsNullOrEmpty(login.Senha))
            {
                if (this.repository.check(login))
                {
                    var loginResultado = repository.getType(login);
                    this.sessao.addTokenLogin(login);

                    if (loginResultado.TipoUsuario == "administrador")
                        return RedirectToAction("Index", "Admin");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");
            }

            return View();
        }           
    }
}
