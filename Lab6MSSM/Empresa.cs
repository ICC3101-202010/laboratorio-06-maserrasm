using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab6MSSM
{
    [Serializable]
    class Empresa
    {
        public string nombre; public int rut; public List<Division> listaDivisiones;
        public Empresa(string name, int rutD)
        {
            this.nombre = name; this.rut = rutD; this.listaDivisiones = new List<Division>();
        }

       
    }
}
