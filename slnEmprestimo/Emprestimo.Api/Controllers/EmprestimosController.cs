using Emprestimo.Application.DTOs;
using Emprestimo.Application.Servico;
using Emprestimo.Application.Servico.Interface;
using Emprestimo.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {

        private readonly IEmprestimosServico _emprestimosServico;
        public EmprestimosController(IEmprestimosServico emprestimosServico)
        {
            _emprestimosServico = emprestimosServico;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] EmprestimosDTO emprestimosDTO)
        {

            try
            {
                var result = await _emprestimosServico.IncluirAsync(emprestimosDTO);
                if (result.isSucesso)
                    return Ok(result);

                return BadRequest(result);

            }
            catch (DomainValitationException ex)
            {
                var result = ResultServico.Fail(ex.Message);

                return BadRequest(result);
            }
           
        }

        [HttpGet]
        public async Task<ActionResult> ObterDetalheAsync()
        {
          
            var result = await _emprestimosServico.ObterDetalheAsync();
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {

            var result = await _emprestimosServico.ObterDetaheIdAsync(id);
            if (result.isSucesso)
                return Ok(result);

            return BadRequest(result);

        }


    }
}
