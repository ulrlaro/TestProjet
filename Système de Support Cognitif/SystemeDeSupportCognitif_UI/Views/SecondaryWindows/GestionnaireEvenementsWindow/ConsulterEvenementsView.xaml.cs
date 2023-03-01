using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEvenementsWindow
{
    public partial class ConsulterEvenementsView : UserControl
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

        public ConsulterEvenementsView()
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

            DateDeDebutTextBox.Text = evenementToFill.StartDate;

            DateDeFinTextBox.Text = evenementToFill.EndDate;

            DescriptionTextBox.Text = evenementToFill.Description;
        }

        private void HideEvenementInformation()
        {
            NomTextBlock.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            CategorieTextBlock.Visibility = System.Windows.Visibility.Hidden;
            CategorieTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;
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
    }
}
