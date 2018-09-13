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
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaService _turmaService;
        private readonly IUnitOfWork _uow;

        public TurmasController(ITurmaService turmaService, IUnitOfWork unitOfWork)
        {
            _turmaService = turmaService;
            _uow = unitOfWork;
        }

        // GET: api/Turmas
        [HttpGet]
        public IEnumerable<Turma> Get()
        {
            return _turmaService.Get();
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turma = await _turmaService.Get(id);

            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma);
        }

        // PUT: api/Turmas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turma.IdTurma)
            {
                return BadRequest();
            }

            _turmaService.Put(turma);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // POST: api/Turmas
        [HttpPost]
        public IActionResult Post([FromBody] Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _turmaService.Post(turma);
            _uow.Commit();

            return CreatedAtAction("Get", new { id = turma.IdTurma }, turma);
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turma = await _turmaService.Get(id);
            if (turma == null)
            {
                return NotFound();
            }

            _turmaService.Delete(turma.IdTurma);
            _uow.Commit();

            return Ok(turma);
        }

        private bool TurmaExists(int id)
        {
            return _turmaService.Get(id).Result == null ? false : true;
        }
    }
}