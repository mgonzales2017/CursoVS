using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    public interface IServiciosReserva
    {
        List<Reserva> GetReservas();

        void SaveReserva(Reserva Reserva);

        void SaveReserva(List<Reserva> Reserva);

        void UpdateReserva(Reserva Reserva);

        bool DeleteReserva(Reserva Reserva);
    }
}
