using InversionOfControl.Core.Interfaces;
using InversionOfControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl.Core.Implementations
{
    public static class TypeVerifier
    {
        public static void ThrowExceptionIfAlreadyRegistered(IReadOnlyDictionary<Type, IService> services, Type contract)
        {
            if (IsRegistered(services, contract))
                throw new TypeAlreadyRegisteredException($"Type {contract} is already registered");
        }

        public static void ThrowExceptionIfNotRegistered(IReadOnlyDictionary<Type, IService> services, Type contract)
        {
            if (!IsRegistered(services, contract))
                throw new TypeNotRegisteredException($"Type {contract} is not registered");
        }

        public static void ThrowExceptionIfNotSubtype(Type baseType, Type subType)
        {
            if (!IsSubtype(baseType, subType))
                throw new InvalidTypeException($"Type {subType} is not {baseType}");
        }

        private static bool IsRegistered(IReadOnlyDictionary<Type, IService> services, Type contract)
        {
            return services.ContainsKey(contract);
        }

        private static bool IsSubtype(Type baseType, Type subType)
        {
            return baseType.IsAssignableFrom(subType);
        }
    }
}
