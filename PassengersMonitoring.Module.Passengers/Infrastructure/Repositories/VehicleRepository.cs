using Microsoft.EntityFrameworkCore;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly PassengersMonitoringContext _context;

        public VehicleRepository(PassengersMonitoringContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            _context.Vehicle.Add(vehicle);

            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task DeleteAsync(Guid id)
        {
            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(p => p.Id == id);

            _context.Vehicle.Remove(vehicle);

            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> GetByIdAsync(Guid id)
        {
            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(p => p.Id == id);

            if (vehicle == null)
            {
                throw new Exception();
            }

            return vehicle;
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _context.Vehicle.Update(vehicle);

            await _context.SaveChangesAsync();
        }
    }
}
