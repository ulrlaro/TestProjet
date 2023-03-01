using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEmploisWindow
{
    public partial class ModifierEmploisView : UserControl
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

        public ModifierEmploisView()
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

            TarifHoraireTextBox.Text = emploiToFill.HourlyRate;

            DateDeDebutTextBox.Text = emploiToFill.StartDate;

            DateDeFinTextBox.Text = emploiToFill.EndDate;

            TachesTextBox.Text = emploiToFill.Tasks;

            DescriptionTextBox.Text = emploiToFill.Description;
        }

        private void HideEmploiInformation()
        {
            TitreLabel.Visibility = System.Windows.Visibility.Hidden;
            TitreTextBox.Visibility = System.Windows.Visibility.Hidden;

            PosteLabel.Visibility = System.Windows.Visibility.Hidden;
            PosteTextBox.Visibility = System.Windows.Visibility.Hidden;

            DomaineLabel.Visibility = System.Windows.Visibility.Hidden;
            DomaineTextBox.Visibility = System.Windows.Visibility.Hidden;

            CompagnieLabel.Visibility = System.Windows.Visibility.Hidden;
            CompagnieTextBox.Visibility = System.Windows.Visibility.Hidden;

            NumeroDeContratLabel.Visibility = System.Windows.Visibility.Hidden;
            NumeroDeContratTextBox.Visibility = System.Windows.Visibility.Hidden;

            TarifHoraireLabel.Visibility = System.Windows.Visibility.Hidden;
            TarifHoraireTextBox.Visibility = System.Windows.Visibility.Hidden;
            DollarTextBlock.Visibility= System.Windows.Visibility.Hidden;

            DateDeDebutLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeDebutTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeFinLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeFinTextBox.Visibility = System.Windows.Visibility.Hidden;

            TachesLabel.Visibility = System.Windows.Visibility.Hidden;
            TachesTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            ModifierEmploiButton.IsEnabled = false;
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

        private void ModifierEmploiButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier cet emploi?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool) modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newEmploiId = _gestionnaireEmplois.Emplois[_emploiIndex].Id;

                Emploi newEmploi = new Emploi(newEmploiId, TitreTextBox.Text, PosteTextBox.Text, DomaineTextBox.Text, CompagnieTextBox.Text, NumeroDeContratTextBox.Text, TarifHoraireTextBox.Text, DateDeDebutTextBox.Text, DateDeFinTextBox.Text, TachesTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireEmplois.ModifyEmploi(_emploiIndex, newEmploi);
            }
        }
    }
}
