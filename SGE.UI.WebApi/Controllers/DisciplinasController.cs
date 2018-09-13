using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sge.Service.Interfaces;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;

namespace SGE.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {        
        private readonly IDisciplinaService _disciplinaService;
        private readonly IUnitOfWork _uow;

        public DisciplinasController(IDisciplinaService disciplinaService, IUnitOfWork unitOfWork)
        {
            _disciplinaService = disciplinaService;
            _uow = unitOfWork;
        }

        // GET: api/Disciplinas
        [HttpGet]
        public IEnumerable<Disciplina> Get()
        {
            return _disciplinaService.Get();
        }

        // GET: api/Disciplinas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disciplina = await _disciplinaService.Get(id);

            if (disciplina == null)
            {
                return NotFound();
            }

            return Ok(disciplina);
        }

        // PUT: api/Disciplinas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disciplina.IdDisciplina)
            {
                return BadRequest();
            }

            _disciplinaService.Put(disciplina);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Disciplinas
        [HttpPost]
        public IActionResult Post([FromBody] Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _disciplinaService.Post(disciplina);
            _uow.Commit();

            return CreatedAtAction("Get", new { id = disciplina.IdDisciplina }, disciplina);
        }

        // DELETE: api/Disciplinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disciplina = await _disciplinaService.Get(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            _disciplinaService.Delete(disciplina.IdDisciplina);
            _uow.Commit();

            return Ok(disciplina);
        }

        private bool DisciplinaExists(int id)
        {
            return _disciplinaService.Get(id).Result == null ? false : true;
        }
    }
}