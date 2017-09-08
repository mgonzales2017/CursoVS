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

            CargarEstaciones(Origen,5);
            CargarEstaciones(Destino,9);
            FechaViaje.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var origen = new Localizacion();
            var destino = new Localizacion();

            origen = estaciones[Origen.SelectedIndex];
            destino = estaciones[Destino.SelectedIndex];

            Reserva = new Reserva();
            Reserva.Ruta = new Rutas();

            Reserva.Ruta.Origen =  origen;
            Reserva.Ruta.Destino = destino;
            Reserva.Ruta.FechaInicio = (DateTime)FechaViaje.SelectedDate;
            
            BuscarViaje(Reserva);
        }

        public void BuscarViaje(Reserva reserva)
        {
            Rutas = ObtenerRutas();
            var query = from q in Rutas
                        where q.Destino.Ciudad.Equals(reserva.Ruta.Destino.Ciudad) &&
                        q.Origen.Ciudad.Equals(reserva.Ruta.Origen.Ciudad) &&
                        (reserva.Ruta.FechaInicio.ToString("dd/MM/yyyy").Equals(q.FechaInicio.ToString("dd/MM/yyyy")))
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

        private void btn_Comprar_Click(object sender, RoutedEventArgs e)
        {
            if (LVResultados.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Ruta para poder Reservar.","Reserva de Boletos",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else {
                Tab_Reservas.SelectedIndex = 1;
                dpk_FechaNac.SelectedDate = DateTime.Now;
            }
        }

        private void btn_ComprarBoleto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reserva.Cliente = new Cliente();
                string filepath = $"{ConfigurationSettings.AppSettings.Get("RutaDatos")}{txt_DNI.Text}_{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.xml";

                Reserva.Cliente.Dni = txt_DNI.Text;
                Reserva.Cliente.Nombre = txt_Nombre.Text;
                Reserva.Cliente.Apellido = txt_Apellidos.Text;
                Reserva.Cliente.FechaNacimiento = (DateTime)dpk_FechaNac.SelectedDate;
                Reserva.Cliente.Dni = txt_DNI.Text;
                if (rbl_Sexo.IsChecked.Value)
                {
                    Reserva.Cliente.Sexo = "M";
                }
                else
                {
                    Reserva.Cliente.Sexo = "F";
                }
                Reserva.Asiento = Convert.ToInt16(txt_Asiento.Text);
                Reserva.Costo = (float)Convert.ToDecimal(txt_Costo.Text);
                Reserva.Id = 1;
                Reserva.Estado = 1;

                IFormatter formatter = new SoapFormatter();
                FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                formatter.Serialize(fs, Reserva);
                fs.Close();
                MessageBox.Show("La compra del Boleto de Viaje se realizó correctamente.", "Compra de Ticket", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Compra de Ticket", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
