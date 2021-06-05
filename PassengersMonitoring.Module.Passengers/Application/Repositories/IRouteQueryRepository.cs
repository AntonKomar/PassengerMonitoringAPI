using PassengersMonitoring.Module.Passengers.Application.Dto;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Repositories
{
    public interface IRouteQueryRepository
    {
        /// <summary>
        /// Gets all route points by route number.
        /// </summary>
        /// <param name="routeNumber">Route number of the route point.</param>
        /// <returns>An array of <see cref="RouteDto"/> entities.</returns>
        Task<RouteDto[]> GetByRouteNumberAsync(int routeNumber);

        /// <summary>
        /// Gets route point by id.
        /// </summary>
        /// <param name="id">Id of the partner.</param>
        /// <returns>An entity of <see cref="PartnerDto"/> class.</returns>
        Task<RouteDto> GetByIdAsync(Guid id);
    }
}
