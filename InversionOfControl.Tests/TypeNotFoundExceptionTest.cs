using FluentAssertions;
using InversionOfControl.Core.Interfaces;
using InversionOfControl.Core.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Exceptions;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class TypeNotFoundExceptionTest
    {
        [Test]
        public void Type_Not_Found_Exception_Test()
        {
            IBuilder builder = new Builder();
            
            var container = builder.Build();

            Action act = () => container.GetInstance<ILogger>();

            act.Should().Throw<TypeNotRegisteredException>()
                .WithMessage($"Type {typeof(ILogger)} is not registered");
        }
    }
}