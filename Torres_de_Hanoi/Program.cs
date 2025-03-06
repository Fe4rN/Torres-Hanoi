using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    // Clase Principal Program
    class Program
    {
        static void Main()
        {
            Console.Write("Ingrese la cantidad de discos: ");
            int n = int.Parse(Console.ReadLine());
            Hanoi hanoi = new Hanoi(n);
            Console.Write("Indica I para Iterativo o R para Recursivo... ");
            string input = Console.ReadLine()?.Trim().ToUpper(); // Normaliza la entrada

            while (input != "I" && input != "R")
            {
                Console.WriteLine("Entrada no válida. Teclee R o I.");
                Console.WriteLine("Indica I para Iterativo o R para Recursivo... ");
                input = Console.ReadLine()?.Trim().ToUpper();
            }

            if (input == "I")
            {
                hanoi.ResolverIterativo();
            }
            else if (input == "R")
            {
                hanoi.ResolverR();
            }

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
