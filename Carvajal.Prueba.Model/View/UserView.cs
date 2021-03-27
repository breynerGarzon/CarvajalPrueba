// using System.ComponentModel.DataAnnotations;

namespace Carvajal.Prueba.Model.View
{
    public class UserView
    {
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        // [Required]
        // [Range(0D, (double)1, ErrorMessage = "La contraseñadebe de poseer una mínima cantidad de 8 carácteres.")]
        public string Password { get; set; }

        public string Mail { get; set; }
    }
}