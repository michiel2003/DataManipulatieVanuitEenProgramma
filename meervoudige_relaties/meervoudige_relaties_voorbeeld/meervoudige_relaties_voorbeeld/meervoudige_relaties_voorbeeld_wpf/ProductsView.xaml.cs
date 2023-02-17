using meervoudige_relaties_voorbeeld_dal;
using meervoudige_relaties_voorbeeld_models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace meervoudige_relaties_voorbeeld_wpf
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
            lbProducten.ItemsSource = FileOperations.BestandInlezen("producten.txt");
            rbBoek.IsChecked = true;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = null;
            string foutmelding = Valideer();

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                // We zijn zeker dat txtPrijs numeriek is, is reeds gevalideerd -> daarom enkel maar double.parse.
                if (rbBoek.IsChecked == true)
                {
                    product = new Boek(txtCode.Text, txtBeschrijving.Text, double.Parse(txtPrijs.Text), txtExtra.Text);
                }
                else if (rbSoftware.IsChecked == true)
                {
                    product = new Software(txtCode.Text, txtBeschrijving.Text, double.Parse(txtPrijs.Text), txtExtra.Text);
                }
                else
                {
                    product = new Product(txtCode.Text, txtBeschrijving.Text, double.Parse(txtPrijs.Text));
                }

                FileOperations.AddProduct("Producten.txt", product);

                lbProducten.ItemsSource = FileOperations.BestandInlezen("producten.txt");

                txtCode.Text = "";
                txtBeschrijving.Text = "";
                txtPrijs.Text = "";
                txtExtra.Text = "";
            }
            else
            {
                lblErrors.Content = foutmelding;
            }
        }

        private string Valideer()
        {
            string foutmelding = "";
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                foutmelding = "Code is een verplicht veld!" + Environment.NewLine;
            }
            if (string.IsNullOrWhiteSpace(txtBeschrijving.Text))
            {
                lblErrors.Content += "Description is een verplicht veld!" + Environment.NewLine;
            }

            if (!double.TryParse(txtPrijs.Text, out double prijs))
            {
                foutmelding += "Prijs is een verplicht NUMERIEK veld!" + Environment.NewLine;
            }

            if (string.IsNullOrWhiteSpace(txtExtra.Text) && rbProduct.IsChecked == false)
            {
                foutmelding += lblExtra.Content + " is een verplicht veld!" + Environment.NewLine;
            }
            return foutmelding;
        }

        private void RbSoftware_Checked(object sender, RoutedEventArgs e)
        {
            lblExtra.Visibility = Visibility.Visible;
            txtExtra.Visibility = Visibility.Visible;
            lblExtra.Content = "Software";
        }

        private void RbBoek_Checked(object sender, RoutedEventArgs e)
        {
            lblExtra.Visibility = Visibility.Visible;
            txtExtra.Visibility = Visibility.Visible;
            lblExtra.Content = "Auteur";
        }

        private void RbProduct_Checked(object sender, RoutedEventArgs e)
        {
            lblExtra.Visibility = Visibility.Hidden;
            txtExtra.Visibility = Visibility.Hidden;
        }
    }
}