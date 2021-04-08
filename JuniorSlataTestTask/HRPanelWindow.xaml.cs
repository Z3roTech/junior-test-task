using JuniorSlataTestTask.Controls;
using JuniorSlataTestTask.Data.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for HRPanelWindow.xaml
    /// </summary>
    public partial class HRPanelWindow : Window
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

        public HRPanelWindow()
        {
            InitializeComponent();
            db = new AppContext();
            UpdateDataGrid();
        }

        private void SignOutBtnClick(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Show();
            this.Close();
        }

        private void AddJobseakerBtnClick(object sender, RoutedEventArgs e)
        {
            AddJobseakerControl control = new AddJobseakerControl();
            control.AcceptChanges += (sender, e) =>
            {
                db.Jobseakers.Add(new Jobseaker()
                {
                    FullName = control.FullName,
                    PhoneNumber = control.FormattedPhoneNumber,
                    Position = control.Position,
                    TimeToTask = control.TimeToTask,
                    ManagerId = Convert.ToInt32(App.Current.Properties["AuthUserID"]),
                    Task = new Task()
                    {
                        DateTimeStart = control.DateTimeStart
                    }
                });
                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
        }

        private void ChangeDataBtnClick(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedIndex == -1) return;
            if (UserDataGrid.Items.Count <= 1) return;
            ChangeJobseakerDataControl control = new ChangeJobseakerDataControl((Jobseaker)UserDataGrid.SelectedItem);
            control.AcceptChanges += (sender, e) =>
            {
                db.Jobseakers.Where(j => j.id == control.Jobseaker.id).FirstOrDefault().FullName = control.Jobseaker.FullName;
                db.Jobseakers.Where(j => j.id == control.Jobseaker.id).FirstOrDefault().Position = control.Jobseaker.Position;
                db.Jobseakers.Where(j => j.id == control.Jobseaker.id).FirstOrDefault().PhoneNumber = control.Jobseaker.PhoneNumber;
                db.Jobseakers.Where(j => j.id == control.Jobseaker.id).FirstOrDefault().TimeToTask = control.Jobseaker.TimeToTask;
                db.Jobseakers.Where(j => j.id == control.Jobseaker.TaskId).FirstOrDefault().Task.DateTimeStart = control.Jobseaker.Task.DateTimeStart;

                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
        }

        private void RemoveDataBtnClick(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedIndex == -1) return;
            if (UserDataGrid.Items.Count <= 1) return;
            DropJobseakerDataControl control = new DropJobseakerDataControl((Jobseaker)UserDataGrid.SelectedCells[0].Item);
            control.AcceptChanges += (sender, e) =>
            {
                db.Tasks.Remove(((Jobseaker)UserDataGrid.SelectedItem).Task);
                db.Jobseakers.Remove((Jobseaker)UserDataGrid.SelectedItem);
                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
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
    }
}