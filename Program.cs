using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Repro
{
    public class Dependency
    {
        private static Func<int, int> Identity { get; } = f => f;
        public Dependency(object param) { } // We need at least two constructors to get the desired failure
        public Dependency(string param) { }
    }

    class Program
    {
        private static Container Container { get; } = new Container();

        static void Main(string[] args)
        {
            Container.Populate(Enumerable.Empty<ServiceDescriptor>()); // Commenting out this line stops the exception
            Container.GetInstance<Dependency>();
        }
    }
}
