using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAlumnos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWCFAlumnos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWCFAlumnos
    {
        [OperationContract]
        AportacionesIMSS CalcularIMSS(int id);
        [OperationContract]
        ItemTablaISR CalcularISR(int id);
    }

    [DataContract]
    public class AportacionesIMSS
    {
        [DataMember]
        public decimal enfermedadMaternidad { get; set; }
        [DataMember]
        public decimal invalidezVida { get; set; }
        [DataMember]
        public decimal retiro { get; set; }
        [DataMember]
        public decimal cesantia { get; set; }
        [DataMember]
        public decimal infonavit { get; set; }

    }

    [DataContract]
    public class ItemTablaISR
    {
        [DataMember]
        public decimal limiteInferior { get; set; }
        [DataMember]
        public decimal limiteSuperior { get; set; }
        [DataMember]
        public decimal cuotaFija { get; set; }
        [DataMember]
        public decimal excedente { get; set; }
        [DataMember]
        public decimal subsidio  { get; set; }
        [DataMember]
        public decimal impuesto { get; set; }
    }

}
