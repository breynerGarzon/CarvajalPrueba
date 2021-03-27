using System.ComponentModel.DataAnnotations;

namespace Carvajal.Prueba.Model.View
{
    public class UserView
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 5, ErrorMessage="El tamaño mínimo de la contraseña es de 5 carácteres y de máximo 12.")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "El mail suministrado es inválido por favor intente nuevamente.")]
        public string Mail { get; set; }
    }
}