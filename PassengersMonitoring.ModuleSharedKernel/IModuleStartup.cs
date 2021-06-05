using System;
using Microsoft.Extensions.DependencyInjection;

namespace PassengersMonitoring.ModuleSharedKernel
{
    public interface IModuleStartup
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IServiceProvider serviceProvider);
    }
}