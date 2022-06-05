using Api.Gateway.Models.Clientes.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebClientBlazor.Models
{
    public class SignupViewModel
    {
        public PacienteCreateCommandView PacienteCreate { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Nombre de usuario no válido")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string RepetirPassword { get; set; }
    }

    public class PacienteCreateCommandView
    {
        [Required]
        [RegularExpression(@"\d{8}", ErrorMessage = "Número de DNI no válido")]
        public string Dni { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z ,.'-]+$", ErrorMessage = "Los nombres no son válidos")]
        public string Nombres { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z ,.'-]+$", ErrorMessage = "Los apellidos no son válidos")]
        public string Apellidos { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidDate(ErrorMessage = "La fecha de nacimiento no es válida")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"9\d{8}", ErrorMessage = "Formato de número no válido")]
        public string Celular { get; set; }

        public string Usuario_Id { get; set; }
        public bool Activo { get; set; }
    }

    public class ValidDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);

            if (date < DateTime.UtcNow)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
