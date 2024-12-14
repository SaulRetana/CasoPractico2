using System.ComponentModel.DataAnnotations;

namespace EventCorp.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El usuario de registro es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre del usuario de registro no puede exceder los 100 caracteres.")]
        public string UsuarioRegistro { get; set; }
    }
}
