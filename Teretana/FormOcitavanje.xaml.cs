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
    /// Interaction logic for FormOcitavanje.xaml
    /// </summary>
    public partial class FormOcitavanje : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();

        public void OcitavanjeKartice(int id)
        {
            if(id == 1)
            {
                MessageBox.Show("Nije moguce ocitati klijenta!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var proveraID = (from k in tdc.Klijents
                             where k.KlijentID == id
                             select k).Count();

            if(proveraID > 0)
            {
                Klijent klijent = (from k in tdc.Klijents
                                   where k.KlijentID == id
                                   select k).Single();

                if(klijent.ClanarinaID != "N0")
                {
                    klijent.BrojTermina--;
                    if (klijent.BrojTermina == 0)
                    {
                        klijent.ClanarinaID = "N0";
                        klijent.DatumPocetkaClanarine = DateTime.Now;
                        klijent.DatumIstekaClanarine = DateTime.Now;
                    }

                    try
                    {
                        tdc.SubmitChanges();

                        dataGridKlijenti.Items.Add(klijent);
                        tbID.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Doslo je do greske: " + ex + ", pri ocitavnju klijenta.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Klijent bez clanarine ne moze da dodje na trening.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Klijent ne postoji u sistemu.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                tbID.Clear();
            }
        }

        public FormOcitavanje()
        {
            InitializeComponent();
        }

        private void btnOcitaj_Click(object sender, RoutedEventArgs e)
        {
            OcitavanjeKartice(int.Parse(tbID.Text));
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbID.Text != "")
                btnOcitaj.IsEnabled = true;
            else
                btnOcitaj.IsEnabled = false;
        }
    }
}
