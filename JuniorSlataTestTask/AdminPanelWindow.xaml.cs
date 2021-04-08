using JuniorSlataTestTask.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
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
            List<User> users = db.Users.ToList();
            UserDataGrid.ItemsSource = users;
        }

        public AdminPanelWindow()
        {
            InitializeComponent();
            db = new AppContext();
            UpdateDataGrid();
            UserDataGrid.SelectedIndex = 0;
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

        private void ChangePermissionBtnClick(object sender, RoutedEventArgs e)
        {
            ChangePermissionControl control = new ChangePermissionControl();
            control.AcceptChanges += (sender, e) =>
            {
                db.Users.Where(u => u.id == ((User)UserDataGrid.SelectedCells[0].Item).id).FirstOrDefault().Permission = control.Permission;
                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
            //MessageBox.Show(((User)UserDataGrid.SelectedCells[0].Item).id.ToString());
            //MessageBox.Show(((ChangePermissionControl)sender).Permission.ToString());
        }

        private void ChangePasswordBtnClick(object sender, RoutedEventArgs e)
        {
            ChangePasswordControl control = new ChangePasswordControl();
            control.AcceptChanges += (sender, e) =>
            {
                db.Users.Where(u => u.id == ((User)UserDataGrid.SelectedCells[0].Item).id).FirstOrDefault().Password = control.Password;
                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
        }

        private void DropUserBtnClick(object sender, RoutedEventArgs e)
        {
            DropUserControl control = new DropUserControl((User)UserDataGrid.SelectedCells[0].Item);
            control.AcceptChanges += (sender, e) =>
            {
                db.Users.Remove(((User)UserDataGrid.SelectedCells[0].Item));
                db.SaveChanges();
                UpdateDataGrid();
            };
            DialogHost.Show(control);
        }

        private void SignOutBtnClick(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Show();
            this.Close();
        }
    }
}