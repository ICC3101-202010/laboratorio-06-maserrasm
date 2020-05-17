using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6MSSM
{
    [Serializable]
    class Persona
    {
        public string nombre; public int rut; public string cargo;

        public Persona(string nombre, int rut, string cargo)
        {
            this.nombre = nombre; this.rut = rut; this.cargo = cargo; 
        }

    }
}
