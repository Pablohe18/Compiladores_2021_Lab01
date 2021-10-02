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
            while (nextToken.Tag != TokenType.EOF)
            {
                Console.WriteLine("TOKEN: {0}, VALOR {1}",
                  nextToken.Tag,
                  nextToken.Value);
                nextToken = scanner.GetToken();
            }
            Parser parser = new Parser();
                if (parser.Parse(regexp))
                {
                    Console.WriteLine("ERROR DE ANALISIS SINTACTICO");
                }
                else
                {
                    Console.WriteLine("ANALISIS SINTACTICO CORRECTO");
                }

            Console.ReadKey();
        }
    }
}
