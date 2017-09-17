using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UCV.Comun.Modelos;

namespace UCV.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompaniasService" in both code and config file together.
    [ServiceContract]
    public interface ICompaniasService
    {
        [OperationContract]
        List<Compania> GetCompanias();

        [OperationContract]
        List<Compania> GetCompaniasById(string id);

        [OperationContract]
        List<Compania> GetCompaniasByIdRuc(string id, string ruc);

        [OperationContract]
        List<Compania> GetCompaniasByIdCal(string id, string ruc, int calificacion);
        
        [OperationContract]
        void SaveCompania(Compania compania);

        [OperationContract]
        void UpdateCompania(Compania compania);

        [OperationContract]
        void DeleteCompania(Compania compania);
    }
}
