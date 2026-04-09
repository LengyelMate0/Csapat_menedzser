using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Focicsapat_menedzser
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Jatekos> keret = new ObservableCollection<Jatekos>();
        private const int MAX_KERET = 26;

        public MainWindow()
        {
            InitializeComponent();
            dgJatekosok.ItemsSource = keret;

            // Kapusok
            keret.Add(new Jatekos("Dibusz Dénes", "Kapus", 0, 41));
            keret.Add(new Jatekos("Gulácsi Péter", "Kapus", 0, 57));
            keret.Add(new Jatekos("Szappanos Péter", "Kapus", 0, 1));

            // Védők
            keret.Add(new Jatekos("Willi Orbán", "Védő", 6, 54));
            keret.Add(new Jatekos("Dárdai Márton", "Védő", 0, 11));
            keret.Add(new Jatekos("Botka Endre", "Védő", 1, 31));
            keret.Add(new Jatekos("Fiola Attila", "Védő", 2, 63));
            keret.Add(new Jatekos("Balogh Botond", "Védő", 0, 7));
            keret.Add(new Jatekos("Szűcs Kornél", "Védő", 0, 3));

            // Középpályások
            keret.Add(new Jatekos("Szoboszlai Dominik", "Középpályás", 15, 51));
            keret.Add(new Jatekos("Nagy Ádám", "Középpályás", 2, 89));
            keret.Add(new Jatekos("Schäfer András", "Középpályás", 3, 34));
            keret.Add(new Jatekos("Bolla Bendegúz", "Középpályás", 0, 25));
            keret.Add(new Jatekos("Nagy Zsolt", "Középpályás", 3, 28));
            keret.Add(new Jatekos("Kata Mihály", "Középpályás", 0, 4));
            keret.Add(new Jatekos("Nikitscher Tamás", "Középpályás", 0, 6));
            keret.Add(new Jatekos("Gera Dániel", "Középpályás", 0, 4));

            // Támadók
            keret.Add(new Jatekos("Sallai Roland", "Csatár", 13, 58));
            keret.Add(new Jatekos("Varga Barnabás", "Csatár", 7, 19));
            keret.Add(new Jatekos("Csoboth Kevin", "Csatár", 1, 15));
            keret.Add(new Jatekos("Gruber Zsombor", "Csatár", 0, 1));
            keret.Add(new Jatekos("Szabó Levente", "Csatár", 0, 2));
            keret.Add(new Jatekos("Dárdai Palkó", "Csatár", 0, 2));
            keret.Add(new Jatekos("Horváth Krisztofer", "Csatár", 0, 4));
        }

        private void BtnHozzaad_Click(object sender, RoutedEventArgs e)
        {
            if (keret.Count >= MAX_KERET)
            {
                MessageBox.Show($"A keret megtelt ({MAX_KERET} fő)!");
                return;
            }

            try
            {
                string nev = txtNev.Text;
                string poszt = txtPoszt.Text;
                int golok = int.Parse(txtGolok.Text);
                int meccsek = int.Parse(txtMeccsek.Text);

                if (!string.IsNullOrWhiteSpace(nev) && !string.IsNullOrWhiteSpace(poszt))
                {
                    keret.Add(new Jatekos(nev, poszt, golok, meccsek));
                    txtNev.Clear();
                    txtPoszt.Clear();
                    txtGolok.Text = "0";
                    txtMeccsek.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("Hiba! A gólokhoz és mérkőzésekhez számot írj!");
            }
        }

        private void BtnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dgJatekosok.SelectedItem is Jatekos kijelolt)
            {
                keret.Remove(kijelolt);
            }
        }
    }
}