using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemeDeSupportCognitif_UI.Windows.SearchWindow
{
    public partial class RechercheWindow : Window
    {
        public string Type
        {
            get
            {
               return TypeComboBox.Text.ToLower();
            }
        }

        public string Recherche
        {
            get
            {
                return SearchTextbox.Text.ToLower();
            }
        }
        public RechercheWindow(List<string> listePropiete)
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = listePropiete;
            StateChanged += MainWindowStateChangeRaised;
        }

        private void MinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void MaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void RestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void MainWindowStateChangeRaised(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MaximizeWindowButton.Visibility = Visibility.Collapsed;

                RestoreWindowButton.Visibility = Visibility.Visible;
            }

            else
            {
                MaximizeWindowButton.Visibility = Visibility.Visible;

                RestoreWindowButton.Visibility = Visibility.Collapsed;
            }
        }

        private void RechercherButton_Click(object sender, RoutedEventArgs e)
        {
            if(Type != "")
                DialogResult = true;
            else
                DialogResult = false;
        }
    }
}
