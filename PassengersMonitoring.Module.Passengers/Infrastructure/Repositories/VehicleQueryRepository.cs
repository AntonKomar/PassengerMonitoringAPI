using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PassengersMonitoring.Module.Passengers.Application.Dto;
using PassengersMonitoring.Module.Passengers.Application.Repositories;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.Repositories
{
    public class VehicleQueryRepository : IVehicleQueryRepository
    {
        private readonly PassengersMonitoringContext _context;
        private readonly IMapper _mapper;

        public VehicleQueryRepository(PassengersMonitoringContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<VehicleDto[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleDto> GetByIdAsync(Guid id)
        {
            var vehicle = await _context.Vehicle
                .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);

            if (vehicle == null)
            {
                throw new Exception();
            }

            return vehicle;
        }
    }
}
