using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sge.Service.Interfaces;
using Sge.Service.Service;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using SGE.Infra.Data.Repositories;
using SGE.Infra.Data.Repositories.UoW;

namespace Sge.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Services dependency
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEscolaService, EscolaService>();
            services.AddScoped<IProfessorDisciplinaService, ProfessorDisciplinaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IProfessorEscolaService, ProfessorEscolaService>();
            services.AddScoped<ITurmaDisciplinaService, TurmaDisciplinaService>();
            services.AddScoped<ITurmaEscolaService, TurmaEscolaService>();
            services.AddScoped<ITurmaService, TurmaService>();

            // Infra-Data dependency
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IProfessorDisciplinaRepository, ProfessorDisciplinaRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IProfessorEscolaRepository, ProfessorEscolaRepository>();
            services.AddScoped<ITurmaDisciplinaRepository, TurmaDisciplinaRepository>();
            services.AddScoped<ITurmaEscolaRepository, TurmaEscolaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SgeContext>();
        }
    }
}
