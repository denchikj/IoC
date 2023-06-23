using InversionOfControl.Core.Interfaces;

namespace InversionOfControl.Core.Implementations
{
    public class Builder : IBuilder
    {
        private readonly IContainer _container = new Container();
        public void AddSingleton<TContract, TImplementation>()
        {
            _container.RegisterSingleton<TContract, TImplementation>();
        }

        public void AddSingletonInstance<TContract, TImplementation>(TImplementation instance)
        {
            _container.RegisterSingletonInstance<TContract, TImplementation>(instance);
        }

        public void AddTransient<TContract, TImplementation>()
        {
            _container.RegisterTransient<TContract, TImplementation>();
        }

        public IContainer Build()
        {
            return _container;
        }
    }
}
