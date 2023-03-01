using System;
using System.Windows;
using System.Windows.Controls;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEmploisWindow
{
    public partial class AjouterEmploisView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireEmplois _gestionnaireEmplois;

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

        public AjouterEmploisView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireEmplois = new GestionnaireEmplois("Data/Gestionnaires/Emplois.xml", _undefinedValueMessage);

            InitializeComponent();
        }

        private void EmptyWindowInformation()
        {
            TitreTextBox.Text = PosteTextBox.Text = DomaineTextBox.Text = CompagnieTextBox.Text = NumeroDeContratTextBox.Text = TarifHoraireTextBox.Text = TachesTextBox.Text = DescriptionTextBox.Text = "";

            DateDeDebutTextBox.Text = DateDeFinTextBox.Text = DateTime.Now.ToString();
    }

        private void AjouterEmploiButton_Click(object sender, RoutedEventArgs e)
        {
            AjoutConfirmationWindow ajoutConfirmationWindow = new AjoutConfirmationWindow("Êtes-vous sûr de vouloir ajouter cet emploi?");

            ajoutConfirmationWindow.Owner = Window.GetWindow(this);

            bool ajoutConfirmation = (bool)ajoutConfirmationWindow.ShowDialog();

            if (ajoutConfirmation)
            {
                Emploi newEmploi = new Emploi(_gestionnaireEmplois.GetNewEmploiId(), TitreTextBox.Text, PosteTextBox.Text, DomaineTextBox.Text, CompagnieTextBox.Text, NumeroDeContratTextBox.Text, TarifHoraireTextBox.Text, DateDeDebutTextBox.Text, DateDeFinTextBox.Text, TachesTextBox.Text, DescriptionTextBox.Text);

                _gestionnaireEmplois.AddEmploi(newEmploi);

                EmptyWindowInformation();
            }
        }
    }
}
