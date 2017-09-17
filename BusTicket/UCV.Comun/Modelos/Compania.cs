using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace UCV.Comun.Modelos
{
    [DataContract]
    public class Compania : BaseClass
    {
        [DataMember]
        public string Ruc { get; set; }

        [DataMember]
        public float Calificacion { get; set; }
    }
}