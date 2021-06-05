using System;
using System.Collections.Generic;
using System.Text;

namespace PassengersMonitoring.Model
{
    /// <summary>
    /// The base entity type
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// The id for each entity. This is the primary key for each entity.
        /// </summary>
        /// <example>1</example>
        Guid Id { get; set; }
    }
}
