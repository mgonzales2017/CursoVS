using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    public interface IServiciosViaje
    {
        List<Viaje> GetViajes();

        void SaveViaje(Viaje Viaje);

        void SaveViaje(List<Viaje> Viaje);

        void UpdateViaje(Viaje Viaje);

        bool DeleteViaje(Viaje Viaje);
    }
}
