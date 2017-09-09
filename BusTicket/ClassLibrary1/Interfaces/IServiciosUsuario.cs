using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace ClassLibrary1.Interfaces
{
    interface IServiciosUsuario
    {
        List<Usuario> GetUsuario();

        void SaveUsuario(Usuario usuario);

        void SaveUsuario(List<Usuario> usuario);

        void UpdateUsuario(Usuario usuario);

        bool DeleteUsuario(Usuario usuario);
    }
}
