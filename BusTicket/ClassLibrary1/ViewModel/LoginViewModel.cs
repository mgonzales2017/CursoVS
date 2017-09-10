using UCV.Comun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.ViewModel
{
    public class LoginViewModel
    {
        public Usuario Usuario { get; set; }

        private IServiciosUsuario ServiciosUsuarios { get; set; }

        public Usuario Login(string usuario, string password) {
            return new Usuario();
        }

        public Usuario Login()
        {
            var u = new Usuario()
            {
                Username = Usuario.Username,
                Password = Usuario.Password,
            };

            return u;
        }
    }
}
