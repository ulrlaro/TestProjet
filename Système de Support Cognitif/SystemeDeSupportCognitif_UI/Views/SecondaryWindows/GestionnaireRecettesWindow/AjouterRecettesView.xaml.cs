using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireRecettesWindow
{
    public partial class AjouterRecettesView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireRecettes _gestionnaireRecettes;

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

        public GestionnaireRecettes GestionnaireRecettes
        {
            get
            {
                return _gestionnaireRecettes;
            }
        }

        public AjouterRecettesView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireRecettes = new GestionnaireRecettes("Data/Gestionnaires/Recettes.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            NomTextBox.Text = SourceTextBox.Text = IngredientsTextBox.Text = PreparationTextBox.Text = DescriptionTextBox.Text = "";

            CategorieComboBox.Text = "Dessert";
        }

        private void AjouterLaRecetteButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter cette recette?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool) ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Recette newRecette = new Recette(_gestionnaireRecettes.GetNewRecetteId(), NomTextBox.Text, CategorieComboBox.Text, SourceTextBox.Text, IngredientsTextBox.Text, PreparationTextBox.Text, IngredientsTextBox.Text);

                _gestionnaireRecettes.AddRecette(newRecette);

                EmptyWindowInformation();
            }
        }
    }
}
