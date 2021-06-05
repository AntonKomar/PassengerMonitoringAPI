using Microsoft.Extensions.DependencyInjection;
using System;

namespace PassengersMonitoring.ModuleSharedKernel
{
    public abstract class ModuleBase : IModuleStartup
    {
        public abstract void ConfigureServices(IServiceCollection services);

        public void Configure(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                ConfigureModule(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Configure module here. No need to call base method
        /// </summary>
        protected virtual void ConfigureModule(IServiceProvider serviceProvider)
        {
        }
    }
}
