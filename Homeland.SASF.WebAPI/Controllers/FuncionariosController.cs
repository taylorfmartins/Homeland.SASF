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
    public class FuncionariosController : ControllerBase
    {
        private readonly IRepository<Funcionario> _repo;

        public FuncionariosController(IRepository<Funcionario> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _repo.All.Select(f => f.ToApi()).ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Funcionario model)
        {
            if (ModelState.IsValid)
            {
                var funcionario = model;

                List<Object> errorList = new List<Object>();

                if (String.IsNullOrEmpty(funcionario.Nome))
                    errorList.Add(new { error = "Nome não pode estar em branco ou nulo!" });

                if (String.IsNullOrEmpty(funcionario.Telefone))
                    errorList.Add(new { error = "Telefone não pode estar em branco ou nulo!" });

                if (String.IsNullOrEmpty(funcionario.Email))
                    errorList.Add(new { error = "Email não pode estar em branco ou nulo!" });

                if (String.IsNullOrEmpty(funcionario.CPF))
                    errorList.Add(new { error = "CPF não pode estar em branco ou nulo!" });

                if (String.IsNullOrEmpty(funcionario.TipoNotificacao.ParaString()))
                    errorList.Add(new { error = "TipoNotificacao (WhatsApp, Email, Telegram) não pode estar em branco ou nulo!" });

                if (errorList.Count > 0)
                    return BadRequest(errorList);

                _repo.Add(funcionario);
                var uri = "/api/Funcionario/" + funcionario.Matricula;
                return Created(uri, funcionario);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Funcionario model)
        {
            if (ModelState.IsValid)
            {
                var funcionario = model;
                _repo.Update(funcionario);
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
