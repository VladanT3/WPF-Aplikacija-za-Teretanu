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
    /// Interaction logic for FormClanarina.xaml
    /// </summary>
    public partial class FormClanarina : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();

        public void IzaberiClanarinu(string id, int termini)
        {
            Klijent klijent = (from k in tdc.Klijents
                               where k.KlijentID == Ulogovan.UlogovanKlijent
                               select k).Single();

            if (klijent.ClanarinaID != "N0")
            {
                MessageBoxResult rez = MessageBox.Show("Vec imate kupljenu clanarinu. Da li zelite da je produzite?", "Pitanje",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rez == MessageBoxResult.Yes)
                {
                    klijent.ClanarinaID = id;
                    klijent.BrojTermina += termini;
                    klijent.DatumIstekaClanarine.AddMonths(1);// = klijent.DatumIstekaClanarine.AddMonths(1);

                    try
                    {
                        tdc.SubmitChanges();
                        MessageBox.Show("Vasa clanarina je uspesno produzena, detalje mozete videti na vasem nalogu.", "Obavestenje",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Doslo je do greske: " + ex + ", pri produzivanju vase clanarine.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    return;
            }
            else
            {
                klijent.ClanarinaID = id;
                klijent.BrojTermina += termini;
                klijent.DatumPocetkaClanarine = DateTime.Now;
                klijent.DatumIstekaClanarine = DateTime.Now.AddMonths(1);

                try
                {
                    tdc.SubmitChanges();
                    MessageBox.Show("Uspesno ste kupili clanarinu, detalje mozete videti na vasem nalogu.", "Obavestenje",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex + ", pri kupovanju vase clanarine.", "Greska",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public FormClanarina()
        {
            InitializeComponent();
        }

        private void btnBasic_Click(object sender, RoutedEventArgs e)
        {
            IzaberiClanarinu("B12", 12);
        }

        private void btnClassic_Click(object sender, RoutedEventArgs e)
        {
            IzaberiClanarinu("C16", 16);
        }

        private void btnElite_Click(object sender, RoutedEventArgs e)
        {
            IzaberiClanarinu("E31", 31);
        }
    }
}
