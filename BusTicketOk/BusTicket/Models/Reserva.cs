using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    [Serializable]
    public class Reserva : ISerializable
    {
        public int Id {get;set;}
        public Rutas Ruta{get;set;}
        public Cliente Cliente {get ;set ;}
        public int Asiento {get;set;}
        public float Costo {get;set;}
        public int Estado {get;set;}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", Id, typeof(int));
            info.AddValue("ruta", Ruta, typeof(Rutas));
            info.AddValue("cliente", Cliente, typeof(Cliente));
            info.AddValue("asiento", Asiento, typeof(int));
            info.AddValue("costo", Costo, typeof(float));
            info.AddValue("estado", Estado, typeof(int));
        }

        public Reserva(SerializationInfo info, StreamingContext context) {
            Id = (int)info.GetValue("id", typeof(int));
            Ruta = (Rutas)info.GetValue("ruta", typeof(Rutas));
            Cliente = (Cliente)info.GetValue("cliente", typeof(Cliente));
            Asiento = (int)info.GetValue("asiento", typeof(int));
            Costo= (float)info.GetValue("costo", typeof(string));
            Estado = (int)info.GetValue("estado", typeof(int));
        }

        public Reserva()
        {

        }
    }
}
