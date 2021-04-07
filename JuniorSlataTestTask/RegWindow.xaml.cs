﻿using System;
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
    /// Interaction logic for RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public event EventHandler WindowClosed;

        private AppContext dbcontext;

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
            dbcontext = new AppContext();
        }

        private void Register_ButtonClick(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPass.Password == tbPassCheck.Password ? tbPass.Password.Trim() : "";
            string name = tbName.Text.Trim();
            string surname = tbSurname.Text.Trim();

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
                tbPassCheck.ToolTip = "Неверный ввод даных";
                tbPassCheck.Background = Brushes.LightPink;
            }
            else if (String.IsNullOrEmpty(name) ||
                new Regex("[^a-zA-Zа-яА-Я]").IsMatch(name))
            {
                tbName.ToolTip = "Неверный ввод даных";
                tbName.Background = Brushes.LightPink;
            }
            else if (String.IsNullOrEmpty(surname) ||
                new Regex("[^a-zA-Zа-яА-Я]").IsMatch(surname))
            {
                tbSurname.ToolTip = "Неверный ввод даных";
                tbSurname.Background = Brushes.LightPink;
            }
            else
            {
                foreach (UIElement el in continerReg.Children)
                {
                    if (el is TextBox)
                    {
                        ((TextBox)el).ToolTip = "";
                        ((TextBox)el).Background = Brushes.Transparent;
                    }
                    if (el is PasswordBox)
                    {
                        ((PasswordBox)el).ToolTip = "";
                        ((PasswordBox)el).Background = Brushes.Transparent;
                    }
                }
                dbcontext.Users.Add(new User(login, password, name, surname));
                dbcontext.SaveChanges();

                Application.Current.MainWindow.Show();
                this.Close();
            }
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
            else OnWindowClosed(EventArgs.Empty);
        }

        private void tbPassCheck_LostFocus(object sender, RoutedEventArgs e)
        {
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