using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using GWI.Models;
using GWI.Repositories.ADO.SQLServer;

namespace GWI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        public IActionResult VerificarEmail()
        {
            return View();
        }

        public IActionResult ErroEmail()
        {
            return View();
        }

        public IActionResult EscolherMetodo()
        {
            return View();
        }

        public IActionResult MetodoIncorreto()
        {
            return View();
        }

        public IActionResult InserirCodigo()
        {
            return View();
        }

        public IActionResult NovaSenha()
        {
            return View();
        }
    }
}
