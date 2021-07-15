using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
using Homeland.SASF.WebApp.HttpClients;
using Homeland.SASF.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homeland.SASF.WebApp.Controllers
{
    public class OcorrenciaController : Controller
    {
        private readonly IRepository<Ocorrencia> _repo;

        public OcorrenciaController(IRepository<Ocorrencia> repository)
        {
            _repo = repository;
        }

        private IEnumerable<Ocorrencia> Carregar()
        {
            return _repo.All
                .ToList();
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new OcorrenciaViewModel
            {
                Ocorrencias = Carregar()
            };

            return View(model);
        }

        public IActionResult Adicionar(Ocorrencia model)
        {
            if (ModelState.IsValid)
            {
                model.data = DateTime.Now;
                _repo.Add(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Novo()
        {
            return View();
        }

        
    }
}