using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PedidosPrueba.Core.Interfaces;
using PedidosPrueba.Core.Interfaces.Repositorios;
using PedidosPrueba.Core.Interfaces.Servicios;
using PedidosPrueba.Core.Servicios;
using PedidosPrueba.Infraestructure.Datos;
using PedidosPrueba.Infraestructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosPrueba.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen();

            // Base de datos.
            services.AddDbContext<PedidosPruebaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CadenaConexion")));

            // Inyección de dependencias.
            services.AddTransient<IPedidosServicio, PedidosServicio>();
            services.AddTransient<IPedidosRepositorio, PedidoRepositorio>();
            services.AddTransient<IUsuariosServicio, UsuariosServicio>();
            services.AddTransient<IUsuariosRepositorio, UsuariosRepositorio>();

            // Agregar configuración de los cors.
            AddCors(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Configuración de Swagger
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseCors("PedidosPrueba.Api");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddCors(IServiceCollection services)
        {
            List<string> strPermisoRest = new List<string>()
            {
                "GET", "POST", "PUT", "PATCH", "DELETE"
            };

            services.AddCors(options =>
            {
                options.AddPolicy("PedidosPrueba.Api", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .SetIsOriginAllowed(x => true)
                    .AllowAnyHeader()
                    .WithMethods(strPermisoRest.ToArray())
                    .AllowCredentials()
                    .Build());
            });
        }
    }
}