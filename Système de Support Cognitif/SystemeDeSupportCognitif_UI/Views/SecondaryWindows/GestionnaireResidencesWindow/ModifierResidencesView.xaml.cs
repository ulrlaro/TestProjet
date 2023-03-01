using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireResidencesWindow
{
    public partial class ModifierResidencesView : UserControl
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

        public ModifierResidencesView()
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
            ContinentComboBox.Text = residenceToFill.Continent;

            PaysComboBox.Text = residenceToFill.Country;

            EtatProvinceTerritoireTextBox.Text = residenceToFill.StateProvinceTerritory;

            VilleTextBox.Text = residenceToFill.City;

            CodePostalTextBox.Text = residenceToFill.ZIPCode;

            AdresseTextBox.Text = residenceToFill.Address;

            NumeroDeTelephoneTextBox.Text = residenceToFill.PhoneNumber;

            LoyerTextBox.Text = residenceToFill.Rent;

            DateDeDebutDatePicker.Text = residenceToFill.StartDate;

            DateDeFinDatePicker.Text = residenceToFill.EndDate;

            DescriptionTextBox.Text = residenceToFill.Description;
        }

        private void HideResidenceInformation()
        {
            ContinentLabel.Visibility = System.Windows.Visibility.Hidden;
            ContinentComboBox.Visibility = System.Windows.Visibility.Hidden;

            PaysLabel.Visibility = System.Windows.Visibility.Hidden;
            PaysComboBox.Visibility = System.Windows.Visibility.Hidden;

            EtatProvinceTerritoireLabel.Visibility = System.Windows.Visibility.Hidden;
            EtatProvinceTerritoireTextBox.Visibility = System.Windows.Visibility.Hidden;

            VilleLabel.Visibility = System.Windows.Visibility.Hidden;
            VilleTextBox.Visibility = System.Windows.Visibility.Hidden;

            CodePostalLabel.Visibility = System.Windows.Visibility.Hidden;
            CodePostalTextBox.Visibility = System.Windows.Visibility.Hidden;

            AdresseLabel.Visibility = System.Windows.Visibility.Hidden;
            AdresseTextBox.Visibility = System.Windows.Visibility.Hidden;

            NumeroDeTelephoneLabel.Visibility = System.Windows.Visibility.Hidden;
            NumeroDeTelephoneTextBox.Visibility = System.Windows.Visibility.Hidden;

            LoyerLabel.Visibility = System.Windows.Visibility.Hidden;
            LoyerTextBox.Visibility = System.Windows.Visibility.Hidden;
            DollarTextBlock.Visibility = System.Windows.Visibility.Hidden;

            DateDeDebutLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;


            ModifierLaResidenceButton.IsEnabled = false;
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

        private void ModifierLaResidenceButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier cette résidence?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool) modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newResidenceId = _gestionnaireResidences.Residences[_residenceIndex].Id;

                Residence newResidence = new Residence(newResidenceId, ContinentComboBox.Text, PaysComboBox.Text, EtatProvinceTerritoireTextBox.Text, VilleTextBox.Text, CodePostalTextBox.Text, AdresseTextBox.Text, NumeroDeTelephoneTextBox.Text, LoyerTextBox.Text, DateDeDebutDatePicker.Text, DateDeFinDatePicker.Text, DescriptionTextBox.Text);

                _gestionnaireResidences.ModifyResidence(_residenceIndex, newResidence);
            }
        }
    }
}
