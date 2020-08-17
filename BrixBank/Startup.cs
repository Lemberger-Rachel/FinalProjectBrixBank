using BrixBank.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using BrixBank.Services.Interfaces;
using BrixBank.Data.Repositories;
using BrixBank.Services.Services;

namespace BrixBank
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

                //var connectionString = Configuration.GetConnectionString("DataContext");

                //services.AddDbContext<DataContext>(options => options.UseMySql(connectionString));
                //services.AddControllersWithViews();
            services.AddControllers();
            services.AddDbContext<BrixBankContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BrixBankContext")));
            services.AddScoped<IRuleService, RuleService>();
            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddSwaggerGen(setupAction =>
            //{
            //    setupAction.SwaggerDoc(
            //        "AccountOpenAPI",
            //        new Microsoft.OpenApi.Models.OpenApiInfo()
            //        {
            //            Title = "Account API",
            //            Version = "1"
            //        });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            //app.UseSwagger();
            //app.UseSwaggerUI(setupAction =>
            //{
            //    setupAction.SwaggerEndpoint(
            //        "/swagger/AccountOpenAPI/swagger.json",
            //        "Account API");
            //});
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
