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
    /// Interaction logic for FormLogovanje.xaml
    /// </summary>
    public partial class FormLogovanje : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();
        public MainWindow main;

        public void Ulogovanje(string email, string sifra)
        {
            var proveraEmailRadnik = (from r in tdc.Radniks
                                      where r.Email == email
                                      select r).Count();
            var proveraEmailKlijent = (from k in tdc.Klijents
                                       where k.Email == email
                                       select k).Count();

            if (proveraEmailRadnik == 1)
                loginRadnik(email, sifra);
            else if (proveraEmailKlijent == 1)
                loginKlijent(email, sifra);
            else
                MessageBox.Show("Uneti email nije registrovan.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void loginRadnik(string email, string sifra)
        {
            var logIn = (from r in tdc.Radniks
                         where r.Email == email && r.Sifra == sifra
                         select r).Count();

            if(logIn == 1)
            {
                Radnik radnik = (from r in tdc.Radniks
                                 where r.Email == email && r.Sifra == sifra
                                 select r).Single();

                Ulogovan.UlogovanRadnik = radnik.RadnikID;

                MessageBox.Show("Uspesno logovanje.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

                RadnikHomePage rhp = new RadnikHomePage();
                rhp.Show();
                main.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Nije uneta dobra sifra.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void loginKlijent(string email, string sifra)
        {
            if(email == "/" && sifra == "/")
            {
                MessageBox.Show("Nije moguce iskoristiti nalog!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var logIn = (from r in tdc.Klijents
                         where r.Email == email && r.Sifra == sifra
                         select r).Count();

            if (logIn == 1)
            {
                Klijent klijent = (from k in tdc.Klijents
                                   where k.Email == email && k.Sifra == sifra
                                   select k).Single();

                Ulogovan.UlogovanKlijent = klijent.KlijentID;

                MessageBox.Show("Uspesno logovanje.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

                KlijentHomePage khp = new KlijentHomePage();
                khp.Show();
                main.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Nije uneta dobra sifra.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public FormLogovanje()
        {
            InitializeComponent();
        }

        private void cbPrikazSifre_Checked(object sender, RoutedEventArgs e)
        {
            tbPrikazSifre.Visibility = Visibility.Visible;
            tbPrikazSifre.Text = tbSifra.Password;
        }

        private void cbPrikazSifre_Unchecked(object sender, RoutedEventArgs e)
        {
            tbPrikazSifre.Visibility = Visibility.Hidden;
            tbSifra.Password = tbPrikazSifre.Text;
        }

        private void btnLogovanje_Click(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text != "" && (tbSifra.Password != "" || tbPrikazSifre.Text != ""))
            {
                string sifra = "";
                if (cbPrikazSifre.IsChecked == true)
                    sifra = tbPrikazSifre.Text;
                else
                    sifra = tbSifra.Password;

                Ulogovanje(tbEmail.Text, sifra);
            }
            else
            {
                MessageBox.Show("Nisu uneti svi podaci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
