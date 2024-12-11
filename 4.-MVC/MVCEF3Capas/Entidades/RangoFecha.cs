using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel.DataAnnotations
{
    public class RangoFecha : ValidationAttribute
    {
        public RangoFecha(string fMinima, string fMaxima)
        {
            this.fMinima = DateTime.Parse( fMinima );
            this.fMaxima = DateTime.Parse( fMaxima );
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessage,name, fMinima.ToString("d"), fMaxima.ToString("d"));
        }
        public override bool IsValid(object value)
        {
            DateTime fIngre = (DateTime)value;
            return fIngre>=fMinima && fIngre<=fMaxima;
        }

        public DateTime fMinima { get; set; }
        public DateTime fMaxima { get; set; }
    }
}
