using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Management;
using System.Configuration;
using Newtonsoft.Json;

namespace Negocio
{
    public class NAlumno
    {
        //WSAlumno.WSAlumnosSoapClient _wsAlu = new WSAlumno.WSAlumnosSoapClient();
        DAlumno _controller = new DAlumno();
        public List<Alumno> Consultar() => _controller.Consultar();
        public Alumno Consultar(int id) => _controller.Consultar(id);
        public void Agregar(Alumno alumno) => _controller.Agregar(alumno);
        public void Actualizar(Alumno alumno) => _controller.Actualizar(alumno);
        public void Eliminar(int id) => _controller.Eliminar(id);
        //public ItemTablaISR CalcularIsr(int id)
        //{
        //    ItemTablaISR ISREntidad = new ItemTablaISR();

        //    try
        //    {
        //        WSAlumno.ItemTablaISR ISRService = _wsAlu.CalcularIsr(id);
        //        string json = JsonConvert.SerializeObject(ISRService);
        //        ISREntidad = JsonConvert.DeserializeObject<ItemTablaISR>(json);
        //    }
        //    catch(Exception ex)
        //    {
        //        List<ItemTablaISR> listIsr = _controller.ConsultarTablaISR();
        //        decimal sueldoQuincenal = Consultar(id).sueldo / 2;

        //        //ISREntidad = (ItemTablaISR)listIsr.Where(x => x.limiteInferior < sueldoQuincenal & x.limiteSuperior > sueldoQuincenal).First();

        //        var isrEntity = (from isrEnti in listIsr
        //                         where isrEnti.limiteInferior < sueldoQuincenal && isrEnti.limiteSuperior > sueldoQuincenal
        //                         select isrEnti).First();

        //        ISREntidad = isrEntity;

        //        ISREntidad.ISR = sueldoQuincenal - ISREntidad.limiteInferior;
        //        ISREntidad.ISR = (ISREntidad.ISR * ISREntidad.excedente) / 100;
        //        ISREntidad.ISR = ISREntidad.ISR + ISREntidad.cuotaFija;
        //        ISREntidad.ISR = ISREntidad.ISR - ISREntidad.subsidio;
        //    }

            

        //    return ISREntidad;
        //}
        public AportacionesIMSS CalcularIMSS(int id)
        {
            AportacionesIMSS apoIm = new AportacionesIMSS();

            try
            {
                //WSAlumno.AportacionesIMSS IMSSService = _wsAlu.CalcularIMSS(id);
                //string json = JsonConvert.SerializeObject(IMSSService);
                //apoIm = JsonConvert.DeserializeObject<AportacionesIMSS>(json);
            }
            catch (Exception ex)
            {
                decimal UMA = decimal.Parse(ConfigurationManager.AppSettings["UMA"]);
                decimal sueldo = Consultar(id).sueldo;

                apoIm.enfermedadMaternidad = (sueldo - (UMA * 3)) * decimal.Parse("0.04");
                apoIm.invalidezVida = (sueldo) * decimal.Parse("0.0625");
                apoIm.retiro = (sueldo) * decimal.Parse("0");
                apoIm.cesantia = (sueldo) * decimal.Parse("0.1125");
                apoIm.infonavit = (sueldo) * decimal.Parse("0");
            }

            //AportacionesIMSS entidadAportaciones = new AportacionesIMSS();
            //decimal UMA = decimal.Parse(ConfigurationManager.AppSettings["UMA"]);
            //decimal sueldo = Consultar(id).sueldo;

            //entidadAportaciones.enfermedadMaternidad = (sueldo - (UMA * 3)) * decimal.Parse("0.04");
            //entidadAportaciones.invalidezVida = (sueldo) * decimal.Parse("0.0625");
            //entidadAportaciones.retiro = (sueldo) * decimal.Parse("0");
            //entidadAportaciones.cesantia = (sueldo) * decimal.Parse("0.1125");
            //entidadAportaciones.infonavit = (sueldo) * decimal.Parse("0");

            return apoIm;
        }
    }
}
