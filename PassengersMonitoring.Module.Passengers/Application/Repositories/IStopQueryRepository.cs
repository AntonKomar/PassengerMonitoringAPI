using PassengersMonitoring.Module.Passengers.Application.Dto;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Repositories
{
    public interface IStopQueryRepository
    {
        /// <summary>
        /// Gets all stops for the vehicle.
        /// </summary>
        /// <param name="vehicleId">Vehicle id of the stop.</param>
        /// <returns>An array of <see cref="StopDto"/> entities.</returns>
        Task<StopDto[]> GetByVehicleIdAsync(Guid vehicleId);

        /// <summary>
        /// Gets stop by id.
        /// </summary>
        /// <param name="id">Id of the stop.</param>
        /// <returns>An entity of <see cref="StopDto"/> class.</returns>
        Task<StopDto> GetByIdAsync(Guid id);
    }
}
