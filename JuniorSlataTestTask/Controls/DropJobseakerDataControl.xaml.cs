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
    /// Interaction logic for DropJobseakerDataControl.xaml
    /// </summary>
    public partial class DropJobseakerDataControl : UserControl
    {
        public event EventHandler AcceptChanges;

        private Jobseaker jobseaker;
        public Jobseaker Jobseaker { get => jobseaker; set => jobseaker = value; }

        protected virtual void OnAceeptChanges(EventArgs e)
        {
            EventHandler handler = AcceptChanges;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public DropJobseakerDataControl(Jobseaker jobseaker)
        {
            InitializeComponent();
            List<Jobseaker> jobseakers = new List<Jobseaker>();
            jobseakers.Add(jobseaker);
            UserToDrop.ItemsSource = jobseakers;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            OnAceeptChanges(e);
        }
    }
}