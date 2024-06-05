using Calendario.Data.Models;
using Calendario.Service.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendario.Service.Services
{
    public class EventoService
    {
        // Inyección de Dependecias
        private readonly CalendarioDbContext _calendarioDbContext;

        public EventoService(CalendarioDbContext dbContext)
        {
            _calendarioDbContext = dbContext;
        }

        // Traducir el día a Español
        CultureInfo culture = new System.Globalization.CultureInfo("es-ES");

        public List<EventoResponse> ObtenerTodos()
        {
            try
            {
                var eventos = _calendarioDbContext.Eventos.ToList();

                List<EventoResponse> eventoList = new List<EventoResponse>();

                foreach (var evento in eventos)
                {
                    eventoList.Add(new EventoResponse()
                    {
                        Id = evento.Id,
                        FechaInicio = evento.FechaInicio,
                        FechaFin = evento.FechaFin,
                        DiaCalendarioJuliano = evento.FechaInicio.AddDays(-13),
                        DiaCalendarioCivil = culture.DateTimeFormat.GetDayName(evento.FechaInicio.DayOfWeek).ToUpper(),
                        Duracion = evento.Duracion,
                        Repeticion = evento.Repeticion.Nombre,
                        DescripcionDia = evento.DescripcionDia,
                        TonoCantico = evento.TonoCantico,
                        GuiaAyuno = evento.GuiaAyuno,
                        FiestasLiturgicas = evento.FiestasLiturgicas,
                        SantosCelebrados = evento.SantosCelebrados,
                        GuiaLiturgia = evento.GuiaLiturgia,
                        LecturaDiariaEpistola = evento.LecturaDiariaEpistola,
                        LecturaDiariaEvangelio = evento.LecturaDiariaEvangelio
                    });
                }

                return eventoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EventoResponse ObtenerPorId(int id)
        {
            try
            {
                var evento = _calendarioDbContext.Eventos
                    .FirstOrDefault(x => x.Id == id);

                var eventoResponse = new EventoResponse()
                {
                    Id = evento.Id,
                    FechaInicio = evento.FechaInicio,
                    FechaFin = evento.FechaFin,
                    DiaCalendarioJuliano = evento.FechaInicio.AddDays(-13),
                    DiaCalendarioCivil = culture.DateTimeFormat.GetDayName(evento.FechaInicio.DayOfWeek).ToUpper(),
                    Duracion = evento.Duracion,
                    Repeticion = evento.Repeticion.Nombre,
                    DescripcionDia = evento.DescripcionDia,
                    TonoCantico = evento.TonoCantico,
                    GuiaAyuno = evento.GuiaAyuno,
                    FiestasLiturgicas = evento.FiestasLiturgicas,
                    SantosCelebrados = evento.SantosCelebrados,
                    GuiaLiturgia = evento.GuiaLiturgia,
                    LecturaDiariaEpistola = evento.LecturaDiariaEpistola,
                    LecturaDiariaEvangelio = evento.LecturaDiariaEvangelio
                };

                return eventoResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento Agregar(EventoCreateRequest peticion)
        {
            try
            {
                var evento = new Evento()
                {
                    FechaInicio = peticion.FechaInicio,
                    FechaFin = peticion.FechaFin,
                    Duracion = peticion.Duracion,
                    RepeticionId = peticion.RepeticionId,
                    DescripcionDia = peticion.DescripcionDia,
                    TonoCantico = peticion.TonoCantico,
                    GuiaAyuno = peticion.GuiaAyuno,
                    FiestasLiturgicas = peticion.FiestasLiturgicas,
                    SantosCelebrados = peticion.SantosCelebrados,
                    GuiaLiturgia = peticion.GuiaLiturgia,
                    LecturaDiariaEpistola = peticion.LecturaDiariaEpistola,
                    LecturaDiariaEvangelio = peticion.LecturaDiariaEvangelio
                };

                _calendarioDbContext.Eventos.Add(evento);
                _calendarioDbContext.SaveChanges();

                return evento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento Actualizar(EventoUpdateRequest peticion)
        {
            try
            {
                var evento = _calendarioDbContext.Eventos
                    .FirstOrDefault(x => x.Id == peticion.Id);
                
                evento.FechaInicio = peticion.FechaInicio;
                evento.FechaFin = peticion.FechaFin;
                evento.Duracion = peticion.Duracion;
                evento.RepeticionId = peticion.RepeticionId;
                evento.DescripcionDia = peticion.DescripcionDia;
                evento.TonoCantico = peticion.TonoCantico;
                evento.GuiaAyuno = peticion.GuiaAyuno;
                evento.FiestasLiturgicas = peticion.FiestasLiturgicas;
                evento.SantosCelebrados = peticion.SantosCelebrados;
                evento.GuiaLiturgia = peticion.GuiaLiturgia;
                evento.LecturaDiariaEpistola = peticion.LecturaDiariaEpistola;
                evento.LecturaDiariaEvangelio = peticion.LecturaDiariaEvangelio;

                _calendarioDbContext.SaveChanges();

                return evento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento? Eliminar(int id)
        {
            try
            {
                var evento = _calendarioDbContext.Eventos
                    .FirstOrDefault(x => x.Id == id);

                _calendarioDbContext.Remove(evento);
                _calendarioDbContext.SaveChanges();

                return evento;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
