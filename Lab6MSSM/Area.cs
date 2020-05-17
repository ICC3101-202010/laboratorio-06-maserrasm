using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6MSSM
{
    [Serializable]
    class Area : Division
    {
        public Area (string nombre, Persona encargado) : base(nombre, encargado)
        {
            
        }

    }
}
