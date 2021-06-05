using Microsoft.EntityFrameworkCore;
using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly PassengersMonitoringContext _context;

        public RouteRepository(PassengersMonitoringContext context)
        {
            _context = context;
        }

        public async Task<Route> CreateAsync(Route route)
        {
            _context.Route.Add(route);

            await _context.SaveChangesAsync();

            return route;
        }

        public async Task DeleteAsync(Guid id)
        {
            var route = await _context.Route
                .FirstOrDefaultAsync(p => p.Id == id);

            _context.Route.Remove(route);

            await _context.SaveChangesAsync();
        }

        public async Task<Route> GetByIdAsync(Guid id)
        {
            var route = await _context.Route.SingleOrDefaultAsync(p => p.Id == id);

            if (route == null)
            {
                throw new Exception();
            }

            return route;
        }

        public async Task UpdateAsync(Route route)
        {
            _context.Route.Update(route);

            await _context.SaveChangesAsync();
        }
    }
}
