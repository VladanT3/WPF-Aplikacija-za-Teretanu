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
    /// Interaction logic for FormRacuni.xaml
    /// </summary>
    public partial class FormRacuni : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();

        public void prikazRacuna()
        {
            var racuni = from r in tdc.Racuns
                         where r.Uknjizen == false
                         select r;

            dataGridRacuni.ItemsSource = racuni;
        }
        public void uknjiziRacun(int id)
        {
            Racun racun = (from r in tdc.Racuns
                           where r.RacunID == id
                           select r).Single();

            racun.Uknjizen = true;

            try
            {
                tdc.SubmitChanges();

                prikazRacuna();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex + ", pri uknjizivanju racuna.", "Greska",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public FormRacuni()
        {
            InitializeComponent();

            prikazRacuna();
        }

        private void menuUknjizi_Click(object sender, RoutedEventArgs e)
        {
            uknjiziRacun(((Racun)dataGridRacuni.SelectedItem).RacunID);
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
