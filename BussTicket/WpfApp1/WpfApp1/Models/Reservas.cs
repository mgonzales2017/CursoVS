using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public struct Reservas
    {
        private Localizacion destino;
        private Localizacion salida;
        private DateTime fecha;

        public Localizacion Destino
        {
            get;set;
        }

        public Localizacion Salida
        {
            get; set;
        }

        public DateTime Fecha
        {
            get; set;
        }

    }
}
