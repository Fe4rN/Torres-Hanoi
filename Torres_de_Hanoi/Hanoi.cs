using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    // Clase Hanoi
    class Hanoi
    {
        private Pila ini, fin, aux; //Declara que hay tres objetos de tipo Pila que son INI, AUX y FIN
        private int movimientos; //Declara una variable para contar los movimientos necesitados

        public Hanoi(int n) //Constructor que recibe la cantidad de discos con la que se va a operar
        {
            ini = new Pila("INI"); //Crea la pila INI
            fin = new Pila("FIN"); //Crea la pila FIN
            aux = new Pila("AUX"); //Crea la pila AUX

            for (int i = n; i >= 1; i--)
                ini.Push(new Disco(i)); //Por cada disco introducido como parametro de constructor, crea un disco y lo añade por encima a la pila INI
        }

        private void MoverDisco(Pila origen, Pila destino) //Mueve un disco desde y hasta las pilas introducidas
        {
            if (!origen.IsEmpty() && (destino.IsEmpty() || origen.Top().Tamano < destino.Top().Tamano)) //Si ni el origen ni el destino están vacios o el tamaño del disco a mover es menor que el primero del destino
            {
                destino.Push(origen.Pop()); //Añade al destino el primero del origen
                movimientos++; //Añade un movimiento a la cuenta
                Console.WriteLine($"\nSituación tras el movimiento {movimientos}"); 
                MostrarEstado(); //Imprime el resultado del movimiento
            }
            else
            {
                throw new InvalidOperationException("Movimiento inválido: No se puede colocar un disco más grande sobre uno más pequeño."); //Excepción por si hay un error
            }
        }

        public void ResolverRecursivo(int n, Pila origen, Pila destino, Pila auxiliar) //Resuelve el problema usando la recursión
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
