using UCV.Comun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;
using UCV.DataBaseAccess.Servicios.EntityContext;
using System.Transactions;
using static UCV.DataBaseAccess.Servicios.EntityContext.SQLContexto;

namespace Data.UCV.DataBaseAccess.Servicios
{


    public class ServicioCompania : IServiciosCompania
    {
        SQLContexto db;

        public ServicioCompania() {
            db = new SQLContexto();
        }

        public bool DeleteCompania(Compania compania)
        {
            var c = db.Companias.FirstOrDefault(g => g.Id == compania.Id);
            try
            {
                db.Companias.Remove(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<Compania> GetCompanias()
        {
            //SELECT * FROM Companias
            return db.Companias.ToList().Select(g=>new Compania {
                Id=g.Id,
                Ruc=g.Ruc,
                Calificacion= g.Calificacion
            }).ToList();

        }

        public List<Compania> GetCompanias(int calificacion)
        {
            return db.Companias.Where(g => g.Calificacion > calificacion).ToList();
        }

        public List<Compania> GetCompanias(string ruc)
        {
            return db.Companias.Where(g => g.Ruc.Contains(ruc)).ToList();
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
            //formas de hacer busqueda

            IEnumerable<Compania> collection = db.Companias.Where(g => g.Id == compania.Id);
            ////el primer elemento siempre
            //collection.FirstOrDefault();
            ////devuelve el unico elemento en la coleccion, si hay mas de uno           
            //collection.Single();

            ////Puede devolver un valor por defecto ya sea null o vacio
            //Compania c = db.Companias.FirstOrDefault(g => g.Id == compania.Id);
            ////arroja una excepcion si no hay ningun resultado o hay null

            //Compania single = db.Companias.Single(g => g.Id == compania.Id);

            Compania c = db.Companias.FirstOrDefault(g => g.Id == compania.Id);

            c.Ruc = compania.Ruc;
            c.Calificacion = compania.Calificacion;

            //recuperar un valor sin consulta
            //db.Entry(compania).State = System.Data.Entity.EntityState.Modified;
            //db.Entry(compania).CurrentValues();

            db.SaveChanges();

        }

        public void UpdateCompania(Guid companiaId, Compania compania) 
        {
            
        }

        public void UpdateCompania(Guid companiaId, string  ruc, int calificacion)
        {

        }
    }
}
