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
    /// Interaction logic for FormPorudzbenica.xaml
    /// </summary>
    public partial class FormPorudzbenica : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();
        Stack<pomStavkaPorudzbenice> stavke = new Stack<pomStavkaPorudzbenice>();

        public void prikazProizvoda()
        {
            var proiz = from p in tdc.Proizvods
                        select p;

            dataGridProizvodi.ItemsSource = proiz;
        }
        public void generisiStavkuPorudzbenice(string id, string naziv, double cena, int kolicina)
        {
            Proizvod proizvod = (from p in tdc.Proizvods
                                 where p.ProizvodID == id
                                 select p).Single();

            if (proizvod.Kolicina > 20)
            {
                MessageBoxResult rez = MessageBox.Show("Proizvoda ima dovoljno u magacinu. Da li zelite svakako da narucite jos?",
                    "Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rez == MessageBoxResult.Yes)
                {
                    stavke.Push(new pomStavkaPorudzbenice(id, naziv, cena, kolicina));

                    puniListBox();
                    ukupnaCena();
                    btnNaruci.IsEnabled = true;
                }
            }
            else
            {
                stavke.Push(new pomStavkaPorudzbenice(id, naziv, cena, kolicina));

                puniListBox();
                ukupnaCena();
                btnNaruci.IsEnabled = true;
            }

            dataGridProizvodi.SelectedIndex = -1;
            tbKolicina.Clear();
            tbKolicina.IsEnabled = false;
            btnDodaj.IsEnabled = false;
        }
        public void puniListBox()
        {
            listBoxPorudzbenica.Items.Clear();
            foreach(var stavka in stavke)
            {
                listBoxPorudzbenica.Items.Add("ID: " + stavka.ID + " | Naziv: " + stavka.Naziv + " | Cena: " + stavka.Cena + " | Kolicina: " + stavka.Kolicina);
            }
        }
        public void ukupnaCena()
        {
            double ukupnaCena = 0;
            foreach (var stavka in stavke)
            {
                ukupnaCena += stavka.Cena * stavka.Kolicina;
            }

            tbUkupnaCena.Text = ukupnaCena.ToString();
        }
        public void generisiPorudzbenicu(double cena, string dobavljac)
        {
            Porudzbenica novaPorudzbenica = new Porudzbenica()
            {
                DatumKreiranja = DateTime.Now,
                CenaPorudzbenice = cena,
                RadnikID = Ulogovan.UlogovanRadnik,
                DobavljacID = dobavljac
            };

            tdc.Porudzbenicas.InsertOnSubmit(novaPorudzbenica);

            try
            {
                tdc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex + ", pri pravljenju nove porudzbenice.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var poslednjaPorudzbenica = (from p in tdc.Porudzbenicas
                                         select p.PorudzbenicaID).Max();

            foreach(var stavka in stavke)
            {
                StavkaPorudzbenice novaStavka = new StavkaPorudzbenice()
                {
                    PorudzbenicaID = poslednjaPorudzbenica,
                    ProizvodID = stavka.ID,
                    NazivStavke = stavka.Naziv,
                    CenaStavke = stavka.Cena,
                    Kolicina = stavka.Kolicina
                };

                Proizvod proizvod = (from p in tdc.Proizvods
                                     where p.ProizvodID == stavka.ID
                                     select p).Single();

                proizvod.Kolicina += stavka.Kolicina;

                tdc.StavkaPorudzbenices.InsertOnSubmit(novaStavka);

                try
                {
                    tdc.SubmitChanges();

                    prikazProizvoda();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex + ", pri pravljenju stavki porudzbenice.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            stavke.Clear();
            MessageBox.Show("Uspesno napravljena porudzbenica.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void reset()
        {
            listBoxPorudzbenica.Items.Clear();
            dataGridProizvodi.SelectedIndex = -1;
            tbKolicina.Clear();
            tbKolicina.IsEnabled = false;
            btnDodaj.IsEnabled = false;
            tbUkupnaCena.Clear();
            cbDobavljaci.SelectedIndex = -1;
        }
        public void puniComboBox()
        {
            var dobavljaci = from d in tdc.Dobavljacs
                             select d;

            cbDobavljaci.ItemsSource = dobavljaci;
        }

        public FormPorudzbenica()
        {
            InitializeComponent();

            prikazProizvoda();
            puniComboBox();
        }

        private void dataGridProizvodi_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dataGridProizvodi.SelectedIndex != -1)
            {
                tbKolicina.Clear();
                tbKolicina.IsEnabled = true;
                btnDodaj.IsEnabled = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if(tbKolicina.Text != "")
            {
                string id = ((Proizvod)dataGridProizvodi.SelectedItem).ProizvodID;
                string naziv = ((Proizvod)dataGridProizvodi.SelectedItem).NazivProizvoda;
                double cena = ((Proizvod)dataGridProizvodi.SelectedItem).NabavnaCena;
                int kolicina = int.Parse(tbKolicina.Text);

                generisiStavkuPorudzbenice(id, naziv, cena, kolicina);
            }
            else
            {
                MessageBox.Show("Morate da unesete kolicinu koju zelite da narucite.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnObrisiStavku_Click(object sender, RoutedEventArgs e)
        {
            if(stavke.Count > 0)
            {
                stavke.Pop();

                puniListBox();
                ukupnaCena();

                if(stavke.Count == 0)
                {
                    listBoxPorudzbenica.Items.Clear();
                    tbUkupnaCena.Clear();
                    btnNaruci.IsEnabled = false;
                }
            }
        }

        private void btnNaruci_Click(object sender, RoutedEventArgs e)
        {
            if(cbDobavljaci.SelectedIndex != -1)
            {
                double cena = Convert.ToDouble(tbUkupnaCena.Text);
                string dobavljac = ((Dobavljac)cbDobavljaci.SelectedItem).DobavljacID;

                generisiPorudzbenicu(cena, dobavljac);
            }
            else
            {
                MessageBox.Show("Nije izabran dobavljac!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
