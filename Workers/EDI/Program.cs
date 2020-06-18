using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using Microsoft.Extensions.Options;

namespace Workers.EDI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();                    
                    services.AddScoped<IScopedProcessingService,ScopedProcessingService>();                    
                    //services.AddDbContext<NFeContext>(options => options.UseNpgsql("Server=postgres;Port=5432;Database=postgres;User Id=postgres;Password=123;"));
                });
    }
}
