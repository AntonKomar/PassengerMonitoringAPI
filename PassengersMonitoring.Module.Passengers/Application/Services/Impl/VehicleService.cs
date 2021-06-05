using AutoMapper;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Application.Dto;
using PassengersMonitoring.Module.Passengers.Application.Services.Abstr;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Application.Services.Impl
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = await _vehicleRepository.CreateAsync(_mapper.Map<Vehicle>(vehicleDto));
            return vehicle.Id;
        }

        public async Task DeleteVehicleAsync(Guid id)
        {
            await _vehicleRepository.DeleteAsync(id);
        }

        public async Task UpdateVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleDto.Id.Value);
            await _vehicleRepository.UpdateAsync(_mapper.Map(vehicleDto, vehicle));
        }
    }
}
