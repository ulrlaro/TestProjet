using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemeDeSupportCognitif_UI.Windows.SecondaryWindows;

namespace SystemeDeSupportCognitif_UI.Views.MainWindow
{
    public partial class GestionnairesView : UserControl
    {
        public GestionnairesView()
        {
            InitializeComponent();
        }

        private void GestionnaireResidencesButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireResidencesWindow residencesWindow = new GestionnaireResidencesWindow();

            residencesWindow.Show();
        }

        private void GestionnaireAcquisitionsButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireAcquisitionsWindow acquisitionsWindow = new GestionnaireAcquisitionsWindow();

            acquisitionsWindow.Show();
        }

        private void GestionnaireEvenementsButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireEvenementsWindow evenementsWindow = new GestionnaireEvenementsWindow();

            evenementsWindow.Show();
        }

        private void GestionnaireDemarchesButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireDemarchesWindow demarchesWindow = new GestionnaireDemarchesWindow();

            demarchesWindow.Show();
        }

        private void GestionnaireEmploisButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireEmploisWindow emploisWindow = new GestionnaireEmploisWindow();

            emploisWindow.Show();
        }

        private void GestionnaireChansonsButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireChansonsWindow chansonsWindow = new GestionnaireChansonsWindow();

            chansonsWindow.Show();
        }

        private void GestionnaireRecettesButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireRecettesWindow recettesWindow = new GestionnaireRecettesWindow();

            recettesWindow.Show();
        }

        private void GestionnaireDocumentsButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireDocumentsWindow documentsWindow = new GestionnaireDocumentsWindow();

            documentsWindow.Show();
        }

        private void GestionnaireProjetsButton_Click(object sender, MouseButtonEventArgs e)
        {
            GestionnaireProjetsWindow projetsWindow = new GestionnaireProjetsWindow();

            projetsWindow.Show();
        }
    }
}
