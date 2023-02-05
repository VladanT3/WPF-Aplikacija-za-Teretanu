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
    /// Interaction logic for FormProizvodi.xaml
    /// </summary>
    public partial class FormProizvodi : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();

        public void prikazProizvoda()
        {
            var proiz = from p in tdc.Proizvods
                       select p;

            dataGridProizvodi.ItemsSource = proiz;
        }
        public void traziProizvod(string naziv)
        {
            var pretraga = from p in tdc.Proizvods
                           where p.NazivProizvoda.Contains(naziv)
                           select p;

            dataGridProizvodi.ItemsSource = pretraga;
            tbPretraga.Clear();
        }
        public void kreirajProizvod(string id, string naziv, float nabavnaCena, float prodajnaCena)
        {
            var provera = (from p in tdc.Proizvods
                          where p.ProizvodID == id
                          select p).Count();

            if(provera > 0)
            {
                MessageBox.Show("Proizvod vec postoji.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Proizvod noviPro = new Proizvod()
            {
                ProizvodID = id,
                NazivProizvoda = naziv,
                Kolicina = 0,
                NabavnaCena = nabavnaCena,
                ProdajnaCena = prodajnaCena
            };

            tdc.Proizvods.InsertOnSubmit(noviPro);

            try
            {
                tdc.SubmitChanges();
                
                MessageBox.Show("Uspesno unet novi proizvod.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
                
                prikazProizvoda();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex + ", pri unosu novog proizvoda.", "Greska",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void menjajProizvod(string id)
        {
            Proizvod menjanjePro = (from p in tdc.Proizvods
                                    where p.ProizvodID == id
                                    select p).Single();

            menjanjePro.NazivProizvoda = tbNaziv.Text;
            menjanjePro.NabavnaCena = float.Parse(tbNabavnaCena.Text);
            menjanjePro.ProdajnaCena = float.Parse(tbProdajnaCena.Text);

            try
            {
                tdc.SubmitChanges();
                
                MessageBox.Show("Proizvod je uspesno promenjen.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
                
                prikazProizvoda();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex + ", pri menjanju proizvoda.", "Greska",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void brisiProizvod(string id)
        {
            Proizvod brisanjePro = (from p in tdc.Proizvods
                                    where p.ProizvodID == id
                                    select p).Single();

            tdc.Proizvods.DeleteOnSubmit(brisanjePro);

            try
            {
                tdc.SubmitChanges();

                MessageBox.Show("Uspesno obrisan proizvod.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

                prikazProizvoda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex + ", pri brisanju proizvoda.", "Greska",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void reset()
        {
            tbID.Clear();
            tbNaziv.Clear();
            tbNabavnaCena.Clear();
            tbProdajnaCena.Clear();

            dataGridProizvodi.SelectedIndex = -1;

            tbID.IsEnabled = true;
            btnUnos.IsEnabled = true;
            btnIzmena.IsEnabled = false;
        }

        public FormProizvodi()
        {
            InitializeComponent();

            prikazProizvoda();
        }

        private void btnPretrazi_Click(object sender, RoutedEventArgs e)
        {
            if (tbPretraga.Text != "")
            {
                traziProizvod(tbPretraga.Text);
            }
            else
            {
                prikazProizvoda();
            }
        }

        private void btnUnos_Click(object sender, RoutedEventArgs e)
        {
            if(tbID.Text != "" && tbNaziv.Text != "" && tbNabavnaCena.Text != "" && tbProdajnaCena.Text != "")
            {
                try
                {
                    float nabavnaCena = float.Parse(tbNabavnaCena.Text);
                    float prodajnaCena = float.Parse(tbProdajnaCena.Text);

                    kreirajProizvod(tbID.Text, tbNaziv.Text, nabavnaCena, prodajnaCena);
                }
                catch (Exception)
                {
                    MessageBox.Show("Podaci nisu u dobrom formatu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva obavezna polja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnIzmena_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float nabavnaCena = float.Parse(tbNabavnaCena.Text);
                float prodajnaCena = float.Parse(tbProdajnaCena.Text);

                menjajProizvod(tbID.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Podaci nisu u dobrom formatu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void menuBrisanje_Click(object sender, RoutedEventArgs e)
        {
            brisiProizvod(((Proizvod)dataGridProizvodi.SelectedItem).ProizvodID);
        }

        private void dataGridProizvodi_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dataGridProizvodi.SelectedIndex != -1)
            {
                tbID.Text = ((Proizvod)dataGridProizvodi.SelectedItem).ProizvodID;
                tbNaziv.Text = ((Proizvod)dataGridProizvodi.SelectedItem).NazivProizvoda;
                tbNabavnaCena.Text = ((Proizvod)dataGridProizvodi.SelectedItem).NabavnaCena.ToString();
                tbProdajnaCena.Text = ((Proizvod)dataGridProizvodi.SelectedItem).ProdajnaCena.ToString();

                tbID.IsEnabled = false;
                btnUnos.IsEnabled = false;
                btnIzmena.IsEnabled = true;
            }
            else
            {
                tbID.Clear();
                tbNaziv.Clear();
                tbNabavnaCena.Clear();
                tbProdajnaCena.Clear();

                tbID.IsEnabled = true;
                btnUnos.IsEnabled = true;
                btnIzmena.IsEnabled = false;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }
    }
}
