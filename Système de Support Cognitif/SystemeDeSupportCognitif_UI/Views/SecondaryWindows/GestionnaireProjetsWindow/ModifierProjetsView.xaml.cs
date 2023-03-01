using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireProjetsWindow
{
    public partial class ModifierProjetsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireProjets _gestionnaireProjets;

        private ushort _acquisitionIndex = 0;

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

        public ushort ProjetIndex
        {
            get
            {
                return _acquisitionIndex;
            }

            set
            {
                _acquisitionIndex = value;
            }
        }

        public ModifierProjetsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireProjets = new GestionnaireProjets("Data/Gestionnaires/Projets.xml", _undefinedValueMessage);

            _acquisitionIndex = 0;

            InitializeComponent();

            UpdateWindow();
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_acquisitionIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (_gestionnaireProjets.Projets.Count == 0 || _acquisitionIndex == _gestionnaireProjets.Projets.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireProjets.Projets.Count > 0)
                FillWindow(_gestionnaireProjets.GetProjet(_acquisitionIndex));

            else
            {
                HideProjetInformation();
                ShowNoProjetMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Projet acquisitionToFill)
        {
            NomTextBox.Text = acquisitionToFill.Name;

            CategorieTextBox.Text = acquisitionToFill.Category;

            DomaineTextBox.Text = acquisitionToFill.Domain;

            DateDeDebutDatePicker.Text = acquisitionToFill.StartDate;

            DateDeFinDatePicker.Text = acquisitionToFill.EndDate;

            DateCibleDatePicker.Text = acquisitionToFill.TargetDate;

            NiveauCompleteTextBox.Text = acquisitionToFill.CompletionLevel == _undefinedValueMessage ? acquisitionToFill.CompletionLevel + " %" : acquisitionToFill.CompletionLevel;

            DescriptionTextBox.Text = acquisitionToFill.Description;
        }

        private void HideProjetInformation()
        {
            NomLabel.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            CategorieLabel.Visibility = System.Windows.Visibility.Hidden;
            CategorieTextBox.Visibility = System.Windows.Visibility.Hidden;

            DomaineLabel.Visibility = System.Windows.Visibility.Hidden;
            DomaineTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DateCibleLabel.Visibility = System.Windows.Visibility.Hidden;
            DateCibleDatePicker.Visibility = System.Windows.Visibility.Hidden;

            NiveauCompleteLabel.Visibility = System.Windows.Visibility.Hidden;
            NiveauCompleteTextBox.Visibility = System.Windows.Visibility.Hidden;
            PercentageTextBlock.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            ModifierLeProjetButton.IsEnabled = false;
        }

        private void ShowNoProjetMessage()
        {
            NoProjetMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoProjetMessageTextBlock.FontSize = 18;

            NoProjetMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void LeftNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_acquisitionIndex != 0)
            {
                _acquisitionIndex--;

                UpdateWindow();
            }
        }

        private void RightNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_acquisitionIndex < _gestionnaireProjets.Projets.Count - 1)
            {
                _acquisitionIndex++;

                UpdateWindow();
            }
        }

        private void ModifierLeProjetButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier ce projet?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool)modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newProjetId = _gestionnaireProjets.Projets[_acquisitionIndex].Id;

                Projet newProjet = new Projet(newProjetId, NomTextBox.Text, CategorieTextBox.Text, DomaineTextBox.Text, DateDeDebutDatePicker.Text, DateDeFinDatePicker.Text, DateCibleDatePicker.Text, NiveauCompleteTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireProjets.ModifyProjet(_acquisitionIndex, newProjet);
            }
        }
    }
}
