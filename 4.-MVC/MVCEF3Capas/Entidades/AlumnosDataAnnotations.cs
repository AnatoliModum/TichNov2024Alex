using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Entidades
{
    public class AlumnosDataAnnotations
    {
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string nombre { get; set; }

        [DisplayName("Teléfono")]
        public string telefono { get; set; }

        [DisplayName("Primer Apellido")]
        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El primer apellido solo puede contener letras y espacios.")]
        public string primerApellido { get; set; }

        [DisplayName("Segundo Apellido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El segundo apellido solo puede contener letras y espacios.")]
        public string segundoApellido { get; set; }

        [DisplayName("Correo")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string correo { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "01-01-1990", "31-12-2000", ErrorMessage = "La fecha de nacimiento debe estar entre el {1} y el {2}.")]
        [RangoFecha("01-01-1990", "31-12-2000", ErrorMessage = "La fecha debe de estar entre {1} y {2}")]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Estado de nacimiento")]
        public int idEstadoOrigen { get; set; }
        [DisplayName("Estatus")]
        public int idEstatus { get; set; }

        [DisplayName("Curp")]
        [MaxLength(18, ErrorMessage = "Longitud máxima de {1}")]
        [MinLength(18, ErrorMessage = "Longitud minima de {1}")]
        [StringLength(18, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El CURP es obligatorio.")]
        [RegularExpression(@"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z0-9]{2}$", ErrorMessage = "El CURP no tiene un formato válido.")]
        public string curp { get; set; }

        [DisplayName("Sueldo")]
        [Range(10000, 40000, ErrorMessage = "El {0} debe estar entre 10,000 y 40,000 pesos.")]
        public decimal sueldo { get; set; }
    }
}
