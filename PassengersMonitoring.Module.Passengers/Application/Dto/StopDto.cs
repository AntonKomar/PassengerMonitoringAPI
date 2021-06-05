using NetTopologySuite.Geometries;
using System;
using System.Xml.Serialization;

namespace PassengersMonitoring.Module.Passengers.Application.Dto
{
    public class StopDto
    {
        public Guid? Id { get; set; }

        public Guid? VehicleId { get; set; }

        public int PassengersNumber { get; set; }

        public DateTime Timestamp { get; set; }

        //[Newtonsoft.Json.JsonProperty(PropertyName = "geometry", ItemConverterType = typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public CustomPoint Location { get; set; }
    }
}
