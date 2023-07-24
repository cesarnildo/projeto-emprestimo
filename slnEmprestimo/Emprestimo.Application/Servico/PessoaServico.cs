using AutoMapper;
using Emprestimo.Application.DTOs;
using Emprestimo.Application.DTOs.Validacao;
using Emprestimo.Application.Servico.Interface;
using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;

namespace Emprestimo.Application.Servico
{
    public class PessoaServico : IPessoaServico
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IMapper _mapper;
        public PessoaServico(IPessoaRepositorio pessoaRepositorio,IMapper mapper)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _mapper = mapper;
        }

        public async Task<ResultServico> AlterarAsync(PessoaDTO pessoaDTO)
        {
            if (pessoaDTO == null)
                return ResultServico.Fail("Objeto deve ser informado!");

            var validation = new PessoaDTOValidacao().Validate(pessoaDTO);
            if (!validation.IsValid)
                return ResultServico.RequestError<PessoaDTO>("Problema com a validação dos campos",validation);

            var pessoa = await _pessoaRepositorio.ObterIdAsync(pessoaDTO.Id);

            if (pessoa == null)
                return ResultServico.Fail("Pessoa não encontrada");

            pessoa = _mapper.Map<PessoaDTO, Pessoa>(pessoaDTO, pessoa);

            await _pessoaRepositorio.EditarAsync(pessoa);

            return ResultServico.Ok("Pessoa alterada com sucesso!");


        }

        public async Task<ResultServico> DeletarAsync(int id)
        {
            var pessoa = await _pessoaRepositorio.ObterIdAsync(id);

            if (pessoa == null)
                return ResultServico.Fail("Pessoa não encontrada");

            await _pessoaRepositorio.DeletarAsync(pessoa);

            return ResultServico.Ok("Pessoa excluída com sucessor");
        }

        public async Task<ResultServico<PessoaDTO>> IncluirAsync(PessoaDTO pessoaDTO)
        {
            if (pessoaDTO == null)
                return ResultServico.Fail<PessoaDTO>("Objeto deve ser informado");

            var result = new PessoaDTOValidacao().Validate(pessoaDTO);
            if (!result.IsValid)
                return ResultServico.RequestError<PessoaDTO>("Problemas de validação", result);

            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            var data = await _pessoaRepositorio.IncluirAsync(pessoa);
            return ResultServico.Ok<PessoaDTO>(_mapper.Map<PessoaDTO>(data));
        }

        public async Task<ResultServico<ICollection<PessoaDTO>>> ObterAsync()
        {
            var pessoa = await _pessoaRepositorio.ObterPessoasAsync();
            return ResultServico.Ok<ICollection<PessoaDTO>>(_mapper.Map<ICollection<PessoaDTO>>(pessoa));
        }

        public async Task<ResultServico<PessoaDTO>> ObterPorIdAsync(int id)
        {
            var pessoa = await _pessoaRepositorio.ObterIdAsync(id);
            if (pessoa == null)
                return ResultServico.Fail<PessoaDTO>("Pessoa não encontrada!");

            return ResultServico.Ok(_mapper.Map<PessoaDTO>(pessoa));
        }
    }
}
