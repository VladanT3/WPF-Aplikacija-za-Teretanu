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
    /// Interaction logic for FormNalog.xaml
    /// </summary>
    public partial class FormNalog : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();
        public KlijentHomePage khp;

        public void prikazProfila()
        {
            Klijent klijent = (from k in tdc.Klijents
                               where k.KlijentID == Ulogovan.UlogovanKlijent
                               select k).Single();

            Clanarina clanarina = (from c in tdc.Clanarinas
                                   where klijent.ClanarinaID == c.ClanarinaID
                                   select c).Single();

            tBlockIme.Text = klijent.Ime + " " + klijent.Prezime;
            tBlockEmail.Text = klijent.Email;
            tBlockDatum.Text = klijent.DatumRodjenja.ToShortDateString();
            tBlockAdresa.Text = klijent.Adresa;
            tBlockTelefon.Text = klijent.BrojTelefona;
            tBlockClanarina.Text = clanarina.NazivClanarine;
            tBlockDatumIsteka.Text = klijent.DatumIstekaClanarine.ToShortDateString();
            tBlockTermini.Text = klijent.BrojTermina.ToString();
        }
        public void ObrisiNalog()
        {
            Klijent klijent = (from k in tdc.Klijents
                               where k.KlijentID == Ulogovan.UlogovanKlijent
                               select k).Single();

            MessageBoxResult rez = MessageBox.Show("Da li ste sigurni da zelite da obrisete vas nalog?", "Brisanje naloga",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (rez == MessageBoxResult.Yes)
            {
                tdc.Klijents.DeleteOnSubmit(klijent);

                Racun racun = (from r in tdc.Racuns
                               where r.KlijentID == Ulogovan.UlogovanKlijent
                               select r).Single();
                racun.KlijentID = 1;

                try
                {
                    tdc.SubmitChanges();
                    MessageBox.Show("Uspesno obrisan nalog.", "Brisanje naloga", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow main = new MainWindow();
                    main.Show();
                    khp.Close();
                    Ulogovan.UlogovanKlijent = 0;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex + ", pri brisanju vaseg naloga.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public FormNalog()
        {
            InitializeComponent();

            prikazProfila();
        }

        private void btnBrisi_Click(object sender, RoutedEventArgs e)
        {
            ObrisiNalog();
        }
    }
}
