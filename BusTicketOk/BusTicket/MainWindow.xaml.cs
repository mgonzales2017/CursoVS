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

        public List<Localizacion> estaciones;

        public MainWindow()
        {
            InitializeComponent();

            CargarEstaciones(Origen,3);
            CargarEstaciones(Destino,5);
            FechaViaje.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var reserva = new Reserva();
            var origen = new Localizacion();
            var destino = new Localizacion();

            origen = estaciones[Origen.SelectedIndex];
            destino = estaciones[Destino.SelectedIndex];

            reserva.Origen = origen;
            reserva.Destino = destino;
            reserva.Fecha = (DateTime)FechaViaje.SelectedDate;
            
            BuscarViaje(reserva);
        }

        public void BuscarViaje(Reserva reserva)
        {
            var rutas = ObtenerRutas();
            var query = from q in rutas
                        where q.Destino.Ciudad.Equals(reserva.Destino.Ciudad) &&
                        q.Origen.Ciudad.Equals(reserva.Origen.Ciudad) &&
                        (reserva.Fecha.ToString("dd/MM/yyyy").Equals(q.FechaInicio.ToString("dd/MM/yyyy")))
                        select q;

            //query = Rutas.Where(g => true).Select(g => g);
            Resultados = query.ToList();
            LVResultados.ItemsSource = Resultados;
        }

        public List<Rutas> ObtenerRutas() {
            string filepath = ConfigurationSettings.AppSettings.Get("RutaDatos") + "Rutas.JSON";
            IFormatter formatter = new SoapFormatter();
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
            string jsonStorage;
            using (StreamReader sr = new StreamReader(fs))
            {
                jsonStorage = sr.ReadToEnd();
            }
            var rutas = JsonConvert.DeserializeObject<List<Rutas>>(jsonStorage);
            fs.Close();
            return rutas;
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
            estaciones = JsonConvert.DeserializeObject<List<Localizacion>>(jsonStorage);
            control.ItemsSource = estaciones;
            control.SelectedIndex = indice;
            fs.Close();

        }
    }
}
