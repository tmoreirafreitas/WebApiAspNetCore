using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGE.Domain.Entities;
using SGE.Infra.Data.Context;

namespace SGE.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorDisciplinaController : ControllerBase
    {
        private readonly SgeContext _context;

        public ProfessorDisciplinaController(SgeContext context)
        {
            _context = context;
        }

        // GET: api/ProfessorDisciplina
        [HttpGet]
        public IEnumerable<ProfessorDisciplina> GetProfessorDisciplinas()
        {
            return _context.ProfessorDisciplinas;
        }

        // GET: api/ProfessorDisciplina/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorDisciplina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorDisciplina = await _context.ProfessorDisciplinas.FindAsync(id);

            if (professorDisciplina == null)
            {
                return NotFound();
            }

            return Ok(professorDisciplina);
        }

        // PUT: api/ProfessorDisciplina/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessorDisciplina([FromRoute] int id, [FromBody] ProfessorDisciplina professorDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professorDisciplina.IdDisciplina)
            {
                return BadRequest();
            }

            _context.Entry(professorDisciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorDisciplinaExists(id))
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
        public async Task<IActionResult> PostProfessorDisciplina([FromBody] ProfessorDisciplina professorDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProfessorDisciplinas.Add(professorDisciplina);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfessorDisciplinaExists(professorDisciplina.IdDisciplina))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfessorDisciplina", new { id = professorDisciplina.IdDisciplina }, professorDisciplina);
        }

        // DELETE: api/ProfessorDisciplina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessorDisciplina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorDisciplina = await _context.ProfessorDisciplinas.FindAsync(id);
            if (professorDisciplina == null)
            {
                return NotFound();
            }

            _context.ProfessorDisciplinas.Remove(professorDisciplina);
            await _context.SaveChangesAsync();

            return Ok(professorDisciplina);
        }

        private bool ProfessorDisciplinaExists(int id)
        {
            return _context.ProfessorDisciplinas.Any(e => e.IdDisciplina == id);
        }
    }
}