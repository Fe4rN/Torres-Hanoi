using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    // Clase Hanoi
    class Hanoi
    {
        private Pila ini, fin, aux;
        private int movimientos;

        public Hanoi(int n)
        {
            ini = new Pila("INI");
            fin = new Pila("FIN");
            aux = new Pila("AUX");

            for (int i = n; i >= 1; i--)
                ini.Push(new Disco(i)); // Ajustar orden inicial correctamente
        }

        private void MoverDisco(Pila origen, Pila destino)
        {
            if (!origen.IsEmpty() && (destino.IsEmpty() || origen.Top().Tamano < destino.Top().Tamano))
            {
                destino.Push(origen.Pop());
                movimientos++;
                Console.WriteLine($"\nSituación tras el movimiento {movimientos}");
                MostrarEstado();
            }
            else
            {
                throw new InvalidOperationException("Movimiento inválido: No se puede colocar un disco más grande sobre uno más pequeño.");
            }
        }

        public void ResolverRecursivo(int n, Pila origen, Pila destino, Pila auxiliar)
        {
            if (n == 1)
            {
                MoverDisco(origen, destino);
                return;
            }

            ResolverRecursivo(n - 1, origen, auxiliar, destino);
            MoverDisco(origen, destino);
            ResolverRecursivo(n - 1, auxiliar, destino, origen);
        }

        public void Resolver()
        {
            Console.WriteLine("\nSituación inicial");
            MostrarEstado();

            ResolverRecursivo(ini.Count, ini, fin, aux);

            Console.WriteLine("\nSituación final");
            MostrarEstado();
            Console.WriteLine($"Problema resuelto en {movimientos} movimientos.");
        }

        public void MostrarEstado()
        {
            ini.MostrarEstado();
            aux.MostrarEstado();
            fin.MostrarEstado();
            Console.WriteLine("----------------------");
        }
    }
}
