using PassengersMonitoring.Model.Entities;
using PassengersMonitoring.Module.Passengers.Domain.Repositories;
using System.Threading.Tasks;

namespace PassengersMonitoring.Module.Passengers.Infrastructure.Repositories
{
    public class StopRepository : IStopRepository
    {
        private readonly PassengersMonitoringContext _context;

        public StopRepository(PassengersMonitoringContext context)
        {
            _context = context;
        }

        public async Task<Stop> CreateAsync(Stop stop)
        {
            _context.Stop.Add(stop);

            await _context.SaveChangesAsync();

            return stop;
        }
    }
}
