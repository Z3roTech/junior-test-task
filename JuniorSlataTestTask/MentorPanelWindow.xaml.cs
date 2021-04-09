using JuniorSlataTestTask.Controls;
using JuniorSlataTestTask.Data.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for MentorPanelWindow.xaml
    /// </summary>
    public partial class MentorPanelWindow : Window
    {
        public event EventHandler SignOut;

        private AppContext db;

        protected virtual void OnSignOut(EventArgs e)
        {
            EventHandler handler = SignOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void UpdateDataGrid()
        {
            List<Jobseaker> jobseakers = db.Jobseakers.ToList();
            UserDataGrid.ItemsSource = jobseakers;
        }

        public MentorPanelWindow()
        {
            InitializeComponent();
            db = new AppContext();
            UpdateDataGrid();
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

        private void TaskCompleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedIndex == -1) return;
            if (UserDataGrid.Items.Count <= 1) return;
            TaskCompleteControl control = new TaskCompleteControl((Jobseaker)UserDataGrid.SelectedItem);
            control.AcceptChanges += (sender, e) =>
            {
                var seakerId = ((Jobseaker)UserDataGrid.SelectedItem).id;
                var seakerTaskId = ((Jobseaker)UserDataGrid.SelectedItem).TaskId;
                db.Tasks.Where(t => t.id == seakerTaskId).FirstOrDefault().DateTimeEnd = control.TaskEndTime;
                db.Tasks.Where(t => t.id == seakerTaskId).FirstOrDefault().Completeness = true;
                db.Jobseakers.Where(j => j.id == seakerId).FirstOrDefault().MentorId = Convert.ToInt32(App.Current.Properties["AuthUserID"]);
                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
        }
    }
}