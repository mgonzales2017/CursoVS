using BusTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public List<Localizacion> Estaciones { get; set; }
        public MainWindow()
        {
            Estaciones = new List<Localizacion>()
            {
                new Localizacion()
                {
                    Ciudad = "Lima",
                    Estacion = "Lima Central",
                    Estado = "Lima",
                    Pais = "Peru",
                },
                new Localizacion()
                {
                    Ciudad = "Trujillo",
                    Estacion ="Central Trujillo",
                    Estado = "Trujillo",
                    Pais = "Peru",
                }
            };

            Reserva = new Reserva()
            {
                Destino = Estaciones[0],
                Salida = Estaciones[1],
                Fecha = DateTime.Now,
            };

            Rutas = new List<Models.Rutas>()
            {
                new Rutas()
                {
                    Chofer = "MC",
                    Compania = "L",
                    Estaciones = Estaciones,
                    FechaFin = DateTime.Now.AddDays(2),
                    FechaInicio = DateTime.Now,
                    Id = Guid.NewGuid(),
                },
                new Rutas()
                {
                    Chofer = "XYZ",
                    Compania = "Z",
                    Estaciones = Estaciones,
                    FechaFin = DateTime.Now.AddDays(12),
                    FechaInicio = DateTime.Now.AddDays(10),
                    Id = Guid.NewGuid(),
                }
            };

            InitializeComponent();

            Origen.ItemsSource = Estaciones;
            Origen.SelectedItem = Reserva.Salida;
            Destino.ItemsSource = Estaciones;
            Destino.SelectedItem = Reserva.Destino;
            DiaViaje.SelectedDate = Reserva.Fecha;
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
    }
}
