using System;
using System.Windows;
using System.Windows.Input;

namespace SystemeDeSupportCognitif_UI.Windows.ConfirmationWindows
{
    public partial class AjoutConfirmationWindow : Window
    {
        public AjoutConfirmationWindow(string message)
        {
            InitializeComponent();

            StateChanged += MainWindowStateChangeRaised;

            ConfirmationMessageTextBlock.Text = message;
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

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
