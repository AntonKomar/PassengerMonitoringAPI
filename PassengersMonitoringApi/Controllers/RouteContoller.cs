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
    public class RouteContoller : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IRouteQueryRepository _routeQueryRepository;

        public RouteContoller(
            IRouteQueryRepository routeQueryRepository,
            IRouteService routeService)
        {
            _routeService = routeService;
            _routeQueryRepository = routeQueryRepository;
        }

        [HttpGet("Number/{routeNumber}")]
        [ApiExplorerSettings(GroupName = ApiDefaults.RoutesGroupName)]
        [ProducesResponseType(typeof(RouteDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByRouteNumber(int routeNumber)
        {
            var route = await _routeQueryRepository.GetByRouteNumberAsync(routeNumber);

            return Ok(route);
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = ApiDefaults.RoutesGroupName)]
        [ProducesResponseType(typeof(RouteDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRouteById(Guid id)
        {
            var route = await _routeQueryRepository.GetByIdAsync(id);

            return Ok(route);
        }

        [HttpPost]
        [ApiExplorerSettings(GroupName = ApiDefaults.RoutesGroupName)]
        public async Task<IActionResult> CreateRoute([FromForm] RouteDto createRouteRequest)
        {
            await _routeService.CreateRouteAsync(createRouteRequest);

            return Ok();
        }

        [HttpPut]
        [ApiExplorerSettings(GroupName = ApiDefaults.RoutesGroupName)]
        public async Task<IActionResult> UpdateRouteById([FromForm] RouteDto updateRouteRequest)
        {
            await _routeService.UpdateRouteAsync(updateRouteRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(GroupName = ApiDefaults.RoutesGroupName)]
        public async Task<IActionResult> DeleteRouteById(Guid id)
        {
            await _routeService.DeleteRouteAsync(id);

            return Ok();
        }
    }
}
