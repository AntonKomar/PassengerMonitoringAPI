using AutoMapper;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Application.Dto;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.AutoMapperProfiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteDto>();
            CreateMap<RouteDto, Route>();
        }
    }
}
