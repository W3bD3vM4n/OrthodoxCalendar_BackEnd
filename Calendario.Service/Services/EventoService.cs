using Calendario.Data.Models;
using Calendario.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendario.Service.Services
{
    public class EventoService
    {
        // Dependency injection
        private readonly CalendarioDbContext _calendarioDbContext;

        public EventoService(CalendarioDbContext dbContext)
        {
            _calendarioDbContext = dbContext;
        }

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
                        Titulo = evento.Titulo,
                        FechaInicio = evento.FechaInicio,
                        FechaFin = evento.FechaFin,
                        Duracion = evento.Duracion,
                        Repeticion = evento.Repeticion.Nombre,
                        Detalles = evento.Detalles
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
                    Titulo = evento.Titulo,
                    FechaInicio = evento.FechaInicio,
                    FechaFin = evento.FechaFin,
                    Duracion = evento.Duracion,
                    Repeticion = evento.Repeticion.Nombre,
                    Detalles = evento.Detalles
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
                    Titulo = peticion.Titulo,
                    FechaInicio = peticion.FechaInicio,
                    FechaFin = peticion.FechaFin,
                    Duracion = peticion.Duracion,
                    RepeticionId = peticion.RepeticionId,
                    Detalles = peticion.Detalles
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

                evento.Titulo = peticion.Titulo;
                evento.FechaInicio = peticion.FechaInicio;
                evento.FechaFin = peticion.FechaFin;
                evento.Duracion = peticion.Duracion;
                evento.RepeticionId = peticion.RepeticionId;
                evento.Detalles = peticion.Detalles;

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
