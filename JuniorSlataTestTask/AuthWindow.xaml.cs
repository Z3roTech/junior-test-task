using JuniorSlataTestTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string login = tbLogin.Text.Trim();
            string password = tbPass.Password.Trim();

            if (login.Length < 5 || String.IsNullOrEmpty(login) ||
               new Regex("[^a-zA-Z0-9]").IsMatch(login) || new Regex("[^a-zA-Z]").IsMatch(login.First().ToString()))
            {
                tbLogin.ToolTip = "Неверный ввод даных!";
                tbLogin.Background = Brushes.LightPink;
            }
            else if (password.Length < 8 || String.IsNullOrEmpty(password) ||
                new Regex("[^a-zA-Z0-9]").IsMatch(password))
            {
                tbPass.ToolTip = "Неверный ввод даных";
                tbPass.Background = Brushes.LightPink;
            }
            else
            {
                tbLogin.ToolTip = "";
                tbLogin.Background = Brushes.Transparent;
                tbPass.ToolTip = "";
                tbPass.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    App.Current.Properties["AuthUserID"] = authUser.id;

                    switch (authUser.Permission)
                    {
                        case Permissions.User:
                            this.Show();
                            MessageBox.Show("Обратитесь к системному администратору для получения соответствующих прав");
                            return;

                        case Permissions.Administrator:
                            this.Hide();
                            AdminPanelWindow adminPanel = new AdminPanelWindow();
                            adminPanel.SignOut += ChildWindow_Closed;
                            adminPanel.Show();
                            break;

                        case Permissions.HRManager:
                            this.Hide();
                            HRPanelWindow hrPanel = new HRPanelWindow();
                            hrPanel.SignOut += ChildWindow_Closed;
                            adminPanel.Show();
                            break;

                        case Permissions.Mentor:
                            this.Hide();
                            MentorPanelWindow mentorPanel = new MentorPanelWindow();
                            mentorPanel.SignOut += ChildWindow_Closed;
                            mentorPanel.Show();
                            break;

                        default:
                            break;
                    }
                }
            }
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

        private void KeyboardFocusEvent(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).Background = Brushes.Transparent;
            }
            if (sender is PasswordBox)
            {
                ((PasswordBox)sender).Background = Brushes.Transparent;
            }
        }
    }
}