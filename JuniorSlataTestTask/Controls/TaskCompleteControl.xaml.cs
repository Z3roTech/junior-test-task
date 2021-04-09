using JuniorSlataTestTask.Data.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuniorSlataTestTask.Controls
{
    /// <summary>
    /// Interaction logic for TaskCompleteControl.xaml
    /// </summary>
    public partial class TaskCompleteControl : UserControl
    {
        public event EventHandler AcceptChanges;

        public DateTime TaskEndTime { get; set; }

        protected virtual void OnAceeptChanges(EventArgs e)
        {
            EventHandler handler = AcceptChanges;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public TaskCompleteControl(Jobseaker jobseaker)
        {
            InitializeComponent();
            List<Jobseaker> jobseakers = new List<Jobseaker>();
            jobseakers.Add(jobseaker);
            UserData.ItemsSource = jobseakers;
            TaskEndTimeInput.SelectedDate = DateTime.Today;
            TaskEndTimeInput.DisplayDateEnd = DateTime.Today;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            TaskEndTime = TaskEndTimeInput.SelectedDate.Value;
            OnAceeptChanges(e);
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