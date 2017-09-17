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
using System.Windows.Shapes;

namespace UCV.UIClient
{
    /// <summary>
    /// Interaction logic for Reservas.xaml
    /// </summary>
    public partial class Reservas : Window
    {
        UCV.Reserva.ReservaServiceClient client = new UCV.Reserva.ReservaServiceClient();

        public Reservas()
        {
            InitializeComponent();
            ListaReservas.ItemsSource = client.GetReservas();
        }
    }
}
