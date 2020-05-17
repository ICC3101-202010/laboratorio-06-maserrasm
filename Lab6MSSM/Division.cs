using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6MSSM
{
    [Serializable]
    class Division
    {
        public string nombre;
        public List<Persona> personalDiv;
        public Persona encargado;
        public Division(string nombre, Persona encargado)
        {
            this.nombre = nombre; this.personalDiv = new List<Persona>(); this.encargado = encargado;
        }

        void showEmployees() {

            for (int i = 0; i < personalDiv.Count(); i++)
            {
                string stream = Convert.ToString(i) + ". " + personalDiv[i].nombre;
                Console.WriteLine(stream);
            }
        
        
        }


    }
}
