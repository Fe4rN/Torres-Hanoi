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
            for (int i = n; i >= 1; i--) ini.Push(new Disco(i));
        }

        private void MoverDisco(Pila a, Pila b)
        {
            if (!a.IsEmpty() && (b.IsEmpty() || a.Top().Tamano < b.Top().Tamano))
            {
                b.Push(a.Pop());
            }
            else if (!b.IsEmpty() && (a.IsEmpty() || b.Top().Tamano < a.Top().Tamano))
            {
                a.Push(b.Pop());
            }
            movimientos++;
            MostrarEstado();
        }

        public int ResolverIterativo(int n)
        {
            int totalMovimientos = (int)Math.Pow(2, n) - 1;
            Pila[] palos = (n % 2 == 0) ? new Pila[] { ini, aux, fin } : new Pila[] { ini, fin, aux };

            for (int i = 1; i <= totalMovimientos; i++)
            {
                MoverDisco(palos[(i % 3)], palos[((i + 1) % 3)]);
            }
            return movimientos;
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
