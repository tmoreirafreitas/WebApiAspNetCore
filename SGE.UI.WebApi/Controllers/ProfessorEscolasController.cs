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
    public class ProfessorEscolasController : ControllerBase
    {
        private readonly IProfessorEscolaService _professorEscolaService;
        private readonly IUnitOfWork _uow;

        public ProfessorEscolasController(IProfessorEscolaService professorEscolaService, IUnitOfWork uow)
        {
            _professorEscolaService = professorEscolaService;
            _uow = uow;
        }

        // GET: api/ProfessorEscolas
        [HttpGet]
        public IEnumerable<ProfessorEscola> Get()
        {
            return _professorEscolaService.Get();
        }

        // GET: api/ProfessorEscolas/5
        [HttpGet("{idEscola, idProfessor}")]
        public IActionResult Get([FromRoute] int idEscola, [FromRoute] int idProfessor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorEscola = _professorEscolaService.GetByIds(idProfessor, idEscola);

            if (professorEscola == null)
            {
                return NotFound();
            }

            return Ok(professorEscola);
        }

        // PUT: api/ProfessorEscolas/5
        [HttpPut("{idEscola, idProfessor}")]
        public IActionResult Put([FromRoute] int idEscola, 
            [FromRoute] int idProfessor,
            [FromBody] ProfessorEscola professorEscola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idEscola != professorEscola.IdEscola)
            {
                return BadRequest();
            }

            if (idProfessor != professorEscola.IdProfessor)
            {
                return BadRequest();
            }

            _professorEscolaService.Put(professorEscola);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorEscolaExists(idEscola, idProfessor))
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

        // POST: api/ProfessorEscolas
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorEscola professorEscola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _professorEscolaService.Post(professorEscola);
            try
            {
                _uow.Commit();
            }
            catch (DbUpdateException)
            {
                if (ProfessorEscolaExists(professorEscola.IdEscola, professorEscola.IdProfessor))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = professorEscola.IdEscola }, professorEscola);
        }

        // DELETE: api/ProfessorEscolas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorEscola = await _professorEscolaService.Get(id);
            if (professorEscola == null)
            {
                return NotFound();
            }

            _professorEscolaService.Delete(professorEscola.IdProfessor);
            _uow.Commit();

            return Ok(professorEscola);
        }

        private bool ProfessorEscolaExists(int idEscola, int IdProfessor)
        {
            return _professorEscolaService.GetByIds(IdProfessor, idEscola) == null ? false : true;
        }
    }
}