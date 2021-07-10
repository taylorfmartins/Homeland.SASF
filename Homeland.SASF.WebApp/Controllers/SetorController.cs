using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
using Homeland.SASF.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homeland.SASF.WebApp.Controllers
{
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

        public IActionResult Index()
        {
            var model = new SetorViewModel
            {
                Setores = Carregar()
            };

            return View(model);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Adicionar(Setor model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(model);
                return RedirectToAction("Index", "Setor");
            }
            return View(model);
        }

        public IActionResult Detalhes(int id)
        {
            var model = RecuperarSetor(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

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

        public IActionResult Remover(Setor model)
        {
            var modelRemove = _repo.Find(model.Id);
            if (modelRemove == null)
            {
                return NotFound();
            }
            _repo.Delete(modelRemove);
            return RedirectToAction("Index", "Setor");
        }
    }
}
