using EventCorp.Validators.EventCorp.Validators;
using System.ComponentModel.DataAnnotations;

namespace EventCorp.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título del evento es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La categoría del evento es obligatoria.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "La fecha del evento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe ser una fecha válida.")]
        [FutureDateAttribute(ErrorMessage = "La fecha del evento no puede ser en el pasado.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora del evento es obligatoria.")]
        [DataType(DataType.Time, ErrorMessage = "La hora debe ser un valor válido.")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "La duración del evento es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser un valor positivo.")]
        public int Duracion { get; set; }

        [Required(ErrorMessage = "La ubicación del evento es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La ubicación no puede exceder los 200 caracteres.")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "El cupo máximo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El cupo máximo debe ser mayor que 0.")]
        public int CupoMaximo { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El usuario que registró el evento es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre del usuario de registro no puede exceder los 100 caracteres.")]
        public string UsuarioRegistro { get; set; }

        // Relación con la categoría
        public Categoria Categoria { get; set; }

        // Relación con las inscripciones
        public ICollection<Inscripcion> Inscripciones { get; set; }

    }
}
