using System;
using Microsoft.Extensions.DependencyInjection;

namespace RandomStringGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string originalString = "";

            System.Console.WriteLine("The original string.");
            
            originalString = Console.ReadLine();

            // Loads all the dependencies of the application
            var serviceProvider = LoadServiceProvider();

            // Up front validates the request.
            var validatorResponse = ValidateRequest(originalString, serviceProvider);
            
            if (validatorResponse != null && validatorResponse.Success)
            {
                Console.WriteLine("====== Simple one line solution =========");
                var shuffleString = serviceProvider.GetService<IShuffleString>();
                var oneLinerSolution = shuffleString.OneLinerSimpleSolution(originalString);
                Utilities.PrintOutput(oneLinerSolution);

                Console.WriteLine("====== Using random solution =========");
                var randomSolution = shuffleString.UsingRandomSolution(originalString);
                Utilities.PrintOutput(randomSolution);

                Console.WriteLine("====== Thread safe Fisher yates solution =========");
                var threadSafeFisherYates = shuffleString.ThreadSafeUsingFisherYatesSolution(originalString);
                Utilities.PrintOutput(threadSafeFisherYates);
            }
            else
            {
                Utilities.PrintOutput(validatorResponse);
            }
            System.Console.ReadKey();
            System.Console.WriteLine("Press any key to exit.");
                   
            
        }

        public static RequestValidatorResponse ValidateRequest(string original, ServiceProvider serviceProvider)
        {
            var requestValidator = serviceProvider.GetService<IRequestValidator>();
            var response = requestValidator.Validate(original);
            return response;
        }

        private static ServiceProvider LoadServiceProvider()
        {
            return new ServiceCollection()
                .AddScoped<IRequestValidator, RequestValidator>()
                .AddScoped<IShuffleString, ShuffleString>()
                .BuildServiceProvider();
        }

    }
}
