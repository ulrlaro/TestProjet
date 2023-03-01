using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireAcquisitionsWindow
{
    public partial class ModifierAcquisitionsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireAcquisitions _gestionnaireAcquisitions;

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

        public GestionnaireAcquisitions GestionnaireAcquisitions
        {
            get
            {
                return _gestionnaireAcquisitions;
            }
        }

        public ushort AcquisitionIndex
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

        public ModifierAcquisitionsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireAcquisitions = new GestionnaireAcquisitions("Data/Gestionnaires/Acquisitions.xml", _undefinedValueMessage);

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

            if (_gestionnaireAcquisitions.Acquisitions.Count == 0 || _acquisitionIndex == _gestionnaireAcquisitions.Acquisitions.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireAcquisitions.Acquisitions.Count > 0)
                FillWindow(_gestionnaireAcquisitions.GetAcquisition(_acquisitionIndex));

            else
            {
                HideAcquisitionInformation();
                ShowNoAcquisitionMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Acquisition acquisitionToFill)
        {
            NomTextBox.Text = acquisitionToFill.Name;

            PrixTextBox.Text = acquisitionToFill.Price == _undefinedValueMessage ? acquisitionToFill.Price : acquisitionToFill.Price + " $";

            VendeurTextBox.Text = acquisitionToFill.Seller;

            DateAchatDatePicker.Text = acquisitionToFill.PurchaseDate;

            DateDeRebutDatePicker.Text = acquisitionToFill.DisposalDate;

            DateExpirationDeLaGarantieDatePicker.Text = acquisitionToFill.WarrantyExpirationDate;

            GarantieTextBox.Text = acquisitionToFill.Warranty;

            DescriptionTextBox.Text = acquisitionToFill.Description;
        }

        private void HideAcquisitionInformation()
        {
            NomLabel.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            PrixLabel.Visibility = System.Windows.Visibility.Hidden;
            PrixTextBox.Visibility = System.Windows.Visibility.Hidden;
            DollarTextBlock.Visibility = System.Windows.Visibility.Hidden;

            VendeurLabel.Visibility = System.Windows.Visibility.Hidden;
            VendeurTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateAchatLabel.Visibility = System.Windows.Visibility.Hidden;
            DateAchatDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DateDeRebutLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeRebutDatePicker.Visibility = System.Windows.Visibility.Hidden;

            DateExpirationDeLaGarantieLabel.Visibility = System.Windows.Visibility.Hidden;
            DateExpirationDeLaGarantieDatePicker.Visibility = System.Windows.Visibility.Hidden;

            GarantieLabel.Visibility = System.Windows.Visibility.Hidden;
            GarantieTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            ModifierAcquisitionButton.IsEnabled = false;
        }

        private void ShowNoAcquisitionMessage()
        {
            NoAcquisitionMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoAcquisitionMessageTextBlock.FontSize = 18;

            NoAcquisitionMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
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
            if (_acquisitionIndex < _gestionnaireAcquisitions.Acquisitions.Count - 1)
            {
                _acquisitionIndex++;

                UpdateWindow();
            }
        }

        private void ModifierAcquisitionButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier cette acquisition?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool)modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newAcquisitionId = _gestionnaireAcquisitions.Acquisitions[_acquisitionIndex].Id;

                Acquisition newAcquisition = new Acquisition(newAcquisitionId, NomTextBox.Text, PrixTextBox.Text, VendeurTextBox.Text, DateAchatDatePicker.Text, DateDeRebutDatePicker.Text, DateExpirationDeLaGarantieDatePicker.Text, GarantieTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireAcquisitions.ModifyAcquisition(_acquisitionIndex, newAcquisition);
            }
        }
    }
}
