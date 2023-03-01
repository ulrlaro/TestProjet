using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireResidencesWindow
{
    public partial class SupprimerResidencesView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireResidences _gestionnaireResidences;

        private ushort _residenceIndex = 0;

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

        public GestionnaireResidences GestionnaireResidences
        {
            get
            {
                return _gestionnaireResidences;
            }
        }

        public ushort ResidenceIndex
        {
            get
            {
                return _residenceIndex;
            }

            set
            {
                _residenceIndex = value;
            }
        }

        public SupprimerResidencesView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireResidences = new GestionnaireResidences("Data/Gestionnaires/Residences.xml", _undefinedValueMessage);

            _residenceIndex = 0;

            InitializeComponent();

            UpdateWindow();
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_residenceIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (_gestionnaireResidences.Residences.Count == 0 || _residenceIndex == _gestionnaireResidences.Residences.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireResidences.Residences.Count > 0)
                FillWindow(_gestionnaireResidences.GetResidence(_residenceIndex));

            else
            {
                HideResidenceInformation();
                ShowNoResidenceMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Residence residenceToFill)
        {
            ContinentTextBox.Text = residenceToFill.Continent;

            PaysTextBox.Text = residenceToFill.Country;

            EtatProvinceTerritoireTextBox.Text = residenceToFill.StateProvinceTerritory;

            VilleTextBox.Text = residenceToFill.City;

            CodePostalTextBox.Text = residenceToFill.ZIPCode;

            AdresseTextBox.Text = residenceToFill.Address;

            NumeroDeTelephoneTextBox.Text = residenceToFill.PhoneNumber;

            LoyerTextBox.Text = residenceToFill.Rent == _undefinedValueMessage ? residenceToFill.Rent : residenceToFill.Rent + " $";

            DateDeDebutTextBox.Text = residenceToFill.StartDate;

            DateDeFinTextBox.Text = residenceToFill.EndDate;

            DescriptionTextBox.Text = residenceToFill.Description;

        }

        private void HideResidenceInformation()
        {
            ContinentTextBlock.Visibility = System.Windows.Visibility.Hidden;
            ContinentTextBox.Visibility = System.Windows.Visibility.Hidden;

            PaysTextBlock.Visibility = System.Windows.Visibility.Hidden;
            PaysTextBox.Visibility = System.Windows.Visibility.Hidden;

            EtatProvinceTerritoireTextBlock.Visibility = System.Windows.Visibility.Hidden;
            EtatProvinceTerritoireTextBox.Visibility = System.Windows.Visibility.Hidden;

            VilleTextBlock.Visibility = System.Windows.Visibility.Hidden;
            VilleTextBox.Visibility = System.Windows.Visibility.Hidden;

            CodePostalTextBlock.Visibility = System.Windows.Visibility.Hidden;
            CodePostalTextBox.Visibility = System.Windows.Visibility.Hidden;

            AdresseTextBlock.Visibility = System.Windows.Visibility.Hidden;
            AdresseTextBox.Visibility = System.Windows.Visibility.Hidden;

            NumeroDeTelephoneTextBlock.Visibility = System.Windows.Visibility.Hidden;
            NumeroDeTelephoneTextBox.Visibility = System.Windows.Visibility.Hidden;

            LoyerTextBlock.Visibility = System.Windows.Visibility.Hidden;
            LoyerTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            SupprimerLaResidenceButton.IsEnabled = false;
        }

        private void ShowNoResidenceMessage()
        {
            NoResidenceMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoResidenceMessageTextBlock.FontSize = 18;

            NoResidenceMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void LeftNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_residenceIndex != 0)
            {
                _residenceIndex--;

                UpdateWindow();
            }
        }

        private void RightNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_residenceIndex < _gestionnaireResidences.Residences.Count - 1)
            {
                _residenceIndex++;

                UpdateWindow();
            }
        }

        private void SupprimerLaResidenceButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SuppressionConfirmationWindow suppressionConfirmationWindow = new SuppressionConfirmationWindow("Êtes-vous sûr de vouloir supprimer cette résidence?");

            suppressionConfirmationWindow.Owner = Window.GetWindow(this);

            bool suppressionConfirmation = (bool) suppressionConfirmationWindow.ShowDialog();

            if (suppressionConfirmation)
            {
                _gestionnaireResidences.RemoveResidence(_residenceIndex);

                if (_residenceIndex > 0 && _residenceIndex == _gestionnaireResidences.Residences.Count)
                    _residenceIndex--;

                UpdateWindow();
            }
        }
    }
}
