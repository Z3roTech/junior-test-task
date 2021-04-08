using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuniorSlataTestTask.Controls
{
    /// <summary>
    /// Interaction logic for ChangePasswordControl.xaml
    /// </summary>
    public partial class ChangePasswordControl : UserControl
    {
        public event EventHandler AcceptChanges;

        private string password;
        public string Password { get => password; set => password = value; }

        protected virtual void OnAceeptChanges(EventArgs e)
        {
            EventHandler handler = AcceptChanges;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public ChangePasswordControl()
        {
            InitializeComponent();
            Password = "";
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            string password = tbPass.Password == tbPassCheck.Password ? tbPass.Password.Trim() : "";
            if (password.Length < 8 || String.IsNullOrEmpty(password) ||
                new Regex("[^a-zA-Z0-9]").IsMatch(password))
            {
                tbPass.ToolTip = "Неверный ввод даных";
                tbPass.Background = Brushes.LightPink;
                tbPassCheck.ToolTip = "Неверный ввод даных";
                tbPassCheck.Background = Brushes.LightPink;
            }
            else
            {
                Password = password;
                OnAceeptChanges(e);
                AcceptBtn.Command = DialogHost.CloseDialogCommand;
            }
        }
    }
}