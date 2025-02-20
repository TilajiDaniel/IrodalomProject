﻿using IrodalomProject.Models;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IrodalomProject
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

        private static void KerdeseketFeltolt(string fileName)
        {
            {
                kerdesek.Clear();
                try
                {
                    StreamReader sr = new 
                }
            }
        }
        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT fájlok(*.txt)|*.txt ";
            if(openFileDialog.ShowDialog() == true)
            {
                try
                {
                    KerdeseketFeltolt(openFileDialog.FileName);
                    MessageBox.Show("Sikeres betöltés!", "Információ", MessageBoxButton.OK,
                        MessageBoxImage.Information);
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

        private void MutatKerdes(int aktualisIndex)
        {
            throw new NotImplementedException();
        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Kiertekeles_CLick(object sender, RoutedEventArgs e)
        {

        }
        private void ElozoClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void KovetkezoClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void ValaszMenteseClick(object sender, RoutedEventArgs e)
        {
            
        }

    }
}