using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinhaApp.Infrastructure.DependencyInjection;
using MinhaApp.Api.DependencyInjection;
using MinhaApp.Application.Mapping;
using MinhaApp.Infrastructure.Persistence;
using MinhaApp.Domain.Entities;
using System.Linq;

namespace MinhaApp.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Registrar infra e serviços
            services.AddInfrastructureServices(Configuration);
            services.AddApiServices();

            // Registrar Mapster mappings
            MapsterConfig.RegisterMappings();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });

            // Seed minimal data for development (simple approach)
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MinhaAppDbContext>();
                if (!db.Categorias.Any())
                {
                    var cat = new CategoriaEntity("Exemplo Categoria");
                    cat.AdicionarProduto("Produto A");
                    cat.AdicionarProduto("Produto B");
                    db.Categorias.Add(cat);
                    db.SaveChanges();
                }
            }
        }
    }
}
