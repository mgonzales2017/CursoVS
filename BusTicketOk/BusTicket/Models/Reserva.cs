using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public class Reserva
    {
        private Localizacion destino;
        private Localizacion origen;
        private DateTime fecha;

        public Localizacion Destino
        {
            get
            {
                return destino;
            }
            set
            {
                destino = value;
            }
        }

        public Localizacion Origen
        {
            get
            {
                return origen;
            }
            set
            {
                origen = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

    }
}
