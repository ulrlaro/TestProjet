using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEvenementsWindow
{
    public partial class ModifierEvenementsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireEvenements _gestionnaireEvenements;

        private ushort _evenementIndex = 0;

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

        public ushort EvenementIndex
        {
            get
            {
                return _evenementIndex;
            }

            set
            {
                _evenementIndex = value;
            }
        }

        public ModifierEvenementsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireEvenements = new GestionnaireEvenements("Data/Gestionnaires/Evenements.xml", _undefinedValueMessage);

            _evenementIndex = 0;

            InitializeComponent();

            UpdateWindow();
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_evenementIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (_gestionnaireEvenements.Evenements.Count == 0 || _evenementIndex == _gestionnaireEvenements.Evenements.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireEvenements.Evenements.Count > 0)
                FillWindow(_gestionnaireEvenements.GetEvenement(_evenementIndex));

            else
            {
                HideEvenementInformation();
                ShowNoEvenementMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Evenement evenementToFill)
        {
            NomTextBox.Text = evenementToFill.Name;

            CategorieTextBox.Text = evenementToFill.Category;

            DateDeDebutDatePicker.Text = evenementToFill.StartDate;

            DateDeFinDatePicker.Text = evenementToFill.EndDate;

            DescriptionTextBox.Text = evenementToFill.Description;
        }

        private void HideEvenementInformation()
        {
            NomLabel.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            CategorieLabel.Visibility = System.Windows.Visibility.Hidden;
            CategorieTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;


            ModifierEvenementButton.IsEnabled = false;
        }

        private void ShowNoEvenementMessage()
        {
            NoEvenementMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoEvenementMessageTextBlock.FontSize = 18;

            NoEvenementMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void LeftNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_evenementIndex != 0)
            {
                _evenementIndex--;

                UpdateWindow();
            }
        }

        private void RightNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_evenementIndex < _gestionnaireEvenements.Evenements.Count - 1)
            {
                _evenementIndex++;

                UpdateWindow();
            }
        }

        private void ModifierEvenementButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier cet événement?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool)modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newEvenementId = _gestionnaireEvenements.Evenements[_evenementIndex].Id;

                Evenement newEvenement = new Evenement(newEvenementId, NomTextBox.Text, CategorieTextBox.Text, DateDeDebutDatePicker.Text, DateDeFinDatePicker.Text, DescriptionTextBox.Text);

                _gestionnaireEvenements.ModifyEvenement(_evenementIndex, newEvenement);
            }
        }
    }
}
