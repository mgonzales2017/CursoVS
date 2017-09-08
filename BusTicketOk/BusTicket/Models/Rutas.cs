using System;
using System.Runtime.Serialization;

namespace BusTicket.Models
{
    [Serializable]
    public class Rutas : ISerializable
    {
        public int Id { get; set; }
        public string Chofer { get; set; }
        public string Compania { get; set; }
        public Localizacion Origen { get; set; }
        public Localizacion Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public override string ToString()
        {
            return $"Ruta: {Origen.Ciudad} ({Origen.Estacion}) - {Destino.Ciudad} ({Destino.Estacion}) / Salida: {FechaInicio} - Llegada: {FechaFin} / Chofer: {Chofer} - Agencia: {Compania}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", Id, typeof(int));
            info.AddValue("chofer", Chofer, typeof(string));
            info.AddValue("compania", Compania, typeof(string));
            info.AddValue("origen", Origen, typeof(Localizacion));
            info.AddValue("destino", Destino, typeof(Localizacion));
            info.AddValue("fechainicio", FechaInicio, typeof(DateTime));
            info.AddValue("fechafin", FechaFin, typeof(DateTime));
        }

        public Rutas(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("id", typeof(int));
            Chofer = (string)info.GetValue("chofer", typeof(string));
            Compania = (string)info.GetValue("compania", typeof(string));
            Origen = (Localizacion)info.GetValue("origen", typeof(Localizacion));
            Destino = (Localizacion)info.GetValue("destino", typeof(Localizacion));
            FechaInicio = (DateTime)info.GetValue("fechainicio", typeof(DateTime));
            FechaFin = (DateTime)info.GetValue("fechafin", typeof(DateTime));
        }

        public Rutas() {

        }
    }
}
