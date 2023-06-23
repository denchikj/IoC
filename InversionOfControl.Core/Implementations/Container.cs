using InversionOfControl.Core.Interfaces;

namespace InversionOfControl.Core.Implementations
{
    internal class Container : IContainer
    {
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        public TContract GetInstance<TContract>()
        {
            var service = GetService<TContract>();
            return (TContract)service.Instance;
        }

        private IService GetService<TContract>()
        {
            TypeVerifier.ThrowExceptionIfNotRegistered(_services, typeof(TContract));

            var obj = _services[typeof(TContract)];

            switch(obj.LifeTime)
            {
                case Enums.LifeTime.Transient:
                {
                    var contract = obj.Contract;
                    var implementation = obj.Implementation;
                    var instance = Resolve(typeof(TContract));
                    var lifeTime = obj.LifeTime;

                    return new Service(contract, implementation, instance, lifeTime);
                }
                case Enums.LifeTime.Singleton when !obj.InstanceInitialized:
                    obj.Instance = Resolve(typeof(TContract));
                    return obj;
                default:
                    return obj;
            }        
        }

        private object Resolve(Type contract)
        {
            var implementation = _services[contract].Implementation;
            var constructor = implementation.GetConstructors()[0];
            var constructorParams = constructor.GetParameters();

            if (constructorParams.Length == 0) 
                return Activator.CreateInstance(implementation);

            var parameters = new List<object>();

            foreach (var param in constructorParams)
                parameters.Add(Resolve(param.ParameterType));

            return constructor.Invoke(parameters.ToArray());
        }

        public void RegisterSingleton<TContract, TImplementation>()
        {
            TypeVerifier.ThrowExceptionIfAlreadyRegistered(_services, typeof(TContract));
            TypeVerifier.ThrowExceptionIfNotSubtype(typeof(TContract), typeof(TImplementation));

            _services[typeof(TContract)]
                = new Service(typeof(TContract), typeof(TImplementation), Enums.LifeTime.Singleton);
        }

        public void RegisterSingletonInstance<TContract, TImplementation>(TImplementation instance)
        {
            TypeVerifier.ThrowExceptionIfAlreadyRegistered(_services, typeof(TContract));
            TypeVerifier.ThrowExceptionIfNotSubtype(typeof(TContract), typeof(TImplementation));

            _services[typeof(TContract)] =
                new Service(typeof(TContract), typeof(TImplementation), instance, Enums.LifeTime.Singleton);
        }

        public void RegisterTransient<TContract, TImplementation>()
        {
            TypeVerifier.ThrowExceptionIfAlreadyRegistered(_services, typeof(TContract));
            TypeVerifier.ThrowExceptionIfNotSubtype(typeof(TContract), typeof(TImplementation));

            _services[typeof(TContract)] =
                new Service(typeof(TContract), typeof(TImplementation), Enums.LifeTime.Transient);
        }
    }
}