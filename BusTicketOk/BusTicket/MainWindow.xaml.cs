using Newtonsoft.Json;
using BusTicket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Configuration;

namespace BusTicket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Reserva Reserva { get; set; }
        public List<Rutas> Rutas { get; set; }
        public List<Rutas> Resultados { get; set; }

        public MainWindow()
        {
            //Rutas = new List<Models.Rutas>()
            //{
            //    new Rutas()
            //    {
            //        Chofer = "MC",
            //        Compania = "L",
            //        Estaciones = Estaciones,
            //        FechaFin = DateTime.Now.AddDays(2),
            //        FechaInicio = DateTime.Now,
            //        Id = Guid.NewGuid(),
            //    },
            //    new Rutas()
            //    {
            //        Chofer = "XYZ",
            //        Compania = "Z",
            //        Estaciones = Estaciones,
            //        FechaFin = DateTime.Now.AddDays(12),
            //        FechaInicio = DateTime.Now.AddDays(10),
            //        Id = Guid.NewGuid(),
            //    }
            //};

            InitializeComponent();

            CargarEstaciones(Origen,3);
            CargarEstaciones(Destino,5);
            DiaViaje.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BuscarViaje(Reserva);
        }

        public void BuscarViaje(Reserva reserva)
        {
            var query = from q in Rutas
                        where q.Estaciones.Contains(reserva.Destino) &&
                        q.Estaciones.Contains(reserva.Salida) &&
                        q.FechaInicio >= reserva.Fecha
                        select q;

            query = Rutas.Where(g => true).Select(g => g);
            Resultados = query.ToList();
            LVResultados.ItemsSource = Resultados;
        }

        public void CargarEstaciones(ComboBox control,int indice) {

            string filepath = ConfigurationSettings.AppSettings.Get("RutaDatos") + "Localizacion.JSON";
            IFormatter formatter = new SoapFormatter();
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
            string jsonStorage;
            using (StreamReader sr = new StreamReader(fs))
            {
                jsonStorage = sr.ReadToEnd();
            }
            var estaciones = JsonConvert.DeserializeObject<List<Localizacion>>(jsonStorage);
            control.ItemsSource = estaciones;
            control.SelectedIndex = indice;
            fs.Close();

        }
    }
}
