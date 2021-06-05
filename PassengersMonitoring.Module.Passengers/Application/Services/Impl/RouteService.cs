using AutoMapper;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Application.Dto;
using PassengersMonitoring.Module.Passengers.Application.Services.Abstr;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Services.Impl
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public RouteService(
            IRouteRepository routeRepository,
            IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateRouteAsync(RouteDto routeDto)
        {
            var route = await _routeRepository.CreateAsync(_mapper.Map<Route>(routeDto));
            return route.Id;
        }

        public async Task DeleteRouteAsync(Guid id)
        {
            await _routeRepository.DeleteAsync(id);
        }

        public async Task UpdateRouteAsync(RouteDto routeDto)
        {
            var route = await _routeRepository.GetByIdAsync(routeDto.Id.Value);
            await _routeRepository.UpdateAsync(_mapper.Map(routeDto, route));
        }
    }
}
