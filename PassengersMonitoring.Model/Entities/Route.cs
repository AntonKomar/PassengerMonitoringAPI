using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace PassengersMonitoring.Model.Entities
{
    public class Route : EntityBase
    {
        public int RouteNumber { get; set; }

        public int OrderNumber { get; set; }

        public Point Location { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
