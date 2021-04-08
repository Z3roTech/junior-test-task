using JuniorSlataTestTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for ChangePermissionControl.xaml
    /// </summary>
    public partial class ChangePermissionControl : UserControl
    {
        public event EventHandler AcceptChanges;

        private Permissions permission;
        public Permissions Permission { get => permission; set => permission = value; }

        protected virtual void OnAceeptChanges(EventArgs e)
        {
            EventHandler handler = AcceptChanges;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public ChangePermissionControl()
        {
            InitializeComponent();
            PermissionList.ItemsSource = Enum.GetNames(typeof(Permissions)).ToList();
            PermissionList.SelectedIndex = 0;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            if (PermissionList.SelectedIndex == -1) return;
            Permission = (Permissions)PermissionList.SelectedIndex;
            OnAceeptChanges(e);
        }
    }
}