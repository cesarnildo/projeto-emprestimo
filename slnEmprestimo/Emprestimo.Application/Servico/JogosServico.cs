using AutoMapper;
using Emprestimo.Application.DTOs;
using Emprestimo.Application.DTOs.Validacao;
using Emprestimo.Application.Servico.Interface;
using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;

namespace Emprestimo.Application.Servico
{
    public class JogosServico : IJogosServico
    {
        private readonly IJogosRepositorio _jogosRepositorio;
        private readonly IMapper _mapper;


        public JogosServico(IJogosRepositorio jogosRepositorio, IMapper mapper)
        {
            _jogosRepositorio = jogosRepositorio;
            _mapper = mapper;
        }


        public async Task<ResultServico<JogosDTO>> InserirAsync(JogosDTO jogosDTO)
        {
            if (jogosDTO == null)
                return ResultServico.Fail<JogosDTO>("Objeto deve ser informado!");

            var reult = new JogosDTOValidacao().Validate(jogosDTO);
            if (!reult.IsValid)
                return ResultServico.RequestError<JogosDTO>("Problmemas na validação", reult);

            var jogo = _mapper.Map<Jogos>(jogosDTO);
            var data = await _jogosRepositorio.IncluirAsync(jogo);

            return ResultServico.Ok<JogosDTO>(_mapper.Map<JogosDTO>(data));

        }

        public async Task<ResultServico<ICollection<JogosDTO>>> ObterAsync()
        {
            var jogo = await _jogosRepositorio.ObterJogosAsync();
            return ResultServico.Ok<ICollection<JogosDTO>>(_mapper.Map<ICollection<JogosDTO>>(jogo));
        }

        public async Task<ResultServico<JogosDTO>> ObterPorIdAsync(int id)
        {
            var jogo = await _jogosRepositorio.ObterIdAsync(id);
            if (jogo == null)
                return ResultServico.Fail<JogosDTO>("jogo não encontrada!");

            return ResultServico.Ok(_mapper.Map<JogosDTO>(jogo));
        }

        public async Task<ResultServico> AlterarAsync(JogosDTO jogosDTO)
        {
            if (jogosDTO == null)
                return ResultServico.Fail("Objeto deve ser informado!");

            var validation = new JogosDTOValidacao().Validate(jogosDTO);
            if (!validation.IsValid)
                return ResultServico.RequestError("Problema com a validação dos campos", validation);

            var jogo = await _jogosRepositorio.ObterIdAsync(jogosDTO.Id);

            if (jogo == null)
                return ResultServico.Fail("Jogo não encontrada");

            jogo = _mapper.Map<JogosDTO, Jogos>(jogosDTO, jogo);

            await _jogosRepositorio.EditarAsync(jogo);

            return ResultServico.Ok("Jogo alterado com sucesso!");


        }

        public async Task<ResultServico> DeletarAsync(int id)
        {
            var jogo = await _jogosRepositorio.ObterIdAsync(id);

            if (jogo == null)
                return ResultServico.Fail("Jogo não encontrado!");

            await _jogosRepositorio.DeletarAsync(jogo);

            return ResultServico.Ok("Jogo excluído com sucessor");
        }
    }
}
