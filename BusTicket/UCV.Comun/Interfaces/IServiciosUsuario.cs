using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    public interface IServiciosUsuario
    {
        List<Usuario> GetUsuarios();

        void SaveUsuario(Usuario Usuario);

        void SaveUsuario(List<Usuario> Usuario);

        void UpdateUsuario(Usuario Usuario);

        bool DeleteUsuario(Usuario Usuario);

        Usuario Login(Usuario usuario);
    }
}
