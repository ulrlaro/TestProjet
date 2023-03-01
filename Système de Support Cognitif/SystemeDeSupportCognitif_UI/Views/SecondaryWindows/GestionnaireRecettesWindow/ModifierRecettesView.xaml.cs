using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireRecettesWindow
{
    public partial class ModifierRecettesView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireRecettes _gestionnaireRecettes;

        private ushort _recetteIndex = 0;

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

        public ushort RecetteIndex
        {
            get
            {
                return _recetteIndex;
            }

            set
            {
                _recetteIndex = value;
            }
        }

        public ModifierRecettesView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireRecettes = new GestionnaireRecettes("Data/Gestionnaires/Recettes.xml", _undefinedValueMessage);

            _recetteIndex = 0;

            InitializeComponent();

            UpdateWindow();
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_recetteIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (_gestionnaireRecettes.Recettes.Count == 0 || _recetteIndex == _gestionnaireRecettes.Recettes.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireRecettes.Recettes.Count > 0)
                FillWindow(_gestionnaireRecettes.GetRecette(_recetteIndex));

            else
            {
                HideRecetteInformation();
                ShowNoRecetteMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Recette recetteToFill)
        {
            NomTextBox.Text = recetteToFill.Name;

            CategorieComboBox.Text = recetteToFill.Category;

            SourceTextBox.Text = recetteToFill.Source;

            IngredientsTextBox.Text = recetteToFill.Ingredients;

            PreparationTextBox.Text = recetteToFill.Preparation;

            DescriptionTextBox.Text = recetteToFill.Description;
        }

        private void HideRecetteInformation()
        {
            NomLabel.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            CategorieLabel.Visibility = System.Windows.Visibility.Hidden;
            CategorieComboBox.Visibility = System.Windows.Visibility.Hidden;

            SourceLabel.Visibility = System.Windows.Visibility.Hidden;
            SourceTextBox.Visibility = System.Windows.Visibility.Hidden;

            IngredientsLabel.Visibility = System.Windows.Visibility.Hidden;
            IngredientsTextBox.Visibility = System.Windows.Visibility.Hidden;

            PreparationLabel.Visibility = System.Windows.Visibility.Hidden;
            PreparationTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            ModifierLaRecetteButton.IsEnabled = false;
        }

        private void ShowNoRecetteMessage()
        {
            NoRecetteMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoRecetteMessageTextBlock.FontSize = 18;

            NoRecetteMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void LeftNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_recetteIndex != 0)
            {
                _recetteIndex--;

                UpdateWindow();
            }
        }

        private void RightNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_recetteIndex < _gestionnaireRecettes.Recettes.Count - 1)
            {
                _recetteIndex++;

                UpdateWindow();
            }
        }

        private void ModifierLaRecetteButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier cette recette?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool)modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newRecetteId = _gestionnaireRecettes.Recettes[_recetteIndex].Id;

                Recette newRecette = new Recette(newRecetteId, NomTextBox.Text, CategorieComboBox.Text, SourceTextBox.Text, IngredientsTextBox.Text, PreparationTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireRecettes.ModifyRecette(_recetteIndex, newRecette);
            }
        }
    }
}
