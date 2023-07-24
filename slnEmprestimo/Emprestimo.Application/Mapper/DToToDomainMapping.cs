using AutoMapper;
using Emprestimo.Application.DTOs;
using Emprestimo.Domain.Entities;

namespace Emprestimo.Application.Mapper
{
    public class DToToDomainMapping: Profile
    {
        public DToToDomainMapping()
        {
            CreateMap<PessoaDTO, Pessoa>();
            CreateMap<JogosDTO, Jogos>();

        }
    }
}
