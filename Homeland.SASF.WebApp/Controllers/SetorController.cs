using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
using Homeland.SASF.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homeland.SASF.WebApp.Controllers
{
    [Authorize]
    public class SetorController : Controller
    {
        private readonly IRepository<Setor> _repo;

        public SetorController(IRepository<Setor> repository)
        {
            _repo = repository;
        }

        private IEnumerable<Setor> Carregar()
        {
            return _repo.All
                .ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new SetorViewModel
            {
                Setores = Carregar()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Setor model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(model);
                return RedirectToAction("Index", "Setor");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var model = RecuperarSetor(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(Setor model)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(model);
                return RedirectToAction("Index", "Setor");
            }
            return View(model);
        }

        public Setor RecuperarSetor(int id)
        {
            return _repo.Find(id);
        }

        public IActionResult Remover(int id)
        {
            var modelRemove = _repo.Find(id);
            if (modelRemove == null)
            {
                return NotFound();
            }
            _repo.Delete(modelRemove);
            return RedirectToAction("Index", "Setor");
        }
    }
}
