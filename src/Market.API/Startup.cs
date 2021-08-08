using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using Market.API.Extensions;
using Market.API.Middleware;
using Market.API.Services;
using Market.API.Services.Interfaces;
using Market.Domain.Interfaces.Repositories;
using Market.Domain.Interfaces.UnitOfWork;
using Market.Infra.Contexts;
using Market.Infra.Repositories;
using Market.Infra.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Market.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string DatabaseConnectionString =>
            $"Server={Configuration["DB_URL"]};Port={Configuration["DB_PORT"]};Database={Configuration["DB_NAME"]};User ID={Configuration["DB_USER"]};Password={Configuration["DB_USER_PASSWORD"]};Integrated Security=true;Pooling=true";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
            services.AddSwaggerGen(options =>
            {
                static string SetCustomSchemaIds(Type selector)
                {
                    var className = selector.Name;

                    if (className.EndsWith("ViewModel"))
                        className = className.Replace("ViewModel", string.Empty);
                    else if (className.Contains("`"))
                        className = className.Split('`')[0].Replace("ViewModel", string.Empty) +
                                    "_" +
                                    selector.GenericTypeArguments[0].Name.Replace("ViewModel", string.Empty);

                    return className;
                }

                options.CustomSchemaIds(SetCustomSchemaIds);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Market API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            AddDatabaseContext(services);
            AddRepositoriesScopes(services);
            AddServicesScopes(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDbContextMigration();
            app.UseDbContextSeedMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market.API v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(env).Invoke
            });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void AddDatabaseContext(IServiceCollection services)
        {
            services.AddDbContext<EntityContext>(options =>
                options.UseNpgsql(DatabaseConnectionString));
        }

        private void AddRepositoriesScopes(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStreetFairRepository, StreetFairRepository>();
        }

        private void AddServicesScopes(IServiceCollection services)
        {
            services.AddScoped<IStreetFairService, StreetFairService>();
        }
    }
}