using AutoMapper;
using Emprestimo.Application.DTOs;
using Emprestimo.Domain.Entities;

namespace Emprestimo.Application.Mapper
{
    public class DomainToDtoMapping: Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Pessoa, PessoaDTO>();
            CreateMap<Jogos, JogosDTO>();
            CreateMap<Emprestimos, DetalhesEmprestimosDTO>()
                .ForMember(x => x.Pessoa, opt => opt.Ignore())
                .ForMember(x => x.Jogo, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new DetalhesEmprestimosDTO
                    {
                        Jogo = model.Jogos.Descricao,
                        Id = model.Id,
                        Data = (DateTime)model.DtEntrega,
                        Pessoa = model.Pessoa.Nome
                    };
                    return dto;
                });

        }
    }
}
