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
    public class StopQueryRepository : IStopQueryRepository
    {
        private readonly PassengersMonitoringContext _context;
        private readonly IMapper _mapper;

        public StopQueryRepository(PassengersMonitoringContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StopDto> GetByIdAsync(Guid id)
        {
            var stop = await _context.Stop
                .ProjectTo<StopDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);

            if (stop == null)
            {
                throw new Exception();
            }

            return stop;
        }

        public async Task<StopDto[]> GetByVehicleIdAsync(Guid vehicleId)
        {
            var stops = await _context.Stop
                .Where(p => p.VehicleId == vehicleId)
                .ProjectTo<StopDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToArrayAsync();

            return stops;
        }
    }
}
