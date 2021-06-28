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

        public IActionResult Index()
        {
            var model = new FuncionarioViewModel
            {
                Funcionarios = Carregar()
            };

            return View(model);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Adicionar(Funcionario model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(model);
                return RedirectToAction("Index", "Funcionario");
            }
            return View(model);
        }
    }
}
