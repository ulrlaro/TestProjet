using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEvenementsWindow
{
    public partial class AjouterEvenementsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireEvenements _gestionnaireEvenements;

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

        public GestionnaireEvenements GestionnaireEvenements
        {
            get
            {
                return _gestionnaireEvenements;
            }
        }

        public AjouterEvenementsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireEvenements = new GestionnaireEvenements("Data/Gestionnaires/Evenements.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            NomTextBox.Text = CategorieTextBox.Text = DescriptionTextBox.Text = "";

            DateDeDebutDatePicker.Text = DateDeFinDatePicker.Text = DateTime.Now.ToString();
        }

        private void AjouterEvenementButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter cet événement?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool)ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Evenement newEvenement = new Evenement(_gestionnaireEvenements.GetNewEvenementId(), NomTextBox.Text, CategorieTextBox.Text, DateDeDebutDatePicker.Text, DateDeFinDatePicker.Text, DescriptionTextBox.Text);

                _gestionnaireEvenements.AddEvenement(newEvenement);

                EmptyWindowInformation();
            }
        }
    }
}
