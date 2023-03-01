using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireChansonsWindow
{
    public partial class ConsulterChansonsView : UserControl
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

        public ConsulterChansonsView()
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

            DateDeSortieTextBox.Text = chansonToFill.ReleaseDate;

            ParolesTextBox.Text = chansonToFill.Lyrics;

            DescriptionTextBox.Text = chansonToFill.Description;
        }

        private void HideChansonInformation()
        {
            TitreTextBlock.Visibility = System.Windows.Visibility.Hidden;
            TitreTextBox.Visibility = System.Windows.Visibility.Hidden;

            DureeTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DureeTextBox.Visibility = System.Windows.Visibility.Hidden;

            AuteursTextBlock.Visibility = System.Windows.Visibility.Hidden;
            AuteursTextBox.Visibility = System.Windows.Visibility.Hidden;

            CompositeursTextBlock.Visibility = System.Windows.Visibility.Hidden;
            CompositeursTextBox.Visibility = System.Windows.Visibility.Hidden;

            InterpretesTextBlock.Visibility = System.Windows.Visibility.Hidden;
            InterpretesTextBox.Visibility = System.Windows.Visibility.Hidden;

            AlbumTextBlock.Visibility = System.Windows.Visibility.Hidden;
            AlbumTextBox.Visibility = System.Windows.Visibility.Hidden;

            MaisonDeDisqueTextBlock.Visibility = System.Windows.Visibility.Hidden;
            MaisonDeDisqueTextBox.Visibility = System.Windows.Visibility.Hidden;

            DateDeSortieTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DateDeSortieTextBox.Visibility = System.Windows.Visibility.Hidden;

            ParolesTextBlock.Visibility = System.Windows.Visibility.Hidden;
            ParolesTextBox.Visibility = System.Windows.Visibility.Hidden;

            DescriptionTextBlock.Visibility = System.Windows.Visibility.Hidden;
            DescriptionTextBox.Visibility = System.Windows.Visibility.Hidden;
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
    }
}
