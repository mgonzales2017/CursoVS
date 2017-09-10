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
using UCV.Comun.ViewModel;

namespace UCV.UIClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel vm;

        public Login()
        {
            vm = new LoginViewModel();
            InitializeComponent();
            loginGrid.DataContext = vm;
            vm.Usuario = new Comun.Modelos.Usuario() { Username = "Usuario" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Login();
        }
    }
}
