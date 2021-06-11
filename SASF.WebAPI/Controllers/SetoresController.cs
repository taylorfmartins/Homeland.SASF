using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homeland.SASF.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetoresController : ControllerBase
    {
        private readonly IRepository<Setor> _repo;

        public SetoresController(IRepository<Setor> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _repo.All.Select(s => s.ToApi()).ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _repo.Find(id).ToApi();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Setor model)
        {
            if (ModelState.IsValid)
            {
                var setor = model;

                _repo.Add(setor);
                var uri = "/api/Setores/" + setor.Id;
                return Created(uri, setor);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Setor model)
        {
            if (ModelState.IsValid)
            {
                var setor = model;
                _repo.Update(setor);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Delete(model);
            return NoContent();
        }
    }
}
