using System;
using System.Windows;
using System.Windows.Controls;
using meervoudige_relaties_voorbeeld_dal;
using meervoudige_relaties_voorbeeld_models;

namespace meervoudige_relaties_voorbeeld_wpf
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        private Order order = null;

        public OrdersView()
        {
            InitializeComponent();
            cmbProduct.ItemsSource = FileOperations.BestandInlezen("Producten.txt");
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer();

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                // Nakijken of order reeds geinitialiseerd is
                if (order == null)
                {
                    order = new Order();
                    lbOrderlijnen.ItemsSource = order.Orderlijnen;
                }

                Product geselecteerd = cmbProduct.SelectedItem as Product;
                Orderlijn orderlijn = new Orderlijn(geselecteerd, int.Parse(txtAantal.Text));

                // Voeg orderlijn toe aan order!
                order.ToevoegenOrderlijn(orderlijn);

                RefreshItems();
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private string Valideer()
        {
            string foutmelding = "";
            // Per conventie wordt _ gebruikt voor parameters die verder niet
            // gebruikt worden maar wel toegevoegd moeten worden omdat de methode
            // deze verwacht.
            if (!int.TryParse(txtAantal.Text, out _))
            {
                foutmelding += "Aantal is een verplicht NUMERIEK veld!" + Environment.NewLine;
            }
            if (!(cmbProduct.SelectedItem is Product))
            {
                foutmelding += "Selecteer een product!" + Environment.NewLine;
            }
            return foutmelding;
        }

        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbOrderlijnen.SelectedItem is Orderlijn orderlijn)
            {
                order.VerwijderenOrderlijn(orderlijn);
                RefreshItems();
            }
            else
            {
                MessageBox.Show("Selecteer een orderlijn!", "Foutmelding");
            }
        }

        private void RefreshItems()
        {
            if (order != null)
            {
                lbOrderlijnen.Items.Refresh();
                txtTotaal.Text = Conversies.ConverteerNumeriekNaarValuta(order.Totaal());
            }
            else
            {
                lbOrderlijnen.ItemsSource = null;
                txtTotaal.Text = "";
            }
        }

        private void BtnAfrekenen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(order.ToString(), "Orderbon", MessageBoxButton.OK, MessageBoxImage.Information);
            order = null;
            txtAantal.Text = null;
            cmbProduct.SelectedItem = null;
            RefreshItems();
        }
    }
}