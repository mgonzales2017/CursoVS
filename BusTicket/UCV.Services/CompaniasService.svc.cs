using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Servicios;

namespace UCV.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompaniasService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompaniasService.svc or CompaniasService.svc.cs at the Solution Explorer and start debugging.
    public class CompaniasService : ICompaniasService
    {
        // Run sin debug, Ctrl + F5
        ServicioCompania dao = new ServicioCompania();

        public void DeleteCompania(Compania compania)
        {
            dao.DeleteCompania(compania);
        }

        public List<Compania> GetCompanias()
        {
            return dao.GetCompanias();
        }

        public void SaveCompania(Compania compania)
        {
            dao.SaveCompania(compania);
        }

        public void UpdateCompania(Compania compania)
        {
            dao.UpdateCompania(compania);
        }
    }
}
