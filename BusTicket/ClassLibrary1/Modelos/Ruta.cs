﻿using System.Collections.Generic;

namespace UCV.Comun.Modelos
{
    public class Ruta:BaseClass
    {
        /// <summary>
        /// Informacion de la Unidad/Vehiculo
        /// </summary>
        public string Unidad { get; set; }

        /// <summary>
        /// Todas las estaciones en orden
        /// </summary>
        public List<KeyValuePair<int, string>> Paradas { get; set; }

        public Compania Compania { get; set; }



    }
}