using InversionOfControl.Entities.Implementations;
using FluentAssertions;
using InversionOfControl.Core.Interfaces;
using InversionOfControl.Core.Implementations;
using InversionOfControl.Entities.Interfaces;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class SingletonInstanceTest
    {
        [Test]
        public void Singleton_Instance_Test()
        {
            IBuilder builder = new Builder();
            
            builder.AddSingleton<IRandomNumber, RandomNumber>();
            
            var container = builder.Build();
           
            var random1 = container.GetInstance<IRandomNumber>();
            var random2 = container.GetInstance<IRandomNumber>();
            
            random1.GetRandomNumber().Should().Be(random2.GetRandomNumber());
            
            ReferenceEquals(random1, random2).Should().BeTrue();
        }
    }
}