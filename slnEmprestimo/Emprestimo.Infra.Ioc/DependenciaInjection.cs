using Emprestimo.Application.Mapper;
using Emprestimo.Application.Servico;
using Emprestimo.Application.Servico.Interface;
using Emprestimo.Domain.Repositories;
using Emprestimo.Infra.Data.Context;
using Emprestimo.Infra.Data.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Emprestimo.Infra.Ioc
{
    public static class DependenciaInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmprestimoDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<IJogosRepositorio, JogosRepositorio>();
            services.AddScoped<IEmprestimosRepositorio,EmprestimoRepositorio>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPessoaServico, PessoaServico>();
            services.AddScoped<IJogosServico, JogosServico>();
            services.AddScoped<IEmprestimosServico, EmprestimosServico>();

            return services;
        }
    }
}
