using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UCV.Comun.Modelos;

namespace UCV.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservaService" in both code and config file together.
    [ServiceContract]
    public interface IReservaService
    {
        [OperationContract]
        List<Reserva> GetReservas();

        [OperationContract]
        List<Reserva> GetReservasById(string id);

        [OperationContract]
        List<Reserva> GetReservasByIdFecha(string id, DateTime fecha);

        [OperationContract]
        List<Reserva> GetReservaByIdFechaRuta(string id, DateTime fecha, Ruta ruta);

        [OperationContract]
        void SaveReserva(Reserva reserva);

        [OperationContract]
        void UpdateReserva(Reserva reserva);

        [OperationContract]
        void DeleteReserva(Reserva reserva);
    }
}
