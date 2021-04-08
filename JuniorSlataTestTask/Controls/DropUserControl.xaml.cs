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
using System.Linq;

namespace JuniorSlataTestTask.Controls
{
    /// <summary>
    /// Interaction logic for DropUserControl.xaml
    /// </summary>
    public partial class DropUserControl : UserControl
    {
        public event EventHandler AcceptChanges;

        private User user;
        public User User { get => user; set => user = value; }

        protected virtual void OnAceeptChanges(EventArgs e)
        {
            EventHandler handler = AcceptChanges;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public DropUserControl(User user)
        {
            InitializeComponent();
            User = user;
            List<User> users = new List<User>();
            users.Add(User);
            UserToDrop.ItemsSource = users;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            OnAceeptChanges(e);
        }
    }
}