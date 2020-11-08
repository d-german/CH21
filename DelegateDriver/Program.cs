using System;
using Microsoft.Extensions.DependencyInjection;

namespace DelegateDriver
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = ConfigureServiceProvider();

            Console.WriteLine(serviceProvider.GetService<MyAdderInterface>().Add(1, 1));
            Console.WriteLine(serviceProvider.GetService<MyAdderDelegate>().Add(1, 1));
        }

        private static ServiceProvider ConfigureServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAdder, Adder>()
                .AddSingleton<AdderDelegate>(Abc)
                .AddSingleton<MyAdderDelegate>()
                .AddSingleton<MyAdderInterface>()
                .BuildServiceProvider();
            return serviceProvider;
        }

        private static double Abc(double l, double r)
        {
            return l + r;
        }
    }
}
