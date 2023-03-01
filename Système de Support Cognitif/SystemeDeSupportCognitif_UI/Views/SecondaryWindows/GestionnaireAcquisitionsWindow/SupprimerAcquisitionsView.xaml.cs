using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireAcquisitionsWindow
{
    public partial class SupprimerAcquisitionsView : UserControl
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

        public SupprimerAcquisitionsView()
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

            DateAchatTextBox.Text = acquisitionToFill.PurchaseDate;

            DateDeRebutTextBox.Text = acquisitionToFill.DisposalDate;

            DateExpirationDeLaGarantieTextBox.Text = acquisitionToFill.WarrantyExpirationDate;

            GarantieTextBox.Text = acquisitionToFill.Warranty;

            DescriptionTextBox.Text = acquisitionToFill.Description;
        }

        private void HideAcquisitionInformation()
        {
            NomTextBlock.Visibility = System.Windows.Visibility.Hidden;
            NomTextBox.Visibility = System.Windows.Visibility.Hidden;

            PrixTextBlock.Visibility = System.Windows.Visibility.Hidden;
            PrixTextBox.Visibility = System.Windows.Visibility.Hidden;

            VendeurTextBlock.Visibility = System.Windows.Visibility.Hidden;
            VendeurTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateAchatTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateAchatTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeRebutTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeRebutTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateExpirationDeLaGarantieTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateExpirationDeLaGarantieTextBox.Visibility = System.Windows.Visibility.Hidden;

            GarantieTextBlock.Visibility = System.Windows.Visibility.Hidden;
            GarantieTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            SupprimerAcquisitionButton.IsEnabled = false;
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

        private void SupprimerAcquisitionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SuppressionConfirmationWindow suppressionConfirmationWindow = new SuppressionConfirmationWindow("Êtes-vous sûr de vouloir supprimer cette acquisition?");

            suppressionConfirmationWindow.Owner = Window.GetWindow(this);

            bool suppressionConfirmation = (bool)suppressionConfirmationWindow.ShowDialog();

            if (suppressionConfirmation)
            {
                _gestionnaireAcquisitions.RemoveAcquisition(_acquisitionIndex);

                if (_acquisitionIndex > 0 && _acquisitionIndex == _gestionnaireAcquisitions.Acquisitions.Count)
                    _acquisitionIndex--;

                UpdateWindow();
            }
        }
    }
}
