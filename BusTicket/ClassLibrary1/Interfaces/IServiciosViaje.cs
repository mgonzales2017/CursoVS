using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace ClassLibrary1.Interfaces
{
    interface IServiciosViaje
    {
        List<Viajes> GetViaje();

        void SaveViaje(Viajes viaje);

        void SaveViaje(List<Viajes> viaje);

        void UpdateViaje(Viajes viaje);

        bool DeleteViaje(Viajes viaje);
    }
}
