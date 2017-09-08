using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    [Serializable]
    public class Cliente : ISerializable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }

        public Cliente(SerializationInfo info, StreamingContext context) {
            Id = (int)info.GetValue("id", typeof(int));
            Nombre = (string)info.GetValue("nombre", typeof(string));
            Apellido = (string)info.GetValue("apellido", typeof(string));
            Dni = (string)info.GetValue("dni", typeof(string));
            FechaNacimiento= (DateTime)info.GetValue("fechanacimiento", typeof(DateTime));
            Sexo = (string)info.GetValue("sexo", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", Id, typeof(int));
            info.AddValue("nombre", Nombre, typeof(string));
            info.AddValue("apellido", Apellido, typeof(string));
            info.AddValue("dni", Dni, typeof(string));
            info.AddValue("fechanacimiento", FechaNacimiento, typeof(DateTime));
            info.AddValue("sexo", Sexo, typeof(string));
        }

        public Cliente() {

        }
    }
}
