using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireAcquisitionsWindow
{
    public partial class AjouterAcquisitionsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireAcquisitions _gestionnaireAcquisitions;

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

        public GestionnaireAcquisitions GestionnaireAcquisitions
        {
            get
            {
                return _gestionnaireAcquisitions;
            }
        }

        public AjouterAcquisitionsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireAcquisitions = new GestionnaireAcquisitions("Data/Gestionnaires/Acquisitions.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            NomTextBox.Text = PrixTextBox.Text = VendeurTextBox.Text = GarantieTextBox.Text = DescriptionTextBox.Text = "";

            DateAchatDatePicker.Text = DateDeRebutDatePicker.Text = DateExpirationDeLaGarantieDatePicker.Text = DateTime.Now.ToString();
        }

        private void AjouterAcquisitionButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter cette acquisition?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool) ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Acquisition newAcquisition = new Acquisition(_gestionnaireAcquisitions.GetNewAcquisitionId(), NomTextBox.Text, PrixTextBox.Text, VendeurTextBox.Text, DateAchatDatePicker.Text, DateDeRebutDatePicker.Text, DateExpirationDeLaGarantieDatePicker.Text, GarantieTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireAcquisitions.AddAcquisition(newAcquisition);

                EmptyWindowInformation();
            }
        }
    }
}
