using JuniorSlataTestTask.Data.Models;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuniorSlataTestTask.Controls
{
    /// <summary>
    /// Interaction logic for ChangeJobseakerDataControl.xaml
    /// </summary>
    public partial class ChangeJobseakerDataControl : UserControl
    {
        public event EventHandler AcceptChanges;

        private Jobseaker jobseaker;
        public Jobseaker Jobseaker { get => jobseaker; set => jobseaker = value; }

        private string phoneNumber;

        public string FormattedPhoneNumber
        {
            get
            {
                if (String.IsNullOrEmpty(phoneNumber))
                    return string.Empty;
                switch (phoneNumber.Length)
                {
                    case 7:
                        return Regex.Replace(phoneNumber, @"(\d{3})(\d{4})", "$1-$2");

                    case 10:
                        return Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");

                    case 11:
                        return Regex.Replace(phoneNumber, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");

                    default:
                        return phoneNumber;
                }
            }
        }

        protected virtual void OnAceeptChanges(EventArgs e)
        {
            EventHandler handler = AcceptChanges;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public ChangeJobseakerDataControl(Jobseaker jobseaker)
        {
            InitializeComponent();
            Jobseaker = jobseaker;
            DateTimeStartInput.SelectedDate = jobseaker.Task.DateTimeStart;
            DateTimeStartInput.DisplayDateEnd = DateTime.Today;
            string fullName = Jobseaker.FullName;
            SurnameInput.Text = fullName.Split(" ")[0];
            FirstNameInput.Text = fullName.Split(" ")[1];
            LastNameInput.Text = fullName.Split(" ")[1];
            PositionInput.Text = Jobseaker.Position;
            TimeToTaskInput.Text = Jobseaker.TimeToTask;
            PhoneNumberInput.Text = Jobseaker.PhoneNumber;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            string fName = FirstNameInput.Text.Trim();
            string sName = SurnameInput.Text.Trim();
            string lName = LastNameInput.Text.Trim();
            string position = PositionInput.Text.Trim();
            string time = TimeToTaskInput.Text.Trim();
            phoneNumber = PhoneNumberInput.Text.Trim();

            if (String.IsNullOrEmpty(sName) || new Regex("[^a-zA-Zа-яА-Я]").IsMatch(sName))
            {
                SurnameInput.Background = Brushes.LightPink;
                return;
            }
            if (String.IsNullOrEmpty(fName) || new Regex("[^a-zA-Zа-яА-Я]").IsMatch(fName))
            {
                FirstNameInput.Background = Brushes.LightPink;
                return;
            }
            if (String.IsNullOrEmpty(lName) || new Regex("[^a-zA-Zа-яА-Я]").IsMatch(lName))
            {
                LastNameInput.Background = Brushes.LightPink;
                return;
            }
            if (String.IsNullOrEmpty(position))
            {
                PositionInput.Background = Brushes.LightPink;
                return;
            }
            if (String.IsNullOrEmpty(time) || new Regex("[^0-9]").IsMatch(time))
            {
                TimeToTaskInput.Background = Brushes.LightPink;
                return;
            }
            if (String.IsNullOrEmpty(phoneNumber) || new Regex("[^0-9]").IsMatch(phoneNumber))
            {
                PhoneNumberInput.Background = Brushes.LightPink;
                return;
            }
            Jobseaker.FullName = new StringBuilder().Append(sName).Append(" ").Append(fName).Append(" ").Append(lName).ToString();
            Jobseaker.Position = position;
            Jobseaker.TimeToTask = time;
            Jobseaker.Task.DateTimeStart = DateTimeStartInput.SelectedDate.Value;
            Jobseaker.PhoneNumber = FormattedPhoneNumber;
            OnAceeptChanges(e);
            AcceptBtn.Command = DialogHost.CloseDialogCommand;
        }

        private void KeyboardFocusEvent(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).Background = Brushes.Transparent;
            }
        }
    }
}