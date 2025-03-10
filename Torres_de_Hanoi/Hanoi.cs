using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
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
                ini.Push(new Disco(i));
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

        public void ResolverIterativo()
        {
            Console.WriteLine("\nSituación inicial");
            MostrarEstado();

            int totalMovimientos = (int)Math.Pow(2, ini.Count) - 1;

            Pila[] palos;
            if (ini.Count % 2 == 0)
            {
                palos = new Pila[] { ini, fin, aux };
            }
            else
            {
                palos = new Pila[] { ini, aux, fin };
            }

            for (int i = 1; i <= totalMovimientos; i++)
            {
                int desde = (i & i - 1) % 3;
                int hacia = ((i | i - 1) + 1) % 3;

                MoverDisco(palos[desde], palos[hacia]);
            }

            Console.WriteLine($"Problema resuelto en {totalMovimientos} movimientos.");
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

            Console.WriteLine($"Problema resuelto en {movimientos} movimientos.");
        }

        public void ResolverR()
        {
            Console.WriteLine("\nSituación inicial");
            MostrarEstado();

            ResolverRecursivo(ini.Count, ini, fin, aux);
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
