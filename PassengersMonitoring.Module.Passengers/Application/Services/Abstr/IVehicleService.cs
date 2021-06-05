using PassengersMonitoring.Module.Passengers.Application.Dto;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Services.Abstr
{
    public interface IVehicleService
    {
        /// <summary>
        /// Creates the vehicle by dto data.
        /// </summary>
        /// <param name="vehicleDto">The dto data.</param>
        Task<Guid> CreateVehicleAsync(VehicleDto routeDto);

        /// <summary>
        /// Updates the vehicle by dto data.
        /// </summary>
        /// <param name="vehicleDto">The dto data.</param>
        Task UpdateVehicleAsync(VehicleDto vehicleDto);

        /// <summary>
        /// Deletes the vehicle by id.
        /// </summary>
        /// <param name="id">vehicle id.</param>
        Task DeleteVehicleAsync(Guid id);
    }
}
