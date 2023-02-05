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
    /// Interaction logic for KlijentHomePage.xaml
    /// </summary>
    public partial class KlijentHomePage : Window
    {
        FormClanarina formClanarina;
        FormProdavnica formProdavnica;
        FormNalog formNalog;
        public KlijentHomePage()
        {
            InitializeComponent();
        }

        private void btnClanarina_Click(object sender, RoutedEventArgs e)
        {
            formClanarina = new FormClanarina();
            formClanarina.Show();
        }

        private void btnProdavnica_Click(object sender, RoutedEventArgs e)
        {
            formProdavnica = new FormProdavnica();
            formProdavnica.Show();
        }

        private void btnNalog_Click(object sender, RoutedEventArgs e)
        {
            formNalog = new FormNalog();
            formNalog.khp = this;
            formNalog.Show();
        }

        private void menuLogOut_Click(object sender, RoutedEventArgs e)
        {
            Ulogovan.UlogovanKlijent = 0;
            MainWindow main = new MainWindow();
            main.Show();
            formClanarina?.Close();
            formProdavnica?.Close();
            formNalog?.Close();
            Close();
        }
    }
}
