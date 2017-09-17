using System;

namespace UCV.Comun.Modelos
{
    public class Usuario : BaseClass
    {
        public string NombreCompleto { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}