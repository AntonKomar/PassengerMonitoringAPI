using System;
using System.Collections.Generic;

namespace PassengersMonitoring.Module.Passengers.Application.Dto
{
    public class VehicleDto
    {
        public Guid? Id { get; set; }

        public int VehicleModel { get; set; }

        public int SitsNumber { get; set; }

        public int RouteNumber { get; set; }
    }
}
