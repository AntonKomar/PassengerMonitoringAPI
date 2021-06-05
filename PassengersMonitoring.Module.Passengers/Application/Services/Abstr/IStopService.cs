using PassengersMonitoring.Module.Passengers.Application.Dto;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Services.Abstr
{
    public interface IStopService
    {
        /// <summary>
        /// Creates the stop by dto data.
        /// </summary>
        /// <param name="stopDto">The dto data.</param>
        Task<Guid> CreateStopAsync(StopDto stopDto);
    }
}
