using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Servicios;

namespace UCV.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReservaService.svc or ReservaService.svc.cs at the Solution Explorer and start debugging.
    public class ReservaService : IReservaService
    {
        ServicioReserva dao = new ServicioReserva();

        public void DeleteReserva(Reserva reserva)
        {
            dao.DeleteReserva(reserva);
        }

        public List<Reserva> GetReservaByIdFechaRuta(string id, DateTime fecha, Ruta ruta)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> GetReservas()
        {
            return dao.GetReservas();
        }

        public List<Reserva> GetReservasById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> GetReservasByIdFecha(string id, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public void SaveReserva(Reserva reserva)
        {
            dao.SaveReserva(reserva);
        }

        public void UpdateReserva(Reserva reserva)
        {
            dao.UpdateReserva(reserva);
        }
    }
}
