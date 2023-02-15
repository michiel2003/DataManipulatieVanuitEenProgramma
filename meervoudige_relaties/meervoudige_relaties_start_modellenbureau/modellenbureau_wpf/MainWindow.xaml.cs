﻿using modellenbureau_models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace modellenbureau_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<ModellenBureau> Bureaus = new List<ModellenBureau>();

        public MainWindow()
        {
            InitializeComponent();
            lbBureaus.ItemsSource = Bureaus;
            
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String newBureauName = txtNaamBureau.Text;
                ModellenBureau NewBureau = new ModellenBureau(newBureauName);
                Bureaus.Add(NewBureau);
                lbBureaus.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selected = lbBureaus.SelectedIndex;
                ModellenBureau bureau = Bureaus.ElementAt(selected);
                String newNaam = txtNaam.Text;
                double newLengte = double.Parse(txtLengte.Text);
                double newPols = double.Parse(txtPols.Text);

                bureau.voegToe(newNaam, newPols, newLengte);
                lbBureaus.Items.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSlank_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int selected = lbBureaus.SelectedIndex;
                ModellenBureau bureau = Bureaus.ElementAt(selected);
                String superslank = bureau.DrukSlank();
                MessageBox.Show(superslank);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}