using InversionOfControl.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl.Core.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Type of contract of an entity
        /// </summary>
        Type Contract { get; }

        /// <summary>
        /// Type of concrete implementation of Contract
        /// </summary>
        Type Implementation { get; }

        /// <summary>
        /// Lifetime of the service
        /// </summary>
        LifeTime LifeTime { get; }

        /// <summary>
        /// Concrete implementation of Contract
        /// </summary>
        object Instance { get; set; }

        /// <summary>
        /// Checks whenever instance is not null
        /// </summary>
        bool InstanceInitialized { get; }
    }
}
