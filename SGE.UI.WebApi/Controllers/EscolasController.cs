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

namespace SGE.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolasController : ControllerBase
    {        
        private readonly IEscolaService _escolaService;
        private readonly IEnderecoService _enderecoService;
        private readonly IUnitOfWork _uow;

        public EscolasController(IEscolaService escolaService, 
            IEnderecoService enderecoService, 
            IUnitOfWork uow)
        {
            _uow = uow;
            _escolaService = escolaService;
            _enderecoService = enderecoService;
        }

        // GET: api/Escolas
        [HttpGet]
        public IEnumerable<Escola>Get()
        {
            return _escolaService.Get();
        }

        // GET: api/Escolas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var escola = await _escolaService.Get(id);

            if (escola == null)
            {
                return NotFound();
            }
            
            return Ok(escola);
        }

        // PUT: api/Escolas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escola.IdEscola)
            {
                return BadRequest();
            }

            _escolaService.Put(escola);

            try
            {
                var result = _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscolaExists(id))
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

        // POST: api/Escolas
        [HttpPost]
        public IActionResult Post([FromBody] Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var endereco = _enderecoService.Post(escola.Endereco);            
            escola.IdEndereco = endereco.IdEndereco;
            _escolaService.Post(escola);
            _uow.Commit();

            return CreatedAtAction("Get", new { id = escola.IdEscola }, escola);
        }

        // DELETE: api/Escolas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var escola = await _escolaService.Get(id);
            if (escola == null)
            {
                return NotFound();
            }

            _escolaService.Delete(escola.IdEscola);
            _uow.Commit();

            return Ok(escola);
        }

        private bool EscolaExists(int id)
        {
            return _escolaService.Get(id).Result == null ? false : true;
        }
    }
}