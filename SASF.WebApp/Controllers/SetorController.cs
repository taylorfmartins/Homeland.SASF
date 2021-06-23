using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo(Setor model)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
