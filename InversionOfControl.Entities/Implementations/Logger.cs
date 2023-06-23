using InversionOfControl.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl.Entities.Implementations
{
    public class Logger : ILogger
    {
        public string Log(string data) => $"This logger inserted new entry: {data}";
    }
}
