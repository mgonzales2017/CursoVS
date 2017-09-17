using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Contextos;

namespace UCV.DatabaseAccess.Servicios
{
    public class ServicioReserva : IServiciosReserva
    {
        SqlBusContexto db;

        public ServicioReserva() {
            db = new SqlBusContexto();
        }

        public bool DeleteReserva(Reserva reserva)
        {
            var c = db.Reservas.FirstOrDefault(g => g.Id == reserva.Id);
            try
            {
                db.Reservas.Remove(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<bool> DeleteReservaAsync(Reserva reserva)
        {
            return Task.Run(() => { return DeleteReserva(reserva); });
        }

        public List<Reserva> GetReservas()
        {
            return db.Reservas.
                ToList().
                Select(g => new Reserva
                {
                    Id = g.Id,
                    Ruta = g.Ruta,
                    Usuario = g.Usuario,
                    Compania = g.Compania,
                    FechaReserva = g.FechaReserva
                }).ToList();
        }

        public void SaveReserva(Reserva reserva)
        {
            if (reserva.Usuario == null)
            {
                throw new NullReferenceException("El Usuario no puede ser nulo o vacio");
            }
            else if(reserva.Compania == null)
            {
                throw new NullReferenceException("La compania no puede ser nulo o vacio");
            }
            else if (reserva.Ruta == null)
            {
                throw new NullReferenceException("La Ruta no puede ser nulo o vacio");
            }

            reserva.Id = Guid.NewGuid();
            db.Reservas.Add(reserva);
            db.SaveChanges();
        }

        public void SaveReserva(List<Reserva> reserva)
        {
            // Validar si hay elementos vacios en la coleccion Linq Funcional/Extension
            var hayElementosVacios = reserva.Where(g => g == null ||
                                   g.Usuario == null ||
                                   g.Compania == null ||
                                   g.Ruta == null)
                            .Count() > 0;

            // Validar si hay elementos vacios en la coleccion Linq Clasico
            hayElementosVacios = (from g in reserva
                                  where g == null ||
                                        g.Usuario == null ||
                                        g.Compania == null ||
                                        g.Ruta == null
                                  select g).Count() > 0;
            if (hayElementosVacios)
            {
                throw new NullReferenceException("El usuario, ruta o compañia no pueden ser nulo o vacio");
            }
            // Recrear todos los valores con un ID nuevo Linq Funcional/Extension
            var data = reserva.Select(g => new Reserva
            {
                Id = Guid.NewGuid(),
                Ruta = g.Ruta,
                Usuario = g.Usuario,
                Compania = g.Compania,
                FechaReserva = g.FechaReserva
            });
            // Recrear todos los valores con un ID nuevo Linq Clasico
            data = from g in reserva
                   select new Reserva()
                   {
                       Id = Guid.NewGuid(),
                       Ruta = g.Ruta,
                       Usuario = g.Usuario,
                       Compania = g.Compania,
                       FechaReserva = g.FechaReserva
                   };
            db.Reservas.AddRange(data);
            db.SaveChanges();
        }

        public void UpdateReserva(Reserva reserva)
        {
            Reserva c = db.Reservas.FirstOrDefault(g => g.Id == reserva.Id);

            c.Usuario = reserva.Usuario;
            c.Ruta = reserva.Ruta;
            c.Compania = reserva.Compania;
            c.FechaReserva = reserva.FechaReserva;

            db.SaveChanges();
        }
    }
}
