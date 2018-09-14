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
    public class ProfessorDisciplinaController : ControllerBase
    {
        private readonly IProfessorDisciplinaService _professorDisciplinaService;
        private readonly IUnitOfWork _uow;

        public ProfessorDisciplinaController(IProfessorDisciplinaService professorDisciplinaService, IUnitOfWork unitOfWork)
        {
            _professorDisciplinaService = professorDisciplinaService;
            _uow = unitOfWork;
        }

        // GET: api/ProfessorDisciplina
        [HttpGet]
        public IEnumerable<ProfessorDisciplina> Get()
        {
            return _professorDisciplinaService.Get();
        }

        // GET: api/ProfessorDisciplina/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int idProfessor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorDisciplina = _professorDisciplinaService.GetByIdProfessor(idProfessor);

            if (professorDisciplina == null)
            {
                return NotFound();
            }

            return Ok(professorDisciplina);
        }

        // PUT: api/ProfessorDisciplina/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int idProfessor, [FromRoute] int idDisciplina, [FromBody] ProfessorDisciplina professorDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idProfessor != professorDisciplina.IdProfessor)
            {
                return BadRequest();
            }
            if (idDisciplina != professorDisciplina.IdDisciplina)
            {
                return BadRequest();
            }

            _professorDisciplinaService.Put(professorDisciplina);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorDisciplinaExists(idProfessor, idDisciplina))
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

        // POST: api/ProfessorDisciplina
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorDisciplina professorDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _professorDisciplinaService.Post(professorDisciplina);
            try
            {
                _uow.Commit();
            }
            catch (DbUpdateException)
            {
                if (ProfessorDisciplinaExists(professorDisciplina.IdProfessor, professorDisciplina.IdDisciplina))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = professorDisciplina.IdDisciplina }, professorDisciplina);
        }

        // DELETE: api/ProfessorDisciplina/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int idProfessor, [FromRoute] int idDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorDisciplina = _professorDisciplinaService.GetByIds(idProfessor, idDisciplina);
            if (professorDisciplina == null)
            {
                return NotFound();
            }

            _professorDisciplinaService.Delete(professorDisciplina.IdProfessor, professorDisciplina.IdDisciplina);
            _uow.Commit();

            return Ok(professorDisciplina);
        }

        private bool ProfessorDisciplinaExists(int idProfessor, int idDisciplina)
        {
            return _professorDisciplinaService.GetByIds(idProfessor, idDisciplina) == null ? false : true;
        }
    }
}