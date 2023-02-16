using studenten_models;
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

namespace studenten_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Klas klas = new Klas("");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            klas.KlasNaam = txtKlasnaam.Text;
            txtDetails.Text = klas.MaakLijst();
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNummer.Text))
                {
                    throw new Exception("Student nummer was niet ingevuld");
                }
                if (String.IsNullOrEmpty(txtNaam.Text))
                {
                    throw new Exception("Student naam was niet ingevuld");
                }
                if (rbKotstudent.IsChecked == true)
                {
                    if (String.IsNullOrEmpty(txtKotbaas.Text))
                    {
                        throw new Exception("Kotstudent was geselecteerd maar er is geen kotbaas opgegeven");
                    }
                    if (String.IsNullOrEmpty(txtKotadres.Text))
                    {
                        throw new Exception("Kotstudent was geselecteerd maar er is geen kotadres opgegeveb");
                    }
                }

                String studentNummer = txtNummer.Text;
                String studentNaam = txtNaam.Text;
                if (rbStudent.IsChecked == true)
                {
                    Student newStudent = new Student(studentNummer, studentNaam);
                    klas.VoegStudentToe(newStudent);
                }
                if (rbKotstudent.IsChecked == true)
                {
                    String kotbass = txtKotbaas.Text;
                    String kotadres = txtKotadres.Text;
                    KotStudent kotStudent = new KotStudent(studentNummer, studentNaam, kotbass, kotadres);
                    klas.VoegStudentToe(kotStudent);
                }

                txtDetails.Text = klas.MaakLijst();
                Console.WriteLine(klas.MaakLijst());

                if (cbDetail.IsChecked == true)
                {
                    txtDetails.Text = klas.MaakUitGebreideLijst();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Toevoegen", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void txtNaam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbDetail_Checked(object sender, RoutedEventArgs e)
        {
            txtDetails.Text = klas.MaakUitGebreideLijst();

    }

        private void cbDetail_Unchecked(object sender, RoutedEventArgs e)
        {
            txtDetails.Text = klas.MaakLijst();
        }
    }
}
