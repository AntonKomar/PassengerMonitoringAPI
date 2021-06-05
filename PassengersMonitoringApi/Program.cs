using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using PassengersMonitoring.Module.Passengers;

namespace PassengersMonitoringApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PassengersMonitoringContext>();

                context.Database.Migrate();

                ReloadTypes(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ReloadTypes(PassengersMonitoringContext context)
        {
            using (var connection = (NpgsqlConnection)context.Database.GetDbConnection())
            {
                connection.Open();
                connection.ReloadTypes();
            }
        }
    }
}
