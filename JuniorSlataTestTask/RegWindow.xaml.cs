using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public event EventHandler WindowClosed;

        protected virtual void OnWindowClosed(EventArgs e)
        {
            EventHandler handler = WindowClosed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public RegWindow()
        {
            InitializeComponent();
        }

        private void Register_ButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void SignIn_ButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Application.Current.MainWindow.IsActive)
                Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            OnWindowClosed(e);
        }
    }
}