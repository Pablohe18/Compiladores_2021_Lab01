using System;

namespace LabCompiladores1
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexp = Console.ReadLine();
            Scanner scanner = new Scanner(regexp);
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
