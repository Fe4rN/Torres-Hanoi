using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    // Clase Pila (Palo)
    class Pila
    {
        private Stack<Disco> discos = new Stack<Disco>();
        public string Nombre { get; }

        public Pila(string nombre) => Nombre = nombre;

        public void Push(Disco d) => discos.Push(d);

        public Disco Pop() => discos.Pop();

        public Disco Top() => discos.Count > 0 ? discos.Peek() : null;

        public bool IsEmpty() => discos.Count == 0;

        public int Count => discos.Count;

        public void MostrarEstado()
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
