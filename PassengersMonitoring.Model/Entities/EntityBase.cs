using System;

namespace PassengersMonitoring.Model.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
    }
}
