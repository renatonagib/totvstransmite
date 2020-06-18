using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using API_Portal.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.AspNetCore.Cors;

namespace API_Portal
{
    public class Startup
    {
         readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)

        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                //definir variaves para uso do cors. Ainda nao esta funcionado precisamos estudar 
                                var originHost = Environment.GetEnvironmentVariable("ORIGIN_HOST");
                                var destHost = Environment.GetEnvironmentVariable("ORIGIN_HOST");
                                Console.WriteLine("ORIGEM: " + originHost);
                                Console.WriteLine("DESTINO: " + destHost);
                                builder.WithOrigins("http://localhost:4200","http://localhost:8081");
                              });
            });



            //services.AddDbContext<NFeContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));            
            var host = Environment.GetEnvironmentVariable("DBHOST");
            services.AddDbContext<NFeContext>(options => options.UseNpgsql("Server=" + host +";Port=5432;Database=postgres;User Id=postgres;Password=123;"));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
