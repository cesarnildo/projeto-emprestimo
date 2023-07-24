using Emprestimo.Application.DTOs;
using Emprestimo.Application.Servico;
using Emprestimo.Application.Servico.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private readonly IJogosServico _jogoServico;

        public JogosController(IJogosServico jogoServico)
        {
            _jogoServico = jogoServico;
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] JogosDTO jogosDTO)
        {
            var result = await _jogoServico.InserirAsync(jogosDTO);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _jogoServico.ObterAsync();
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _jogoServico.ObterPorIdAsync(id);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpPut]
        public async Task<ActionResult> AlterarAsync([FromBody] JogosDTO jogosDTO)
        {
            var result = await _jogoServico.AlterarAsync(jogosDTO);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletarAsync(int id)
        {
            var result = await _jogoServico.DeletarAsync(id);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);
        }


    }
}
