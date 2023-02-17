using meervoudige_relaties_voorbeeld_dal;
using meervoudige_relaties_voorbeeld_models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace meervoudige_relaties_voorbeeld_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string geselecteerdTabblad = (tabControl.SelectedItem as TabItem).Name;
            switch (geselecteerdTabblad)
            {
                case "tabProducts":
                    ContentWindow.Content = new ProductsView();
                    break;
                default:
                    ContentWindow.Content = new OrdersView();
                    break;
            }
        }
    }
}