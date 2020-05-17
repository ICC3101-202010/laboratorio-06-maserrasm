using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6MSSM
{
    [Serializable]
    class Departamento : Division
    {
        public Departamento(string nombre, Persona encargado) : base(nombre, encargado)
        {

        }

    }
}

