using InversionOfControl.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl.Entities.Implementations
{
    public class RandomNumber : IRandomNumber
    {
        private readonly int _number;

        public RandomNumber()
        {
            var random = new Random();
            _number = random.Next();
        }

        public int GetRandomNumber()
        {
            return _number;
        }
    }
}
