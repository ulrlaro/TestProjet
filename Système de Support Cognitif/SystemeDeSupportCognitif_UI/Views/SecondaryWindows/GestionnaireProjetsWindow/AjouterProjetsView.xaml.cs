using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireProjetsWindow
{
    public partial class AjouterProjetsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireProjets _gestionnaireProjets;

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

        public GestionnaireProjets GestionnaireProjets
        {
            get
            {
                return _gestionnaireProjets;
            }
        }

        public AjouterProjetsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireProjets = new GestionnaireProjets("Data/Gestionnaires/Projets.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            NomTextBox.Text = CategorieTextBox.Text = DomaineTextBox.Text = NiveauCompleteTextBox.Text = DescriptionTextBox.Text = "";

            DateDeDebutDatePicker.Text = DateDeFinDatePicker.Text = DateCibleDatePicker.Text = DateTime.Now.ToString();
        }

        private void AjouterLeProjetButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter ce projet?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool) ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Projet newProjet = new Projet(_gestionnaireProjets.GetNewProjetId(), NomTextBox.Text, CategorieTextBox.Text, DomaineTextBox.Text, DateDeDebutDatePicker.Text, DateDeFinDatePicker.Text, DateCibleDatePicker.Text, NiveauCompleteTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireProjets.AddProjet(newProjet);

                EmptyWindowInformation();
            }
        }
    }
}
