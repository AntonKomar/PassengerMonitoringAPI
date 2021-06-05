using NetTopologySuite.Geometries;
using System;
using System.Xml.Serialization;

namespace PassengersMonitoring.Model.Entities
{
    public class Stop : EntityBase
    {
        public Guid VehicleId { get; set; }

        public int PassengersNumber { get; set; }

        public DateTime Timestamp { get; set; }

        public Point Location { get; set; }
    }
}
