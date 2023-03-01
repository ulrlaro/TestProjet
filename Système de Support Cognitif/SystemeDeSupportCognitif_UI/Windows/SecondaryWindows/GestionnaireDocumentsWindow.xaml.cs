using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SystemeDeSupportCognitif_UI.ViewModels.SecondaryWindows.GestionnaireDocumentsWindow;

namespace SystemeDeSupportCognitif_UI.Windows.SecondaryWindows
{
    public partial class GestionnaireDocumentsWindow : Window
    {
        public GestionnaireDocumentsWindow()
        {
            InitializeComponent();

            StateChanged += MainWindowStateChangeRaised;

            DataContext = new HomeDocumentsViewModel();
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

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationPanelToggleButton.IsChecked == true)
                AjouterToolTip.Visibility = ConsulterToolTip.Visibility = ModifierToolTip.Visibility = SupprimerToolTip.Visibility = Visibility.Collapsed;

            else
                AjouterToolTip.Visibility = ConsulterToolTip.Visibility = ModifierToolTip.Visibility = SupprimerToolTip.Visibility = Visibility.Visible;
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            ConsulterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ModifierButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            SupprimerButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            AjouterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new AjouterDocumentsViewModel();
        }

        private void ConsulterButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ModifierButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            SupprimerButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            ConsulterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new ConsulterDocumentsViewModel();
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ConsulterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            SupprimerButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            ModifierButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new ModifierDocumentsViewModel();
        }

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ConsulterButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ModifierButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            SupprimerButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new SupprimerDocumentsViewModel();
        }
    }
}
