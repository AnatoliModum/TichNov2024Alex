using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    internal class saludo
    {
        public static string SaludarEstatico(string nombre)
        {
            return "oliwis estatico " + nombre;
        }

        public string SaludarNoEstatico(string nombre)
        {
            return "oliwis no estatico " + nombre;
        }

    }
}
