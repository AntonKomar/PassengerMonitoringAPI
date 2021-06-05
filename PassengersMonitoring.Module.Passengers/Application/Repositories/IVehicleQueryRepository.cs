using PassengersMonitoring.Module.Passengers.Application.Dto;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Repositories
{
    public interface IVehicleQueryRepository
    {
        /// <summary>
        /// Gets all vehicles.
        /// </summary>
        /// <returns>An array of <see cref="VehicleDto"/> entities.</returns>
        Task<VehicleDto[]> GetAllAsync();

        /// <summary>
        /// Gets vehicle by id.
        /// </summary>
        /// <param name="id">Id of the vehicle.</param>
        /// <returns>An entity of <see cref="VehicleDto"/> class.</returns>
        Task<VehicleDto> GetByIdAsync(Guid id);
    }
}
