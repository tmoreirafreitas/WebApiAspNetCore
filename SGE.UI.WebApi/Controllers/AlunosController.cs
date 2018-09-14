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
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IUnitOfWork _uow;

        public AlunosController(IAlunoService alunoService, IUnitOfWork unitOfWork)
        {
            _alunoService = alunoService;
            _uow = unitOfWork;
        }

        // GET: api/Alunos
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _alunoService.Get();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aluno = await _alunoService.Get(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.IdAluno)
            {
                return BadRequest();
            }

            _alunoService.Put(aluno);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _alunoService.Post(aluno);
            _uow.Commit();

            return CreatedAtAction("GetAluno", new { id = aluno.IdAluno }, aluno);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aluno = await _alunoService.Get(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _alunoService.Delete(aluno.IdAluno);
            _uow.Commit();

            return Ok(aluno);
        }

        private bool AlunoExists(int id)
        {
            return _alunoService.Get(id).Result == null ? false : true;
        }
    }
}