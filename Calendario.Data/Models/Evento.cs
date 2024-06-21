﻿using System;
using System.Collections.Generic;

namespace Calendario.Data.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool? Duracion { get; set; }
        public int RepeticionId { get; set; }
        public string? DescripcionDia { get; set; }
        public string? TonoCantico { get; set; }
        public string? GuiaAyuno { get; set; }
        public string? FiestasLiturgicas { get; set; }
        public string? SantosCelebrados { get; set; }
        public string? GuiaLiturgia { get; set; }
        public string? LecturaDiariaEpistola { get; set; }
        public string? LecturaDiariaEvangelio { get; set; }
        public string? TituloIcono { get; set; }
        public string? DescripcionIcono { get; set; }

        public virtual Repeticion Repeticion { get; set; } = null!;
    }
}
