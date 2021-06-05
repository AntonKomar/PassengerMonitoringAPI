using PassengersMonitoring.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Domain.Repositories
{
    public interface IStopRepository
    {
        /// <summary>
        /// Creates new stop.
        /// </summary>
        /// <param name="stop">The stop.</param>
        /// <returns>An instance of the <see cref="Stop"/> entity.</returns>
        Task<Stop> CreateAsync(Stop stop);
    }
}
