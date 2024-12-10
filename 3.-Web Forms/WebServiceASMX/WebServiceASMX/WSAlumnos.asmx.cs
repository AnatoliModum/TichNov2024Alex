using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Negocio;
using Entidades;
using Datos;

namespace WebServiceASMX
{
    /// <summary>
    /// Descripción breve de WSAlumnos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSAlumnos : System.Web.Services.WebService
    {

        [WebMethod]
        public AportacionesIMSS CalcularIMSS(int id)
        {
            AportacionesIMSS apo = new AportacionesIMSS();
            NAlumno negAlu = new NAlumno();
            apo = negAlu.CalcularIMSS(id);

            return apo;
        }

        [WebMethod]
        public ItemTablaISR CalcularIsr(int id)
        {
            ItemTablaISR apo = new ItemTablaISR();
            NAlumno negAlu = new NAlumno();
            apo = negAlu.CalcularIsr(id);

            return apo;
        }

    }
}
