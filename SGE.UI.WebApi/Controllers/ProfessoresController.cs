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
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IUnitOfWork _uow;

        public ProfessoresController(IProfessorService professorService, IUnitOfWork unitOfWork)
        {
            _professorService = professorService;
            _uow = unitOfWork;
        }

        // GET: api/Professores
        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return _professorService.Get();
        }

        // GET: api/Professores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _professorService.Get(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // PUT: api/Professores/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professor.IdProfessor)
            {
                return BadRequest();
            }

            _professorService.Put(professor);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professores
        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _professorService.Post(professor);

            return CreatedAtAction("Get", new { id = professor.IdProfessor }, professor);
        }

        // DELETE: api/Professores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _professorService.Get(id);
            if (professor == null)
            {
                return NotFound();
            }

            _professorService.Delete(professor.IdProfessor);
            _uow.Commit();

            return Ok(professor);
        }

        private bool ProfessorExists(int id)
        {
            return _professorService.Get(id) == null ? false : true;
        }
    }
}