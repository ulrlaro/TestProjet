using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEmploisWindow
{
    public partial class SupprimerEmploisView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireEmplois _gestionnaireEmplois;

        private ushort _emploiIndex = 0;

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

        public GestionnaireEmplois GestionnaireEmplois
        {
            get
            {
                return _gestionnaireEmplois;
            }
        }

        public ushort EmploiIndex
        {
            get
            {
                return _emploiIndex;
            }

            set
            {
                _emploiIndex = value;
            }
        }

        public SupprimerEmploisView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireEmplois = new GestionnaireEmplois("Data/Gestionnaires/Emplois.xml", _undefinedValueMessage);

            _emploiIndex = 0;

            InitializeComponent();

            UpdateWindow();
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_emploiIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (_gestionnaireEmplois.Emplois.Count == 0 || _emploiIndex == _gestionnaireEmplois.Emplois.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireEmplois.Emplois.Count > 0)
                FillWindow(_gestionnaireEmplois.GetEmploi(_emploiIndex));

            else
            {
                HideEmploiInformation();
                ShowNoEmploiMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Emploi emploiToFill)
        {
            TitreTextBox.Text = emploiToFill.Title;

            PosteTextBox.Text = emploiToFill.Position;

            DomaineTextBox.Text = emploiToFill.Domain;

            CompagnieTextBox.Text = emploiToFill.Company;

            NumeroDeContratTextBox.Text = emploiToFill.ContractNumber;

            TarifHoraireTextBox.Text = emploiToFill.HourlyRate == _undefinedValueMessage ? emploiToFill.HourlyRate : emploiToFill.HourlyRate + " $";

            DateDeDebutTextBox.Text = emploiToFill.StartDate;

            DateDeFinTextBox.Text = emploiToFill.EndDate;

            TachesTextBox.Text = emploiToFill.Tasks;

            DescriptionTextBox.Text = emploiToFill.Description;
        }

        private void HideEmploiInformation()
        {
            TitreTextBlock.Visibility = System.Windows.Visibility.Hidden;
            TitreTextBox.Visibility = System.Windows.Visibility.Hidden;

            PosteTextBlock.Visibility = System.Windows.Visibility.Hidden;
            PosteTextBox.Visibility = System.Windows.Visibility.Hidden;

            DomaineTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DomaineTextBox.Visibility = System.Windows.Visibility.Hidden;

            CompagnieTextBlock.Visibility = System.Windows.Visibility.Hidden;
            CompagnieTextBox.Visibility = System.Windows.Visibility.Hidden;

            NumeroDeContratTextBlock.Visibility = System.Windows.Visibility.Hidden;
            NumeroDeContratTextBox.Visibility = System.Windows.Visibility.Hidden;

            TarifHoraireTextBlock.Visibility = System.Windows.Visibility.Hidden;
            TarifHoraireTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinTextBox.Visibility = System.Windows.Visibility.Hidden;

            TachesTextBlock.Visibility = System.Windows.Visibility.Hidden;
            TachesTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            SupprimerEmploiButton.IsEnabled = false;
        }

        private void ShowNoEmploiMessage()
        {
            NoEmploiMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoEmploiMessageTextBlock.FontSize = 18;

            NoEmploiMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void LeftNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_emploiIndex != 0)
            {
                _emploiIndex--;

                UpdateWindow();
            }
        }

        private void RightNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_emploiIndex < _gestionnaireEmplois.Emplois.Count - 1)
            {
                _emploiIndex++;

                UpdateWindow();
            }
        }

        private void SupprimerEmploiButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SuppressionConfirmationWindow suppressionConfirmationWindow = new SuppressionConfirmationWindow("Êtes-vous sûr de vouloir supprimer cet emploi?");

            suppressionConfirmationWindow.Owner = Window.GetWindow(this);

            bool suppressionConfirmation = (bool)suppressionConfirmationWindow.ShowDialog();

            if (suppressionConfirmation)
            {
                _gestionnaireEmplois.RemoveEmploi(_emploiIndex);

                if (_emploiIndex > 0 && _emploiIndex == _gestionnaireEmplois.Emplois.Count)
                    _emploiIndex--;

                UpdateWindow();
            }
        }
    }
}
