///////////////////////////////////////////////////////////
//  Usuario.cs
//  Implementation of the Class Persona
//  Generated by Enterprise Architect
//  Created on:      30-Set.-2017 12:37:43
//  Original author: Enrique Incio Ch
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
    public class Persona {

        private string cApellidos;
        private string cDireccion;
        private string cEmail;
        private string cFonoCelular;
        private string cNombre;
        private string cPassword;
        private string cUsuario;
        private int Id = 0;
        public DeliveryOnline.Models.TipoCliente m_TipoCliente;
        //public DeliveryOnline.Models.TiendaUsuario m_TiendaUsuario;
        public virtual ICollection<Tienda> Tiendas { get; set; }



        ~Persona() {

        }

        [Required]
        [DisplayName("Nombre-Usuario")]
        public string User {
            get {
                return cUsuario;
            }
            set {
                cUsuario = value;
            }
        }

        [Required]
        public string Apellidos {
            get {
                return cApellidos;
            }
            set {
                cApellidos = value;
            }
        }

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoId
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        [Required]
        public string Direccion {
            get {
                return cDireccion;
            }
            set {
                cDireccion = value;
            }
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{
			get{
				return cEmail;
			}
			set{
				cEmail = value;
			}
		}

        [Required]
        [DisplayName("Tel�fono/Celular")]
        public string FonoCelular{
			get{
				return cFonoCelular;
			}
			set{
				cFonoCelular = value;
			}
		}

        [Required]
        [DisplayName("Nombres")]
        public string Nombre{
			get{
				return cNombre;
			}
			set{
				cNombre = value;
			}
		}

        [Required]
        [DataType(DataType.Password)]
        public string Password{
			get{
				return cPassword;
			}
			set{
				cPassword = value;
			}
		}

	}//end Persona

}//end namespace Models