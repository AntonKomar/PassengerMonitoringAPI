using AutoMapper;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Application.Dto;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.AutoMapperProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
        }
    }
}
