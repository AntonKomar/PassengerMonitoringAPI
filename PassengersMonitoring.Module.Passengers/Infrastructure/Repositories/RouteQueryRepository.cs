using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PassengersMonitoring.Module.Passengers.Application.Dto;
using PassengersMonitoring.Module.Passengers.Application.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.Repositories
{
    public class RouteQueryRepository : IRouteQueryRepository
    {
        private readonly PassengersMonitoringContext _context;
        private readonly IMapper _mapper;

        public RouteQueryRepository(PassengersMonitoringContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RouteDto> GetByIdAsync(Guid id)
        {
            var route = await _context.Route
                .ProjectTo<RouteDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);

            if (route == null)
            {
                throw new Exception();
            }

            return route;
        }

        public async Task<RouteDto[]> GetByRouteNumberAsync(int routeNumber)
        {
            var route = await _context.Route
                .Where(p => p.RouteNumber == routeNumber)
                .ProjectTo<RouteDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToArrayAsync();

            return route;
        }
    }
}
