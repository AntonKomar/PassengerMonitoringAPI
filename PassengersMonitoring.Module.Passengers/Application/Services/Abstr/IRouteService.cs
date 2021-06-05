using PassengersMonitoring.Module.Passengers.Application.Dto;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Services.Abstr
{
    public interface IRouteService
    {
        /// <summary>
        /// Creates the route by dto data.
        /// </summary>
        /// <param name="routeDto">The dto data.</param>
        Task<Guid> CreateRouteAsync(RouteDto routeDto);

        /// <summary>
        /// Updates the route by dto data.
        /// </summary>
        /// <param name="routeDto">The dto data.</param>
        Task UpdateRouteAsync(RouteDto routeDto);

        /// <summary>
        /// Deletes the route by id.
        /// </summary>
        /// <param name="id">route id.</param>
        Task DeleteRouteAsync(Guid id);
    }
}
