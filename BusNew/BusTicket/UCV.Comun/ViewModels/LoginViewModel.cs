using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;

namespace UCV.Comun.ViewModels
{
    public class LoginViewModel
    {
        public Usuario Usuario { get; set; }

        public string ErrorMessage { get; set; }

        private IServiciosUsuario ServicioUsuarios { get; set; }

        public Usuario Login(string usuario, string password)
        {
            return new Usuario();
        }

        public Usuario Login()
        {
            var u = new Usuario()
            {
                Username = Usuario.Username,
                Password = Usuario.Password,
            };

            Usuario.Username = "Logged";
            Usuario.Password = "Logged";
            ErrorMessage = "Todo Bien";
            return u;
        }
    }
}
