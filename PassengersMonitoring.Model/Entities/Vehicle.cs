using System.Collections.Generic;

namespace PassengersMonitoring.Model.Entities
{
    public class Vehicle : EntityBase
    {
        public int VehicleModel { get; set; }

        public int SitsNumber { get; set; }

        public int RouteNumber { get; set; }

        public virtual ICollection<Stop> StopsHistory { get; set; } = new HashSet<Stop>();
    }
}
