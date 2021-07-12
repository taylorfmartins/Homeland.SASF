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
    public class FuncionarioController : Controller
    {
        private readonly IRepository<Funcionario> _repo;

        public FuncionarioController(IRepository<Funcionario> repository)
        {
            _repo = repository;
        }

        private IEnumerable<Funcionario> Carregar()
        {
            return _repo.All
                .ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new FuncionarioViewModel
            {
                Funcionarios = Carregar()
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
        public IActionResult Adicionar(Funcionario model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(model);
                return RedirectToAction("Index", "Funcionario");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var model = RecuperarFuncionario(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(Funcionario model)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(model);
                return RedirectToAction("Index", "Funcionario");
            }
            return View(model);
        }

        public Funcionario RecuperarFuncionario(int id)
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
            return RedirectToAction("Index", "Funcionario");
        }
    }
}
