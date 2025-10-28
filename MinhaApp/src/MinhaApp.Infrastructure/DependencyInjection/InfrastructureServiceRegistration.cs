using Microsoft.Extensions.DependencyInjection;

namespace MinhaApp.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Adicione aqui os serviços da infraestrutura, como repositórios e contextos de banco de dados
            services.AddScoped<IExemploRepository, ExemploRepository>();
            services.AddDbContext<MinhaAppDbContext>(options =>
                options.UseSqlServer("sua_string_de_conexao_aqui"));
        }
    }
}