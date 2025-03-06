using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    class Pila
    {
        private Stack<Disco> discos = new Stack<Disco>(); //Pila que alamacena los objetos de clase Disco
        public string Nombre { get; } //Obtiene el nombre de la pila (INI,AUX o FIN)

        public Pila(string nombre) => Nombre = nombre; //Constructor de la Pila, que establece su nombre

        public void Push(Disco d)
        {
            if (discos.Count == 0 || d.Tamano < discos.Peek().Tamano) //Si no hay discos o el disco que intenta insertar es menor que el que hay debajo.
            {
                discos.Push(d); //Añade el disco a la pila por arriba
            }
            else
            {
                throw new InvalidOperationException("No se puede colocar un disco más grande sobre uno más pequeño."); //Lanza una excepción si es imposible
            }
        }

        public Disco Pop() 
        {
            if (discos.Count > 0)
                return discos.Pop(); //Quita y devuelve el primero de la pila (el menor)
            throw new InvalidOperationException("No hay discos para mover."); //Si no hay discos, lanza una excepción
        }

        public Disco Top() => discos.Count > 0 ? discos.Peek() : null; //Devuelve el primer disco

        public bool IsEmpty() => discos.Count == 0; //Devuelve true si la pila está vacía

        public int Count => discos.Count; //Devuelve la cantidad de discos que hay en la pila

        public void MostrarEstado() //Recorre los objetos Disco que hay en la pila y escribe en consola su tamaño
        {
            Console.Write($"{Nombre}: ");
            foreach (var disco in discos)
            {
                Console.Write(disco.Tamano + " ");
            }
            Console.WriteLine();
        }
    }
}
