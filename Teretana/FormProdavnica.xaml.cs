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
    /// Interaction logic for FormProdavnica.xaml
    /// </summary>
    public partial class FormProdavnica : Window
    {
        TeretanaDataContext tdc = new TeretanaDataContext();
        Stack<pomStavkaRacuna> stavke = new Stack<pomStavkaRacuna>();

        public void GenerisiStavkuRacuna(string id, string naziv, double cena, int kolicina)
        {
            Proizvod proizvod = (from p in tdc.Proizvods
                                 where p.ProizvodID == id
                                 select p).Single();

            if (proizvod.Kolicina != 0)
            {
                stavke.Push(new pomStavkaRacuna(id, naziv, cena, kolicina));

                puniListBox();
                UkupnaCena();
                btnNaruci.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Izabrani proizvod nije trenutno na stanju.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            reset();
        }
        public void reset()
        {
            tbBelt.Clear();
            tbKreatin180t.Clear();
            tbKreatin250g.Clear();
            tbPreworkout120k.Clear();
            tbPreworkout500g.Clear();
            tbProtein1kg.Clear();
            tbProtein500g.Clear();
            tbShaker.Clear();
        }
        public void puniListBox()
        {
            listBoxRacun.Items.Clear();
            foreach(var stavka in stavke)
            {
                listBoxRacun.Items.Add("Naziv: " + stavka.Naziv + " | Cena: " + stavka.Cena + " | Kolicina: " + stavka.Kolicina);
            }
        }
        public void UkupnaCena()
        {
            double ukupnaCena = 0;
            foreach (var stavka in stavke)
            {
                ukupnaCena += stavka.Cena * stavka.Kolicina;
            }

            tbUkupnaCena.Text = ukupnaCena.ToString();
        }
        public void kupiProizvod(string id, TextBox tbKolicina)
        {
            int kolicina = 1;
            if (tbKolicina.Text != "")
                kolicina = int.Parse(tbKolicina.Text);

            Proizvod proizvod = (from p in tdc.Proizvods
                                 where p.ProizvodID == id
                                 select p).Single();

            GenerisiStavkuRacuna(proizvod.ProizvodID, proizvod.NazivProizvoda, proizvod.ProdajnaCena, kolicina);
        }
        public void generisiRacun(double cena)
        {
            Racun noviRacun = new Racun()
            {
                DatumKreiranja = DateTime.Now,
                CenaRacuna = cena,
                KlijentID = Ulogovan.UlogovanKlijent,
                Uknjizen = false
            };

            tdc.Racuns.InsertOnSubmit(noviRacun);

            try
            {
                tdc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex + ", pri pravljenju novog racuna.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var poslednjiRacun = (from r in tdc.Racuns
                                  select r.RacunID).Max();

            foreach(var stavka in stavke)
            {
                StavkaRacuna novaStavka = new StavkaRacuna()
                {
                    RacunID = poslednjiRacun,
                    ProizvodID = stavka.ID,
                    NazivStavke = stavka.Naziv,
                    CenaStavke = stavka.Cena,
                    Kolicina = stavka.Kolicina
                };

                Proizvod proizvod = (from p in tdc.Proizvods
                                     where p.ProizvodID == stavka.ID
                                     select p).Single();

                proizvod.Kolicina -= stavka.Kolicina;

                tdc.StavkaRacunas.InsertOnSubmit(novaStavka);

                try
                {
                    tdc.SubmitChanges();

                    reset();
                    listBoxRacun.Items.Clear();
                    tbUkupnaCena.Clear();
                    btnNaruci.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex + ", pri pravljenju stavki racuna.", "Greska",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            stavke.Clear();
            MessageBox.Show("Kupovina je uspesno obavljena.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public FormProdavnica()
        {
            InitializeComponent();
        }

        private void btnProtein500g_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("Pro500", tbProtein500g);
        }

        private void btnProtein1kg_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("Pro1000", tbProtein1kg);
        }

        private void btnPreworkout500g_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("Pre500", tbPreworkout500g);
        }

        private void btnPreworkout120k_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("Pre120k", tbPreworkout120k);
        }

        private void btnKreatin250g_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("Kre250", tbKreatin250g);
        }

        private void btnKreatin180t_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("Kre180t", tbKreatin180t);
        }

        private void btnShaker_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("ShBeli", tbShaker);
        }

        private void btnBelt_Click(object sender, RoutedEventArgs e)
        {
            kupiProizvod("BltCrni", tbBelt);
        }

        private void btnIzbaciPoslednji_Click(object sender, RoutedEventArgs e)
        {
            if(stavke.Count > 0)
            {
                stavke.Pop();

                puniListBox();
                UkupnaCena();

                if(stavke.Count == 0)
                {
                    listBoxRacun.Items.Clear();
                    tbUkupnaCena.Clear();
                    btnNaruci.IsEnabled = false;
                }
            }
        }

        private void btnNaruci_Click(object sender, RoutedEventArgs e)
        {
            generisiRacun(Convert.ToDouble(tbUkupnaCena.Text));
        }
    }
}
