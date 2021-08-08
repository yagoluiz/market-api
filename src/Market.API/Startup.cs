using Market.API.Extensions;
using Market.Domain.Interfaces.Repositories;
using Market.Domain.Interfaces.UnitOfWork;
using Market.Infra.Contexts;
using Market.Infra.Repositories;
using Market.Infra.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market.API", Version = "v1" });
            });

            AddDatabaseContext(services);
            AddRepositoriesScopes(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDbContextMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void AddDatabaseContext(IServiceCollection services)
        {
            services.AddDbContext<EntityContext>(options =>
                options.UseNpgsql(DatabaseConnectionString).UseSnakeCaseNamingConvention());
        }

        private void AddRepositoriesScopes(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStreetFairRepository, StreetFairRepository>();
        }
    }
}