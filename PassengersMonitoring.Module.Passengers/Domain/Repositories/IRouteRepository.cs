using PassengersMonitoring.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Domain.Repositories
{
    public interface IRouteRepository
    {
        /// <summary>
        /// Gets the route point by id.
        /// </summary>
        /// <param name="id">The route id.</param>
        /// <returns>An instance of <see cref="Route"/> entity.</returns>
        Task<Route> GetByIdAsync(Guid id);

        /// <summary>
        /// Creates new route point.
        /// </summary>
        /// <param name="route">The route point.</param>
        /// <returns>An instance of the <see cref="Route"/> entity.</returns>
        Task<Route> CreateAsync(Route route);

        /// <summary>
        /// Updates route point.
        /// </summary>
        /// <param name="route">The route point.</param>
        Task UpdateAsync(Route route);

        /// <summary>
        /// Deletes route point.
        /// </summary>
        /// <param name="id">The route point id.</param>
        Task DeleteAsync(Guid id);
    }
}
