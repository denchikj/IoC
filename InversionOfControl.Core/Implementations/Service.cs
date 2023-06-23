using InversionOfControl.Core.Enums;
using InversionOfControl.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl.Core.Implementations
{
    public class Service : IService
    {
        public Service(Type contract, Type implementation, LifeTime lifeTime)
        {
            Contract = contract;
            Implementation = implementation;
            LifeTime = lifeTime;
        }

        public Service(Type contract, Type implementation, object instance, LifeTime lifeTime)
        {
            Contract = contract;
            Implementation = implementation;
            LifeTime = lifeTime;
            Instance = instance;
        }

        public Type Contract { get; }

        public Type Implementation { get; }

        public LifeTime LifeTime { get; }

        public object Instance { get; set; }

        public bool InstanceInitialized => Instance != null;
    }
}
