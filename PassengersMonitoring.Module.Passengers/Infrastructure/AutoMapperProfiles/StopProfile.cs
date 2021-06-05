using AutoMapper;
using NetTopologySuite.Geometries;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Application.Dto;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.AutoMapperProfiles
{
    public class StopProfile : Profile
    {
        public StopProfile()
        {
            CreateMap<Stop, StopDto>();
            CreateMap<StopDto, Stop>();

            CreateMap<CustomPoint, Point>();
            CreateMap<Point, CustomPoint>();        
        }
    }
}
