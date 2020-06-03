using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using InnovativeProduct.ApplicationServices.GetProductListUseCase;
using InnovativeProduct.ApplicationServices.Ports.Gateways.Database;
using InnovativeProduct.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using InnovativeProduct.ApplicationServices.Repositories;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using InnovativeProduct.WebService.InfrastructureServices.Gateways;

namespace InnovativeProduct.WebService 
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
            services.AddDbContext<ProductContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "InnovativeProduct.db")}")
            );

            services.AddScoped<IProductDatabaseGateway, ProductEFSqliteGateway>();

            services.AddScoped<DbProductRepository>();
            services.AddScoped<IReadOnlyProductRepository>(x => x.GetRequiredService<DbProductRepository>());
            services.AddScoped<IProductRepository>(x => x.GetRequiredService<DbProductRepository>());

            services.AddScoped<IGetProductListUseCase, GetProductListUseCase>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
