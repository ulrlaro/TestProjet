using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using SystemeDeSupportCognitif_Affaires;
using SystemeDeSupportCognitif_UI.Windows.SearchWindow;

namespace SystemeDeSupportCognitif_UI.Views.SecondaryWindows.GestionnaireEmploisWindow
{
    public partial class ConsulterEmploisView : UserControl
    {
        private string _undefinedValueMessage;

        private readonly GestionnaireEmplois _gestionnaireEmplois;

        private ushort _emploiIndex = 0;

        private List<string> _listeType = new List<string>();

        private string _type;

        private string _recherche;

        private List<Emploi> _nouvelleListe = new List<Emploi>();

        private bool EstFiltré = false;

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

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public string Recherche
        {
            get
            {
                return _recherche;
            }
            set
            {
                _recherche = value;
            }
        }

        public ConsulterEmploisView()
        {
            _undefinedValueMessage = "Non défini.";

            _gestionnaireEmplois = new GestionnaireEmplois("Data/Gestionnaires/Emplois.xml", _undefinedValueMessage);

            _emploiIndex = 0;

            FillTypeList();

            InitializeComponent();

            UpdateWindow();
        }

        private void FillTypeList()
        {
            _listeType.Add("titre");
            _listeType.Add("poste");
            _listeType.Add("domaine");
            _listeType.Add("compagnie");
            _listeType.Add("numéro de contrat");
            _listeType.Add("tarif Horaire");
            _listeType.Add("DateDebut");
            _listeType.Add("DateFin");
        }

        private void AdjustNavigationButtonsWidth()
        {
            if (_emploiIndex == 0)
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(10);

            else
                LeftNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            if (!EstFiltré)
            {
                if (_gestionnaireEmplois.Emplois.Count == 0 || _emploiIndex == _gestionnaireEmplois.Emplois.Count - 1)
                    RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

                else
                    RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);
            }
            else
            {
                if (_gestionnaireEmplois.EmploisFiltre.Count == 0 || _emploiIndex == _gestionnaireEmplois.EmploisFiltre.Count - 1)
                    RightNavigationButtonColumn.Width = new System.Windows.GridLength(10);

                else
                    RightNavigationButtonColumn.Width = new System.Windows.GridLength(60);

            }
        }

        private void UpdateWindow()
        {
            //if(_type == "tout" || _type == "")
            if(EstFiltré == false) { 
            
                if (_gestionnaireEmplois.Emplois.Count > 0)
                    FillWindow(_gestionnaireEmplois.GetEmploi(_emploiIndex));

                else
                {
                    HideEmploiInformation();
                    ShowNoEmploiMessage();
                }
            }
            else
            {
                if (_gestionnaireEmplois.EmploisFiltre.Count > 0)
                    FillWindow(_gestionnaireEmplois.GetEmploiFiltre(_emploiIndex));

                else
                {
                    HideEmploiInformation();
                    ShowNoEmploiRechercheMessage();
                }
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
        }

        private void ShowNoEmploiMessage()
        {
            NoEmploiMessageTextBlock.Text = "Vous n'avez pas d'emploi répertorié. Veuillez en ajouter un pour les consulter!";

            NoEmploiMessageTextBlock.Margin = new System.Windows.Thickness(0, 10, 0, 10);

            NoEmploiMessageTextBlock.FontSize = 18;

            NoEmploiMessageTextBlock.Visibility = System.Windows.Visibility.Visible;
        }

        private void ShowNoEmploiRechercheMessage()
        {
            NoEmploiMessageTextBlock.Text = "Aucun emploi ne correspond à votre recherche! Veuillez essayer d'autre mot clés!";

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

        private void RechercherButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RechercheWindow rechercheWindow = new RechercheWindow(_listeType);

            rechercheWindow.ShowDialog();

           _emploiIndex= 0;


            _type = rechercheWindow.Type;

            _recherche = rechercheWindow.Recherche;
            if((_type != "") && (_recherche != ""))
            {
                EstFiltré = true;
                _nouvelleListe = _gestionnaireEmplois.FindEmploi(_recherche, _type);
                UpdateWindow();
            }
            



        }
    }
}
