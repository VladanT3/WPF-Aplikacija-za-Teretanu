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

namespace Teretana
{
    /// <summary>
    /// Interaction logic for RadnikHomePage.xaml
    /// </summary>
    public partial class RadnikHomePage : Window
    {
        FormOcitavanje formOcitavanje;
        FormProizvodi formProizvodi;
        FormPorudzbenica formPorudzbenica;
        FormRacuni formRacuni;
        public RadnikHomePage()
        {
            InitializeComponent();
        }

        private void btnOcitavanje_Click(object sender, RoutedEventArgs e)
        {
            formOcitavanje = new FormOcitavanje();
            formOcitavanje.Show();
        }

        private void btnProizvodi_Click(object sender, RoutedEventArgs e)
        {
            formProizvodi = new FormProizvodi();
            formProizvodi.Show();
        }

        private void btnPorudzbenica_Click(object sender, RoutedEventArgs e)
        {
            formPorudzbenica = new FormPorudzbenica();
            formPorudzbenica.Show();
        }

        private void btnRacuni_Click(object sender, RoutedEventArgs e)
        {
            formRacuni = new FormRacuni();
            formRacuni.Show();
        }

        private void menuLogOut_Click(object sender, RoutedEventArgs e)
        {
            Ulogovan.UlogovanRadnik = "";
            MainWindow main = new MainWindow();
            main.Show();
            formOcitavanje?.Close();
            formProizvodi?.Close();
            formPorudzbenica?.Close();
            formRacuni?.Close();
            Close();
        }
    }
}
