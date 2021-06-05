using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassengersMonitoring.Common;
using PassengersMonitoring.Module.Passengers.Application.Dto;
using PassengersMonitoring.Module.Passengers.Application.Repositories;
using PassengersMonitoring.Module.Passengers.Application.Services.Abstr;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoringApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {
        private readonly IStopService _stopService;
        private readonly IStopQueryRepository _stopQueryRepository;

        public StopController(
            IStopQueryRepository stopQueryRepository,
            IStopService stopService)
        {
            _stopService = stopService;
            _stopQueryRepository = stopQueryRepository;
        }

        [HttpGet("Vehicle/{id}")]
        [ApiExplorerSettings(GroupName = ApiDefaults.StopsGroupName)]
        [ProducesResponseType(typeof(StopDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByVehicleId(Guid id)
        {
            var stop = await _stopQueryRepository.GetByVehicleIdAsync(id);

            return Ok(stop);
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = ApiDefaults.StopsGroupName)]
        [ProducesResponseType(typeof(StopDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStopById(Guid id)
        {
            var stop = await _stopQueryRepository.GetByIdAsync(id);

            return Ok(stop);
        }

        [HttpPost]
        [ApiExplorerSettings(GroupName = ApiDefaults.StopsGroupName)]
        public async Task<IActionResult> CreateStop([FromForm] StopDto createStopRequest)
        {
            await _stopService.CreateStopAsync(createStopRequest);

            return Ok();
        }
    }
}
