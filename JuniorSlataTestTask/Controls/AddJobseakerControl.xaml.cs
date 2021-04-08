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
    /// Interaction logic for AddJobseakerControl.xaml
    /// </summary>
    public partial class AddJobseakerControl : UserControl
    {
        public event EventHandler AcceptChanges;

        private string phoneNumber { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string TimeToTask { get; set; }
        public DateTime DateTimeStart { get; set; }

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

        public AddJobseakerControl()
        {
            InitializeComponent();
            DateTimeStartInput.SelectedDate = DateTime.Now;
            DateTimeStartInput.DisplayDateEnd = DateTime.Now;
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
            FullName = new StringBuilder().Append(sName).Append(" ").Append(fName).Append(" ").Append(lName).ToString();
            Position = position;
            TimeToTask = time;
            DateTimeStart = DateTimeStartInput.SelectedDate.Value;
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