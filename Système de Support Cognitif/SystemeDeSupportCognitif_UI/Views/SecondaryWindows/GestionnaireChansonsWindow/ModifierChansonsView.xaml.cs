using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireChansonsWindow
{
    public partial class ModifierChansonsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireChansons _gestionnaireChansons;

        private ushort _chansonIndex = 0;

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

        public GestionnaireChansons GestionnaireChansons
        {
            get
            {
                return _gestionnaireChansons;
            }
        }

        public ushort ChansonIndex
        {
            get
            {
                return _chansonIndex;
            }

            set
            {
                _chansonIndex = value;
            }
        }

        public ModifierChansonsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireChansons = new GestionnaireChansons("Data/Gestionnaires/Chansons.xml", _undefinedValueMessage);

            _chansonIndex = 0;

            InitializeComponent();

            UpdateWindow();
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_chansonIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (_gestionnaireChansons.Chansons.Count == 0 || _chansonIndex == _gestionnaireChansons.Chansons.Count - 1)
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
        }

        private void UpdateWindow()
        {
            if (_gestionnaireChansons.Chansons.Count > 0)
                FillWindow(_gestionnaireChansons.GetChanson(_chansonIndex));

            else
            {
                HideChansonInformation();
                ShowNoChansonMessage();
            }

            AdjustNavigationButtonsWidth();
        }

        private void FillWindow(Chanson chansonToFill)
        {
            TitreTextBox.Text = chansonToFill.Title;

            DureeTextBox.Text = chansonToFill.Length;

            AuteursTextBox.Text = chansonToFill.Authors;

            CompositeursTextBox.Text = chansonToFill.Composers;

            InterpretesTextBox.Text = chansonToFill.Performers;

            AlbumTextBox.Text = chansonToFill.Album;

            MaisonDeDisqueTextBox.Text = chansonToFill.RecordLabel;

            DateDeSortieDatePicker.Text = chansonToFill.ReleaseDate;

            ParolesTextBox.Text = chansonToFill.Lyrics;

            DescriptionTextBox.Text = chansonToFill.Description;
        }

        private void HideChansonInformation()
        {
            TitreLabel.Visibility = System.Windows.Visibility.Hidden;
            TitreTextBox.Visibility = System.Windows.Visibility.Hidden;

            DureeLabel.Visibility = System.Windows.Visibility.Hidden;
            DureeTextBox.Visibility = System.Windows.Visibility.Hidden;

            AuteursLabel.Visibility = System.Windows.Visibility.Hidden;
            AuteursTextBox.Visibility = System.Windows.Visibility.Hidden;

            CompositeursLabel.Visibility = System.Windows.Visibility.Hidden;
            CompositeursTextBox.Visibility = System.Windows.Visibility.Hidden;

            InterpretesLabel.Visibility = System.Windows.Visibility.Hidden;
            InterpretesTextBox.Visibility = System.Windows.Visibility.Hidden;

            AlbumLabel.Visibility = System.Windows.Visibility.Hidden;
            AlbumTextBox.Visibility = System.Windows.Visibility.Hidden;

            MaisonDeDisqueLabel.Visibility = System.Windows.Visibility.Hidden;
            MaisonDeDisqueTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeSortieLabel.Visibility = System.Windows.Visibility.Hidden;
            DateDeSortieDatePicker.Visibility = System.Windows.Visibility.Hidden;

            ParolesLabel.Visibility = System.Windows.Visibility.Hidden;
            ParolesTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionLabel.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;

            ModifierLaChansonButton.IsEnabled = false;
        }

        private void ShowNoChansonMessage()
        {
            NoChansonMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoChansonMessageTextBlock.FontSize = 18;

            NoChansonMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void LeftNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_chansonIndex != 0)
            {
                _chansonIndex--;

                UpdateWindow();
            }
        }

        private void RightNavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_chansonIndex < _gestionnaireChansons.Chansons.Count - 1)
            {
                _chansonIndex++;

                UpdateWindow();
            }
        }

        private void ModifierLaChansonButton_Click(object sender, RoutedEventArgs e)
        {
            ModificationConfirmationWindow modificationConfirmationWindow = new ModificationConfirmationWindow("Êtes-vous sûr de vouloir modifier cette chanson?");

            modificationConfirmationWindow.Owner = Window.GetWindow(this);

            bool modificationConfirmation = (bool) modificationConfirmationWindow.ShowDialog();

            if (modificationConfirmation)
            {
                ushort newChansonId = _gestionnaireChansons.Chansons[_chansonIndex].Id;

                Chanson newChanson = new Chanson(newChansonId, TitreTextBox.Text, DureeTextBox.Text, AuteursTextBox.Text, CompositeursTextBox.Text, InterpretesTextBox.Text, AlbumTextBox.Text, MaisonDeDisqueTextBox.Text, DateDeSortieDatePicker.Text, ParolesTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireChansons.ModifyChanson(_chansonIndex, newChanson);
            }
        }
    }
}
