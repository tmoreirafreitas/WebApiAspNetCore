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
    public class TurmaDisciplinasController : ControllerBase
    {
        private readonly ITurmaDisciplinaService _turmaDisciplinaService;
        private readonly IUnitOfWork _uow;

        public TurmaDisciplinasController(ITurmaDisciplinaService turmaDisciplinaService, IUnitOfWork unitOfWork)
        {
            _turmaDisciplinaService = turmaDisciplinaService;
            _uow = unitOfWork;
        }

        // GET: api/TurmaDisciplinas
        [HttpGet]
        public IEnumerable<TurmaDisciplina> Get()
        {
            return _turmaDisciplinaService.Get();
        }

        // GET: api/TurmaDisciplinas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turmaDisciplina = await _turmaDisciplinaService.Get(id);

            if (turmaDisciplina == null)
            {
                return NotFound();
            }

            return Ok(turmaDisciplina);
        }

        // PUT: api/TurmaDisciplinas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int idTurma, [FromRoute] int idDisciplina, [FromBody] TurmaDisciplina turmaDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idTurma != turmaDisciplina.IdTurma)
            {
                return BadRequest();
            }

            if (idDisciplina != turmaDisciplina.IdDisciplina)
            {
                return BadRequest();
            }

            _turmaDisciplinaService.Put(turmaDisciplina);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaDisciplinaExists(idTurma, idDisciplina))
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

        // POST: api/TurmaDisciplinas
        [HttpPost]
        public IActionResult Post([FromBody] TurmaDisciplina turmaDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _turmaDisciplinaService.Post(turmaDisciplina);
            try
            {
                _uow.Commit();
            }
            catch (DbUpdateException)
            {
                if (TurmaDisciplinaExists(turmaDisciplina.IdTurma, turmaDisciplina.IdDisciplina))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = turmaDisciplina.IdTurma }, turmaDisciplina);
        }

        // DELETE: api/TurmaDisciplinas/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int idTurma, [FromRoute] int idDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turmaDisciplina = _turmaDisciplinaService.GetByIds(idTurma, idDisciplina);
            if (turmaDisciplina == null)
            {
                return NotFound();
            }

            _turmaDisciplinaService.Delete(idTurma, idDisciplina);
            _uow.Commit();

            return Ok(turmaDisciplina);
        }

        private bool TurmaDisciplinaExists(int idTurma, int idDisciplina)
        {
            return _turmaDisciplinaService.GetByIds(idTurma, idDisciplina) == null ? false : true;
        }
    }
}