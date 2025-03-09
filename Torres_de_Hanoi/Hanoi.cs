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

        public void ResolverIterativo()
        {
            Console.WriteLine("\nSituación inicial");
            MostrarEstado();

            int totalMovimientos = (int)Math.Pow(2, ini.Count) - 1; // Calcula la cantidad de movimientos (2^n - 1)

            Pila[] palos; //Crea las pilas
            if (ini.Count % 2 == 0) // Si el numero es par
            {
                palos = new Pila[] { ini, fin, aux }; //Si es par, las pilas van en ese orden (Dios sabe porque)
            }
            else
            {
                palos = new Pila[] { ini, aux, fin }; //Si es impar, las pilas van en ese orden
            }

            for (int i = 1; i <= totalMovimientos; i++) //Por cada movimiento
            {
                int desde = (i & i - 1) % 3; //Operaciones con bits para averiguar el origen
                int hacia = ((i | i - 1) + 1) % 3; //Operaciones con bits para averiguar el destino

                MoverDisco(palos[desde], palos[hacia]); //Mueve el disco
            }

            Console.WriteLine($"Problema resuelto en {totalMovimientos} movimientos.");
        }

        public void ResolverRecursivo(int n, Pila origen, Pila destino, Pila auxiliar) //Resuelve el problema llamandose a si mismo
        {
            if (n == 1) //Si la cantidad de discos en INI es 1
            {
                MoverDisco(origen, destino); //Simplemente lo mueve
                return;
            }

            ResolverRecursivo(n - 1, origen, auxiliar, destino);
            MoverDisco(origen, destino);
            ResolverRecursivo(n - 1, auxiliar, destino, origen);

            Console.WriteLine($"Problema resuelto en {movimientos} movimientos.");
        }

        public void ResolverR() //Llama al método recursivo
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
