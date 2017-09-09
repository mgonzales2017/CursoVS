using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace ClassLibrary1.Interfaces
{
    interface IServiciosReserva
    {
        List<Reserva> GetReserva();

        void SaveReserva(Reserva reserva);

        void SaveReserva(List<Reserva> reserva);

        void UpdateReserva(Reserva reserva);

        bool DeleteReserva(Reserva reserva);
    }
}
