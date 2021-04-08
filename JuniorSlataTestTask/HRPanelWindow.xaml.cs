using System;
using System.Windows;

namespace JuniorSlataTestTask
{
    /// <summary>
    /// Interaction logic for HRPanelWindow.xaml
    /// </summary>
    public partial class HRPanelWindow : Window
    {
        public event EventHandler SignOut;

        protected virtual void OnSignOut(EventArgs e)
        {
            EventHandler handler = SignOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public HRPanelWindow()
        {
            InitializeComponent();
        }
    }
}