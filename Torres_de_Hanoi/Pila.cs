using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    class Pila
    {
        private Stack<Disco> discos = new Stack<Disco>(); 
        public string Nombre { get; } 

        public Pila(string nombre) => Nombre = nombre; 

        public void Push(Disco d)
        {
            if (discos.Count == 0 || d.Tamano < discos.Peek().Tamano) 
            {
                discos.Push(d); 
            }
            else
            {
                throw new InvalidOperationException("No se puede colocar un disco más grande sobre uno más pequeño."); 
            }
        }

        public Disco Pop() 
        {
            if (discos.Count > 0)
                return discos.Pop(); 
            throw new InvalidOperationException("No hay discos para mover."); 
        }

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
