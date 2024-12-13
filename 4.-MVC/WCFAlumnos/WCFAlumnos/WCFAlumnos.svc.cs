using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entidades;
using Negocio;
using Datos;

namespace WCFAlumnos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFAlumnos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCFAlumnos.svc o WCFAlumnos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFAlumnos : IWCFAlumnos
    {
        public AportacionesIMSS CalcularIMSS(int id)
        {
            NAlumno nAlumno = new NAlumno();
            AportacionesIMSS apoIMSSWS = new AportacionesIMSS();
            Entidades.AportacionesIMSS apoIMSSDll = nAlumno.CalcularIMSS(id);

            apoIMSSWS.enfermedadMaternidad = apoIMSSDll.enfermedadMaternidad;
            apoIMSSWS.invalidezVida = apoIMSSDll.invalidezVida;
            apoIMSSWS.retiro = apoIMSSDll.retiro;
            apoIMSSWS.cesantia = apoIMSSDll.cesantia;
            apoIMSSWS.infonavit = apoIMSSDll.infonavit;

            return apoIMSSWS;
        }

        public ItemTablaISR CalcularISR(int id)
        {
            NAlumno negAlumno = new NAlumno();
            ItemTablaISR itISRWs = new ItemTablaISR();
            Entidades.ItemTablaISR itISRDLL = negAlumno.calcularisr(id);

            itISRWs.limiteInferior = itISRDLL.limiteInferior;
            itISRWs.limiteSuperior = itISRDLL.limiteSuperior;
            itISRWs.cuotaFija = itISRDLL.cuotaFija;
            itISRWs.excedente = itISRDLL.excedente;
            itISRWs.subsidio = itISRDLL.subsidio;
            itISRWs.impuesto = itISRDLL.ISR;

            return itISRWs;
        }

        public void DoWork()
        {
        }
    }
}
