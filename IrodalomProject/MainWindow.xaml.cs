using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;
using IrodalomProjekt.Models;

namespace IrodalomProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Kerdes> kerdesek = new List<Kerdes>();
        private static int aktualisIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void KerdesBetoltes(string fileName)
        {

            kerdesek.Clear();
            try
            {
                StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string kerdesSzovege = sr.ReadLine();
                    string valaszA = sr.ReadLine();
                    string valaszB = sr.ReadLine();
                    string valaszC = sr.ReadLine();
                    string helyesValasz = sr.ReadLine();
                    Kerdes kerdes = new Kerdes(kerdesSzovege, valaszA, valaszB, valaszC, helyesValasz);
                    kerdesek.Add(kerdes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a fájl olvasása közben: " + ex.Message);
            }
        }

        private void MutatKerdes(int index)
        {
            Kerdes kered = kerdesek[index];
            tbkKerdesSzovege.Text = kered.KerdesSzovege;
            ValaszA.Content = kered.ValaszA;
            ValaszB.Content = kered.ValaszB;
            ValaszC.Content = kered.ValaszC;
            switch (kered.FelhasznaloValasz)
            {
                case "A":
                    ValaszA.IsChecked = true;
                    ValaszB.IsChecked = false;
                    ValaszC.IsChecked = false;
                    break;
                case "B":
                    ValaszA.IsChecked = false;
                    ValaszB.IsChecked = true;
                    ValaszC.IsChecked = false;
                    break;
                case "C":
                    ValaszA.IsChecked = false;
                    ValaszB.IsChecked = false;
                    ValaszC.IsChecked = true;
                    break;
                default:
                    ValaszA.IsChecked = false;
                    ValaszB.IsChecked = false;
                    ValaszC.IsChecked = false;
                    break;
            }
        }
        private void Elozo_Click(object sender, RoutedEventArgs e)
        {
            if (aktualisIndex > 0)
            {
                aktualisIndex--;
                MutatKerdes(aktualisIndex);
            }
        }

        private void Kovetkezo_Click(object sender, RoutedEventArgs e)
        {
            if (aktualisIndex < kerdesek.Count - 1)
            {
                aktualisIndex++;
                MutatKerdes(aktualisIndex);
            }
        }
        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT fájlok (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    KerdesBetoltes(openFileDialog.FileName);
                    MessageBox.Show("Sikeres betöltés!", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (kerdesek.Count > 0)
                    {
                        aktualisIndex = 0;
                        MutatKerdes(aktualisIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            if(aktualisIndex <kerdesek.Count)
            {
                if (ValaszA.IsChecked == true)
                {
                    kerdesek[aktualisIndex].FelhasznaloValasz = "A";
                }
                else if (ValaszB.IsChecked == true)
                {
                    kerdesek[aktualisIndex].FelhasznaloValasz = "B";
                }
                else if (ValaszC.IsChecked == true)
                {
                    kerdesek[aktualisIndex].FelhasznaloValasz = "C";
                }
            }
            MessageBox.Show("Válasz mentve!", "Információ");
        }

        private void Kiertekeles_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}