using System;
using CursoOnline.Dados.Contextos;
using CursoOnline.Dados.Repositorios;
using CursoOnline.Dominio;
using CursoOnline.Dominio.Entity.Base;
using CursoOnline.Dominio.Entity.Cursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoOnline.IoC
{
    public static class StartupIoC
    {
        public static void ConfigureSerbvices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LocalDB")));

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped<ICursoRepositorio, CursoRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ArmazenadorDeCurso>();
        }
    }
}
