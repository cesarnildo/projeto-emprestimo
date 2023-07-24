using Emprestimo.Application.DTOs;
using Emprestimo.Application.Servico.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServico _pessoaServico;
               
        public PessoaController(IPessoaServico pessoaServico)
        {
            _pessoaServico = pessoaServico;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PessoaDTO pessoaDTO)
        {
            var result = await _pessoaServico.IncluirAsync(pessoaDTO);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _pessoaServico.ObterAsync();
            if(result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _pessoaServico.ObterPorIdAsync(id);
            if(result.isSucesso)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpPut]
        public async Task<ActionResult> AlterarAsync([FromBody] PessoaDTO pessoaDTO)
        {
            var result = await _pessoaServico.AlterarAsync(pessoaDTO);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarAsync(int id)
        {
            var result = await _pessoaServico.DeletarAsync(id);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
