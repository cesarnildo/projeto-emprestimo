using AutoMapper;
using Emprestimo.Application.DTOs;
using Emprestimo.Application.DTOs.Validacao;
using Emprestimo.Application.Servico.Interface;
using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;

namespace Emprestimo.Application.Servico
{
    public class EmprestimosServico : IEmprestimosServico
    {
        private readonly IJogosRepositorio _jogosRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IEmprestimosRepositorio _emprestimosRepositorio;
        private readonly IMapper _mapper;

        public EmprestimosServico(
            IJogosRepositorio jogosRepositorio,
            IPessoaRepositorio pessoaRepositorio,
            IEmprestimosRepositorio emprestimosRepositorio,
            IMapper mapper)
        {
            _jogosRepositorio = jogosRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _emprestimosRepositorio = emprestimosRepositorio;
            _mapper = mapper;


        }
        public async Task<ResultServico<EmprestimosDTO>> IncluirAsync(EmprestimosDTO emprestimosDTO)
        {
            if (emprestimosDTO == null)
                return ResultServico.Fail<EmprestimosDTO>("Objeto deve ser informado!");

            var validate = new EmprestimosDTOValidacao().Validate(emprestimosDTO);
            if (!validate.IsValid)
                return ResultServico.RequestError<EmprestimosDTO>("Problemas de validação", validate);

            var idPessoa    = await _pessoaRepositorio.ObterIdPessoaAsync(emprestimosDTO.Nome);
            var idJogo      = await _jogosRepositorio.ObterIdJogoAsync(emprestimosDTO.Descricao);

            var emprestimo      = new Emprestimos(idPessoa, idJogo);
            var data            = await _emprestimosRepositorio.IncluirAsync(emprestimo);
            emprestimosDTO.Id   = data.Id;

            return ResultServico.Ok<EmprestimosDTO>(emprestimosDTO);

        }

        public async Task<ResultServico<DetalhesEmprestimosDTO>> ObterDetaheIdAsync(int id)
        {
           var emprestismo = await _emprestimosRepositorio.GetByIdAsync(id);
            if (emprestismo == null)
                return ResultServico.Fail<DetalhesEmprestimosDTO>("Compra não encontrada");

            return ResultServico.Ok(_mapper.Map<DetalhesEmprestimosDTO>(emprestismo));
        }

        public async Task<ResultServico<ICollection<DetalhesEmprestimosDTO>>> ObterDetalheAsync()
        {
            var emprestimos = await _emprestimosRepositorio.GetAllAsync();
            return ResultServico.Ok(_mapper.Map<ICollection<DetalhesEmprestimosDTO>>(emprestimos));
        }
    }
}
