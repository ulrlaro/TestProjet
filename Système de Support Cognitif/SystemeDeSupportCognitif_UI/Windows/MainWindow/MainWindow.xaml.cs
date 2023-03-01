using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SystemeDeSupportCognitif_UI.ViewModels.MainWindow;

namespace SystemeDeSupportCognitif_UI.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StateChanged += MainWindowStateChangeRaised;

            DataContext = new HomeViewModel();
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
                CompteToolTip.Visibility = ChronologieToolTip.Visibility = GestionnairesToolTip.Visibility = ParametresToolTip.Visibility = Visibility.Collapsed;

            else
                CompteToolTip.Visibility = ChronologieToolTip.Visibility = GestionnairesToolTip.Visibility = ParametresToolTip.Visibility = Visibility.Visible;
        }

        private void CompteButton_Click(object sender, RoutedEventArgs e)
        {
            ChronologieButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            GestionnairesButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ParametresButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            CompteButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new CompteViewModel();
        }

        private void ChronologieButton_Click(object sender, RoutedEventArgs e)
        {
            CompteButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            GestionnairesButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ParametresButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            ChronologieButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new ChronologieViewModel();
        }

        private void GestionnairesButton_Click(object sender, RoutedEventArgs e)
        {
            CompteButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ChronologieButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ParametresButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            GestionnairesButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new GestionnairesViewModel();
        }

        private void ParametresButton_Click(object sender, RoutedEventArgs e)
        {
            CompteButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            ChronologieButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));
            GestionnairesButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 45, 45, 45));

            ParametresButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            DataContext = new ParametresViewModel();
        }
    }
}
