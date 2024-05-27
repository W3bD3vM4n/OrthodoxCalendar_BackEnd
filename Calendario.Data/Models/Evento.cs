using System;
using System.Collections.Generic;

namespace Calendario.Data.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool? Duracion { get; set; }
        public int RepeticionId { get; set; }
        public string? Detalles { get; set; }

        public virtual Repeticion Repeticion { get; set; } = null!;
    }
}
