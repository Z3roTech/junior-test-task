using System;
using System.Windows;

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for MentorPanelWindow.xaml
    /// </summary>
    public partial class MentorPanelWindow : Window
    {
        public event EventHandler SignOut;

        protected virtual void OnSignOut(EventArgs e)
        {
            EventHandler handler = SignOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public MentorPanelWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dataContainer.MaxWidth = this.ActualWidth - controlContainer.ActualWidth - (double)100;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Application.Current.MainWindow.IsActive)
                Application.Current.Shutdown();
            else OnSignOut(EventArgs.Empty);
        }

        private void SignOutBtnClick(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Show();
            this.Close();
        }
    }
}