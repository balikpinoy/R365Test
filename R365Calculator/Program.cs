using Microsoft.Extensions.DependencyInjection;
using System;

namespace R365Calculator
{
    class Program
    {
        private static IServiceProvider _calculatorServiceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            var service = _calculatorServiceProvider.GetService<ICalculator>();
            // get input from user
            Console.WriteLine("Enter First Number");
            string input = Console.ReadLine().ToString();

            Console.WriteLine("Enter Second Number");
            input += "," + Console.ReadLine().ToString();

            // do calculations
            var result = service.Add(input);

            Console.WriteLine(result.ToString());
            Console.ReadLine();

        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ICalculator, Calculator>();
            // ...
            // Add other services
            // ...
            _calculatorServiceProvider = collection.BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (_calculatorServiceProvider == null)
            {
                return;
            }
            if (_calculatorServiceProvider is IDisposable)
            {
                ((IDisposable)_calculatorServiceProvider).Dispose();
            }
        }
    }
}
