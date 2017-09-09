using UCV.Comun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;
using UCV.DataBaseAccess.Servicios.EntityContext;

namespace Data.UCV.DataBaseAccess.Servicios
{
    

    public class ServicioCompania : IServiciosCompania
    {
        SQLContexto db;

        public ServicioCompania(){
            db = new SQLContexto();
        }

        public bool DeleteCompania(Compania compania)
        {
            throw new NotImplementedException();
        }

        public List<Compania> GetCompania()
        {
            //SELECT * FROM Companias
            return db.Companias.ToList();
        }

        public void SaveCompania(Compania Compania)
        {
            if (Compania.Ruc == null || Compania.Ruc == String.Empty) {
                throw new NullReferenceException("El RUC no puede ser nulo o vacío");
            }
            Compania.Id = Guid.NewGuid();
            db.Companias.Add(Compania);
            db.SaveChanges();
        }

        public void SaveCompania(List<Compania> companias)
        {
            // Validar si hay elementos vacios en la coleccion Linq Funcional/Extension
            var hayElementosVacios = companias.Where(g => g == null ||
                                   g.Ruc == null ||
                                   g.Ruc == String.Empty)
                            .Count() > 0;

            // Validar si hay elementos vacios en la coleccion Linq Clasico
            hayElementosVacios = (from g in companias
                                  where g == null ||
                                        g.Ruc == null ||
                                        g.Ruc == String.Empty
                                  select g).Count() > 0;
            if (hayElementosVacios)
            {
                throw new NullReferenceException("El Ruc no puede ser nulo o vacio");
            }
            // Recrear todos los valores con un ID nuevo Linq Funcional/Extension
            var data = companias.Select(g => new Compania
            {
                Id = Guid.NewGuid(),
                Ruc = g.Ruc,
                Calificacion = g.Calificacion
            });
            // Recrear todos los valores con un ID nuevo Linq Clasico
            data = from g in companias
                   select new Compania()
                   {
                       Id = Guid.NewGuid(),
                       Ruc = g.Ruc,
                       Calificacion = g.Calificacion,
                   };
            db.Companias.AddRange(data);
            db.SaveChanges();

        }

        public void UpdateCompania(Compania compania)
        {
            throw new NotImplementedException();
        }
    }
}
