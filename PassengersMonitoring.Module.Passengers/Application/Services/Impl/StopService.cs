using AutoMapper;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Application.Dto;
using PassengersMonitoring.Module.Passengers.Application.Services.Abstr;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Services.Impl
{
    public class StopService : IStopService
    {
        private readonly IStopRepository _stopRepository;
        private readonly IMapper _mapper;

        public StopService(
            IStopRepository stopRepository,
            IMapper mapper)
        {
            _stopRepository = stopRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateStopAsync(StopDto stopDto)
        {
            var route = await _stopRepository.CreateAsync(_mapper.Map<Stop>(stopDto));
            return route.Id;
        }
    }
}
