using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    // Clase Disco
    class Disco
    {
        public int Tamano { get; } //Getter del tamaño del disco
        public Disco(int tamano) => Tamano = tamano; //Constructor del disco
    }
}
