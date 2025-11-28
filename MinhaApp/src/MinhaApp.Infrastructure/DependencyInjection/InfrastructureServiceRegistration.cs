using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MinhaApp.Domain.Interfaces;
using MinhaApp.Infrastructure.Repositories;
using MinhaApp.Infrastructure.Persistence;

namespace MinhaApp.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExemploRepository, ExemploRepository>();
            services.AddScoped<MinhaApp.Domain.Interfaces.ICategoriaRepository, MinhaApp.Infrastructure.Repositories.CategoriaRepository>();
            services.AddScoped<MinhaApp.Domain.Interfaces.IProdutoRepository, MinhaApp.Infrastructure.Repositories.ProdutoRepository>();
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MinhaAppDbContext>(options =>
                options.UseSqlServer(conn));
        }
    }
}