using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
using Homeland.SASF.WebApp.HttpClients;
using Homeland.SASF.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homeland.SASF.WebApp.Controllers
{
    [Authorize]
    public class PetPerfeitoController : Controller
    {
        private readonly IRepository<PetPerfeito> _repo;
        private readonly PetPerfeitoApiClient _api;

        public PetPerfeitoController(IRepository<PetPerfeito> repository, PetPerfeitoApiClient api)
        {
            _repo = repository;
            _api = api;
        }

        [HttpGet]
        public IActionResult Index()
        {
            foreach (PetPerfeitoApi pet in ConsultarPetPerfeito())
            {
                if (_repo.All.Where(p => string.Equals(p.Nome, pet.nome)).Count() == 0)
                    _repo.Add(pet.ToModel());
            }

            var model = new PetPerfeitoViewModel
            {
                Pets = Carregar()
            };

            return View(model);
        }

        public List<PetPerfeitoApi> ConsultarPetPerfeito()
        {
            return _api.GetPets().Result;
        }

        private IEnumerable<PetPerfeito> Carregar()
        {
            return _repo.All
                .ToList();
        }
    }
}
