using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    public interface IServiciosCompania
    {
        List<Compania> GetCompanias();

        List<Compania> GetCompanias(int calificacion);

        List<Compania> GetCompanias(string ruc);

        void SaveCompania(Compania compania);

        void SaveCompania(List<Compania> compania);

        void UpdateCompania(Compania compania);

        bool DeleteCompania(Compania compania);
    }
}
