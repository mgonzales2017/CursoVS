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
    /// Interaction logic for Companias.xaml
    /// </summary>
    public partial class Companias : Window
    {
        Proxy.CompaniasServiceClient client = new Proxy.CompaniasServiceClient();

        public Companias()
        {
            InitializeComponent();
            Lista.ItemsSource = client.GetCompanias();
        }

        public override async void BeginInit() {
            base.BeginInit();
            var z = await Task.Run(() => { return client.GetCompanias(); });
            Lista.ItemsSource = z;
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            //var col = client.GetCompanias().ToList();
            var col = await client.GetCompaniasAsync();
            col = col.Where(g => g.Ruc.Contains(Filtro.Text) && g.Ruc!=null).ToArray();
            Lista.ItemsSource = col;
            await Task.Delay(5000).ContinueWith(g => MessageBox.Show("Hola mundo", "Asincrono"));
            (sender as Button).IsEnabled = true;
        }
    }
}
