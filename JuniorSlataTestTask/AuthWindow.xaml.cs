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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void SignIn_ButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void Register_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegWindow regWin = new RegWindow();
            regWin.WindowClosed += ChildWindow_Closed;
            regWin.Show();
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            foreach (UIElement ctl in containerCanvas.Children)
            {
                if (ctl is TextBox)
                    ((TextBox)ctl).Clear();
                if (ctl is PasswordBox)
                    ((PasswordBox)ctl).Clear();
            }
        }
    }
}