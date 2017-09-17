# LourtecVS


Hola clase!

Este es el repositorio de lo demos del profesor!


# 02/09/2017
# Modificaciones a hacer en la aplicacion de Tickets

1) Cambiar struct por class.
2) Generar rutas de viaje y Lugares de destino. Carguen los datos de un archivo XML, JSON, CSV.

###-------------------SET DE DATOS-------------------------------

        string Chofer { get; set; }
        public string Compania { get; set; }
        List<Localizacion> Estaciones -> 
                  string Estado { get; set; }
                  string Ciudad { get; set; }
                  string Pais { get; set; }
                  string Estacion { get; set; }
        Guid Id { get; set; }
        DateTime FechaInicio { get; set; }
        DateTime FechaFin { get; set; }
###--------------LAZY EJEMPLO -------------------------------

abcd, abcd company, { {a, b, c, d},{d,e,f,g} } , id, Fecha, Fecha


3) Guardar los datos en la base de datos. Pueden usar entity Framework
4) Mejorar el query de consulta de datos con LINQ.
5) Generar un ticket de compra. XML o JSON o CSV. 

