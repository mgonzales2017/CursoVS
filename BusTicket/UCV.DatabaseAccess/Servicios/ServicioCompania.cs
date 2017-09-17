using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Contextos;

namespace UCV.DatabaseAccess.Servicios
{
    public class ServicioCompania : IServiciosCompania
    {
        // Linq References
        // http://linq101.nilzorblog.com/linq101-lambda.php
        // https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
        SqlBusContexto db;

        public ServicioCompania()
        {
            db = new SqlBusContexto();
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
            catch (Exception ex)
            {
                return false;
            }
        }

        

        public List<Compania> GetCompanias()
        {
            // SELECT * FROM Companias;
            return db.Companias.
                ToList().
                Select(g => new Compania
                {
                    Id = g.Id,
                    Calificacion =
                   g.Calificacion,
                    Ruc = g.Ruc
                }).
                ToList();
        }

        public List<Compania> GetCompanias(string ruc)
        {
            return db.Companias.Where(g => g.Ruc.Contains(ruc)).ToList();
        }

        public List<Compania> GetCompanias(string ruc, int calificacion)
        {
            return db.Companias.Where(g => g.Ruc.Contains(ruc) && g.Calificacion > calificacion).ToList();
        }

        public List<Compania> GetCompanias(int calificacion)
        {
            return db.Companias.Where(g => g.Calificacion > calificacion).ToList();
        }

        public Compania GetCompania(Guid id)
        {
            return db.Companias.FirstOrDefault(g => g.Id == id);
        }

        public void SaveCompania(Compania compania)
        {
            if (compania.Ruc == null || compania.Ruc == String.Empty)
            {
                throw new NullReferenceException("El Ruc no puede ser nulo o vacio");
            }
            compania.Id = Guid.NewGuid();
            db.Companias.Add(compania);
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
            // Una coleccion de resultados o una coleccion con 0 elementos.
            IEnumerable<Compania> collection = db.Companias.Where(g => g.Id == compania.Id).ToList();

            // El primer elemento siempre
            ///collection.FirstOrDefault();
            // Devuelve el unico elemento en una coleccion, si hay mas de uno falla
            ///collection.Single();

            // Single va a arrojar una exception si no hay ningun resultado o hay duplicidad.
            Compania single = db.Companias.Single(g => g.Id == compania.Id);

            // First or default puede devolver Un valor por defecto ya null o vacio.
            Compania c = db.Companias.FirstOrDefault(g => g.Id == compania.Id);

            c.Ruc = compania.Ruc;
            c.Calificacion = compania.Calificacion;

            db.SaveChanges();
        }
    }
}
