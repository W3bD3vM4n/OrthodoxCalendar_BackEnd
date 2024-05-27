﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calendario.Service.Dto
{
    public class EventoUpdateRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("fechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("fechaFin")]
        public DateTime FechaFin { get; set; }

        [JsonPropertyName("duracion")]
        public bool? Duracion { get; set; }

        [JsonPropertyName("repeticionId")]
        public int RepeticionId { get; set; }

        [JsonPropertyName("detalles")]
        public string? Detalles { get; set; }
    }
}
