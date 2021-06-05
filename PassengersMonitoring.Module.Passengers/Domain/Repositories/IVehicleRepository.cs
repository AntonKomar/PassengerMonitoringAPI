using PassengersMonitoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Domain.Repositories
{
    public interface IVehicleRepository
    {
        /// <summary>
        /// Gets the vehicle by id.
        /// </summary>
        /// <param name="id">The vehicle id.</param>
        /// <returns>An instance of <see cref="Vehicle"/> entity.</returns>
        Task<Vehicle> GetByIdAsync(Guid id);

        /// <summary>
        /// Creates new vehicle.
        /// </summary>
        /// <param name="partner">The vehicle.</param>
        /// <returns>An instance of the <see cref="Vehicle"/> entity.</returns>
        Task<Vehicle> CreateAsync(Vehicle partner);

        /// <summary>
        /// Updates vehicle.
        /// </summary>
        /// <param name="partner">The vehicle.</param>
        Task UpdateAsync(Vehicle partner);

        /// <summary>
        /// Deletes vehicle.
        /// </summary>
        /// <param name="id">The vehicle id.</param>
        Task DeleteAsync(Guid id);
    }
}
