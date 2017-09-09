﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    interface IServiciosRuta
    {
        List<Ruta> GetRutas();

        void SaveRuta(Ruta ruta);

        void SaveRuta(List<Ruta> ruta);

        void UpdateRuta(Ruta ruta);

        bool DeleteRuta(Ruta ruta);
    }
}
