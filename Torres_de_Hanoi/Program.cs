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
            hanoi.Resolver();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
