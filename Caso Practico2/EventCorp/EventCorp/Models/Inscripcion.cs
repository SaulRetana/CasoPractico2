using EventCorp.Validators.EventCorp.Validators;
using System.ComponentModel.DataAnnotations;

namespace EventCorp.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del evento es obligatorio.")]
        public int EventoId { get; set; }

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        // Relación con Evento
        [Required(ErrorMessage = "El evento es obligatorio.")]
        public Evento Evento { get; set; }

        // Relación con Usuario
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe ser válida.")]
        [FutureDateAttribute(ErrorMessage = "La fecha de inscripción no puede ser en el futuro.")]
        public DateTime FechaInscripcion { get; set; }
    }
}
