using PassengersMonitoring.ModuleSharedKernel;
using Microsoft.Extensions.DependencyInjection;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using PassengersMonitoring.Module.Passengers.Infrastructure.Repositories;
using PassengersMonitoring.Module.Passengers.Application.Repositories;
using PassengersMonitoring.Module.Passengers.Application.Services.Impl;
using PassengersMonitoring.Module.Passengers.Application.Services.Abstr;

namespace PassengersMonitoring.Module.Passengers
{
    public class PassengersModuleStartup : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<IStopRepository, StopRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IRouteQueryRepository, RouteQueryRepository>();
            services.AddTransient<IStopQueryRepository, StopQueryRepository>();
            services.AddTransient<IVehicleQueryRepository, VehicleQueryRepository>();
            services.AddTransient<IRouteService, RouteService>();
            services.AddTransient<IStopService, StopService>();
            services.AddTransient<IVehicleService, VehicleService>();
        }
    }
}