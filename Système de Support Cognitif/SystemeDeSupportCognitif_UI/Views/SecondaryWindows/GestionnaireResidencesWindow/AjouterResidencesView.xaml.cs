using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireResidencesWindow
{
    public partial class AjouterResidencesView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireResidences _gestionnaireResidences;

        public string UndefinedValueMessage
        {
            get
            {
                return _undefinedValueMessage;
            }

            set
            {
                _undefinedValueMessage = value;
            }
        }

        public GestionnaireResidences GestionnaireResidences
        {
            get
            {
                return _gestionnaireResidences;
            }
        }

        public AjouterResidencesView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireResidences = new GestionnaireResidences("Data/Gestionnaires/Residences.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            ContinentComboBox.Text = "Amérique du Nord";

            PaysComboBox.Text = "Canada";

            EtatProvinceTerritoireTextBox.Text = VilleTextBox.Text = CodePostalTextBox.Text = AdresseTextBox.Text = NumeroDeTelephoneTextBox.Text = LoyerTextBox.Text = DescriptionTextBox.Text = "";

            DateDeDebutDatePicker.Text = DateDeFinDatePicker.Text = DateTime.Now.ToString();
        }

        private void AjouterLaResidenceButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter cette résidence?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool)ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Residence newResidence = new Residence(_gestionnaireResidences.GetNewResidenceId(), ContinentComboBox.Text, PaysComboBox.Text, EtatProvinceTerritoireTextBox.Text, VilleTextBox.Text, CodePostalTextBox.Text, AdresseTextBox.Text, NumeroDeTelephoneTextBox.Text, LoyerTextBox.Text, DateDeDebutDatePicker.Text, DateDeFinDatePicker.Text, DescriptionTextBox.Text);

                _gestionnaireResidences.AddResidence(newResidence);

                EmptyWindowInformation();
            }
        }

    }
}
