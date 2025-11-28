using Microsoft.Extensions.DependencyInjection;
using MinhaApp.Application.Interfaces;
using MinhaApp.Application.Services;
using MinhaApp.Domain.Interfaces;
using MinhaApp.Infrastructure.Repositories;

namespace MinhaApp.Api.DependencyInjection
{
    public static class ApiServiceRegistration
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IExemploService, ExemploAppService>();
            services.AddScoped<MinhaApp.Application.Interfaces.ICategoriaService, MinhaApp.Application.Services.CategoriaAppService>();
            services.AddScoped<MinhaApp.Application.Interfaces.IProdutoService, MinhaApp.Application.Services.ProdutoAppService>();
        }
    }
}