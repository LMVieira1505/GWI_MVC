﻿using Microsoft.AspNetCore.Mvc;
using GWI.Repositories.ADO.SQLServer;
using GWI.Models.Noticias.Noticias.Noticias.Noticias.Noticias.Noticias;
using GWI.Models.Noticias.Noticias.Noticias.Noticias.Noticias;
using GWI.Models.Noticias.Noticias.Noticias.Noticias;
using GWI.Models.Noticias.Noticias.Noticias;
using GWI.Models.Noticias.Noticias;
using GWI.Models.Noticias;

namespace GWI.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly Repositories.ADO.SQLServer.NoticiaADO repository;

        public NoticiasController(IConfiguration configuration)
        { 
            this.repository = new Repositories.ADO.SQLServer.NoticiaADO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        // Crud de Notícia //
        #region
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
        public ActionResult Create(Noticias noticias)
        {
            try
            {
                this.repository.add(noticias);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Noticias noticias)
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

        
        public ActionResult Delete(int id)
        {
            this.repository.delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            return View(this.repository.Details(id));
        }
        #endregion
    }
}