using System;

namespace LabCompiladores1
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexp = Console.ReadLine();
            Scanner scanner = new Scanner(regexp);

            Token nextToken = scanner.GetToken();
            while(nextToken.Tag != TokenType.EOF)
            {
                nextToken = scanner.GetToken();
                Console.WriteLine("TOKEN: {0}, VALOR {1}",
                    nextToken.Tag,
                    nextToken.Value);
            }

            Console.ReadKey();
        }
    }
}
