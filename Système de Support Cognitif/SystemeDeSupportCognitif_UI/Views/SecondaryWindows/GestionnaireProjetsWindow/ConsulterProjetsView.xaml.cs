using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireProjetsWindow
{
    public partial class ConsulterProjetsView : UserControl
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

        public ConsulterProjetsView()
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

            DateDeDebutTextBox.Text = acquisitionToFill.StartDate;

            DateDeFinTextBox.Text = acquisitionToFill.EndDate;

            DateCibleTextBox.Text = acquisitionToFill.TargetDate;

            NiveauCompleteTextBox.Text = acquisitionToFill.CompletionLevel == _undefinedValueMessage ? acquisitionToFill.CompletionLevel : acquisitionToFill.CompletionLevel + " %";

            DescriptionTextBox.Text = acquisitionToFill.Description;
        }

        private void HideProjetInformation()
        {
            NomTextBlock.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            CategorieTextBlock.Visibility = System.Windows.Visibility.Hidden;
            CategorieTextBox.Visibility = System.Windows.Visibility.Hidden;

            DomaineTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DomaineTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateCibleTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateCibleTextBox.Visibility = System.Windows.Visibility.Hidden;

            NiveauCompleteTextBlock.Visibility = System.Windows.Visibility.Hidden;
            NiveauCompleteTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;
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
    }
}
