using System;

namespace RandomStringGenerator
{
    public static class Utilities
    {
        public static void PrintOutput(BaseResponse response)
        {

            if (response.Success)
            {
                var randomStringResponse = (RandomStringResponse)response;
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"\n Generated Random String:{randomStringResponse.GeneratedRandomString}");
                Console.WriteLine("\n");
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Following Error in Random String Generator.\n");
                System.Console.WriteLine(response.Message);
            }
            System.Console.ForegroundColor = ConsoleColor.White;
           
        }
    }
}
