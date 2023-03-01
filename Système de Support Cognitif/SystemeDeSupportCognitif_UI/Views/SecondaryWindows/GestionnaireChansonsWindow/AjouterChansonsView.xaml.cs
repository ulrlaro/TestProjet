using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireChansonsWindow
{
    public partial class AjouterChansonsView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireChansons _gestionnaireChansons;

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

        public AjouterChansonsView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireChansons = new GestionnaireChansons("Data/Gestionnaires/Chansons.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            TitreTextBox.Text = DureeTextBox.Text = AuteursTextBox.Text = CompositeursTextBox.Text = InterpretesTextBox.Text = AlbumTextBox.Text = MaisonDeDisqueTextBox.Text = ParolesTextBox.Text = DescriptionTextBox.Text = "";

            DateDeSortieDatePicker.Text = DateTime.Now.ToString();
        }

        private void AjouterLaChansonButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter cette chanson?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool)ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Chanson newChanson = new Chanson(_gestionnaireChansons.GetNewChansonId(), TitreTextBox.Text, DureeTextBox.Text, AuteursTextBox.Text, CompositeursTextBox.Text, InterpretesTextBox.Text, AlbumTextBox.Text, MaisonDeDisqueTextBox.Text, DateDeSortieDatePicker.Text, ParolesTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireChansons.AddChanson(newChanson);

                EmptyWindowInformation();
            }
        }
    }
}
