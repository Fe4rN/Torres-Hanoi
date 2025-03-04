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
            int movimientos = hanoi.ResolverIterativo(n);
            Console.WriteLine($"Problema resuelto en {movimientos} movimientos.");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

}
