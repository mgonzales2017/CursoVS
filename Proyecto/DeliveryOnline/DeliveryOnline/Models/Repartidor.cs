///////////////////////////////////////////////////////////
//  Repartidor.cs
//  Implementation of the Class Repartidor
//  Generated by Enterprise Architect
//  Created on:      30-Set.-2017 12:37:43
//  Original author: Enrique
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using DeliveryOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DeliveryOnline.Models {
    [Table("Repartidor")]
    public class Repartidor {

        private string cNombre;
        private int Id;
        private int nEstado;
        
        [ForeignKey("Tienda")]
        public int TiendaId { get; set; }

        public virtual Tienda Tienda { get; set; }

        public Repartidor() {

        }

        ~Repartidor() {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoId {
            get {
                return Id;
            }
            set {
                Id = value;
            }
        }

        public int Estado {
            get {
                return nEstado;
            }
            set {
                nEstado = value;
            }
        }

        [Required]
        [DisplayName("Nombres y Apellidos")]
		public string Nombre{
			get{
				return cNombre;
			}
			set{
				cNombre = value;
			}
		}

	}//end Repartidor

}//end namespace Models