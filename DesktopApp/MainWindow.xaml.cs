using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        NotifyIcon nIcon = new NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();
            nIcon.Click += iconDoubleClick;
        }

        void iconDoubleClick(object sender, EventArgs e)
        {
            if (IsVisible)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                nIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
                this.nIcon.Visible = false;
            }
            
            
        }

        private void toTray(object sender, MouseButtonEventArgs e)
        {
            
            this.WindowState = System.Windows.WindowState.Minimized;
            this.nIcon.Icon = new Icon(@"../Debug/Icon1.ico");
           //con.Icon = ((System.Drawing.Icon)(Properties.Resources.ResourceManager.GetObject("$this.Icon")));
            this.nIcon.Visible = true;
            this.ShowInTaskbar = false;
            //is.nIcon.ShowBalloonTip(5000, "Hi", "This is a BallonTip from Windows Notification", ToolTipIcon.Info);

        }
    }
}
