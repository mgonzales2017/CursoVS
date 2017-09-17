using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UCV.Comun.Modelos
{
    [DataContract]
    public abstract class BaseClass
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
    }
}
