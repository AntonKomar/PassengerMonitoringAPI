using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

namespace PassengersMonitoring.Module.Passengers.Application.Dto
{
    public class RouteDto
    {
        public Guid? Id { get; set; }

        public int RouteNumber { get; set; }

        public int OrderNumber { get; set; }

        //[Newtonsoft.Json.JsonProperty(PropertyName = "geometry", ItemConverterType = typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public CustomPoint Location { get; set; }

        public virtual List<VehicleDto> Vehicles { get; set; }
    }
}
