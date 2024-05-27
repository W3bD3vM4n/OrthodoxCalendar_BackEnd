using System;
using System.Collections.Generic;

namespace Calendario.Data.Models
{
    public partial class Repeticion
    {
        public Repeticion()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
