using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Focicsapat_menedzser
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Jatekos> keret = new ObservableCollection<Jatekos>();

        public MainWindow()
        {
            InitializeComponent();
            dgJatekosok.ItemsSource = keret;
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("keret_adatok.csv"))
                {
                    foreach (var j in keret) sw.WriteLine(j.ToCsv());
                }
                MessageBox.Show("Sikeres mentés a keret_adatok.csv fájlba!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba mentés közben: " + ex.Message);
            }
        }

        private void BtnBeolvas_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("keret_adatok.csv"))
            {
                MessageBox.Show("Nincs még mentett adatfájl!");
                return;
            }

            try
            {
                keret.Clear();
                var sorok = File.ReadAllLines("keret_adatok.csv");
                foreach (var sor in sorok)
                {
                    if (string.IsNullOrWhiteSpace(sor)) continue;
                    var adatok = sor.Split(';');
                    if (adatok.Length == 4)
                    {
                        keret.Add(new Jatekos(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3])));
                    }
                }
                MessageBox.Show("Adatok sikeresen betöltve!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba beolvasáskor: " + ex.Message);
            }
        }

        private void BtnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dgJatekosok.SelectedItem is Jatekos kijelolt)
            {
                keret.Remove(kijelolt);
            }
            else
            {
                MessageBox.Show("Válassz ki egy játékost a listából!");
            }
        }
    }
}