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
using IrodalomProjekt.Models;
using Microsoft.Win32;

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
        private void KerdesBetoltes(string fileName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT fájlok (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    KerdesBetoltes(openFileDialog.FileName);
                    MessageBox.Show("Sikeres betöltés!", "Információ", MessageBoxButton.OK);
                    if (kerdesek.Count > 0)
                    {
                        aktualisIndex = 0;
                        MutatKerdes(aktualisIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a fájl betöltése közben: {ex.Message}");
                }
            }

        }

        private void MutatKerdes(int aktualisIndex)
        {
            if (kerdesek.Count > 0 && aktualisIndex >= 0 && aktualisIndex < kerdesek.Count)
            {
                var kerdes = kerdesek[aktualisIndex];
                KerdesTextBlock.Text = kerdes.Kerdelem;  
                ValaszPanel.Children.Clear();  

                foreach (var valasz in kerdes.Valaszok)
                {
                    RadioButton rb = new RadioButton
                    {
                        Content = valasz
                    };
                    ValaszPanel.Children.Add(rb);
                }
            }
        }

        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {

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

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}