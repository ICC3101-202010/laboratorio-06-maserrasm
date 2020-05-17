using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6MSSM
{

    [Serializable]
    class Seccion : Division
    {
        public Seccion(string nombre, Persona encargado) : base(nombre, encargado)
        {

        }
    }
}
