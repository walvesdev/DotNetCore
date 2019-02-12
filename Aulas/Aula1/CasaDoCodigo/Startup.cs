using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.AcessoDados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            //Injeção de dependencias
            services.AddTransient<IPreencherDados, PreencherDados>();
            services.AddTransient<IProdutoDao, ProdutoDao>();

            //Fornece a StringConnetions ao DbContext
            services.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer("Server=localhost;Database=CasaDoCodigo;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{id?}");
            });
            //adicionar IServiceProvider como parametro no metodo Configure
            //Adiciona a verificação do entityframework em toda inicialização para verificar se existe as tabelas no BD, se naõ existir ele cria autamaticamente.
            //serviceProvider.GetService<ApplicationContext>()
            //    .Database
            //    .Migrate();
            serviceProvider.GetService<IPreencherDados>().InicializaDB();

        }
    }
}
