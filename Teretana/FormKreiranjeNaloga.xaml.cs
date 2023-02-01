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
    /// Interaction logic for FormKreiranjeNaloga.xaml
    /// </summary>
    public partial class FormKreiranjeNaloga : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();
        public MainWindow main;

        public void KreirajNalog(string ime, string prezime, string email, string sifra, DateTime datumRodjenja, string adresa, string brojTelefona)
        {
            var proveraKlijentEmail = (from k in tdc.Klijents
                                       where k.Email == email
                                       select k).Count();
            var proveraRadnikEmail = (from r in tdc.Radniks
                                      where r.Email == email
                                      select r).Count();

            if(proveraKlijentEmail == 0 && proveraRadnikEmail == 0)
            {
                Klijent noviKlijent = new Klijent()
                {
                    Ime = ime,
                    Prezime = prezime,
                    Email = email,
                    Sifra = sifra,
                    DatumRodjenja = datumRodjenja,
                    Adresa = adresa,
                    BrojTelefona = brojTelefona,
                    ClanarinaID = "N0",
                    DatumPocetkaClanarine = DateTime.Now,
                    DatumIstekaClanarine = DateTime.Now,
                    BrojTermina = 0
                };

                tdc.Klijents.InsertOnSubmit(noviKlijent);

                try
                {
                    tdc.SubmitChanges();
                    MessageBox.Show("Uspesno kreiran nalog.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

                    var poslednjiKlijent = (from k in tdc.Klijents
                                                select k.KlijentID).Max();

                    Ulogovan.UlogovanKlijent = poslednjiKlijent;

                    KlijentHomePage khp = new KlijentHomePage();
                    khp.Show();
                    main.Close();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex + ", pri kreiranju vaseg naloga.", "Greska",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Uneti email je vec registrovan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public FormKreiranjeNaloga()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (tbIme.Text != "" && tbPrezime.Text != "" && tbEmail.Text != "" && (tbSifra.Password != "" || tbPrikazSifre.Text != "") &&
                tbAdresa.Text != "" && tbTelefon.Text != "" && !calDatumRodjenja.SelectedDate.Equals(null))
            {
                string sifra = "";
                if (cbPrikazSifre.IsChecked == true)
                    sifra = tbPrikazSifre.Text;
                else
                    sifra = tbSifra.Password;

                KreirajNalog(tbIme.Text, tbPrezime.Text, tbEmail.Text, sifra, (DateTime)calDatumRodjenja.SelectedDate,
                    tbAdresa.Text, tbTelefon.Text);
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
