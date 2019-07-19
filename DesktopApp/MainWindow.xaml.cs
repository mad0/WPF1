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
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace DesktopApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        public string dane
        {
            get;set;
        }
        NotifyIcon nIcon = new NotifyIcon();
        public MainWindow()
        {
            mojIP();
            InitializeComponent();
            nIcon.Click += iconDoubleClick;
            Console.WriteLine(dane);
         
            this.DataContext = dane;
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

        
            private void mojIP()
            {
                string host = Dns.GetHostName();
                //IPAddress[] rr = Dns.GetHostAddresses("");
                string adresIP = Dns.GetHostEntry(host).AddressList[1].ToString();
                double receiv = NetworkInterface.GetAllNetworkInterfaces()[1].GetIPv4Statistics().BytesReceived;
                double sent = NetworkInterface.GetAllNetworkInterfaces()[1].GetIPv4Statistics().BytesSent;
                //Console.WriteLine((int)reciv/1024000);
                //Console.WriteLine((int)sent/1024000);
                string link = null;
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    link = "Connected";
                }
                else
                {
                    link = "Disconnected";
                }
                dane = "Link:\t\t" +link+"\n"+
                        "Nazwa:\t\t" + host + "\n" +
                        "Adres IP:\t\t" + adresIP + "\n" +
                        "Odebrano:\t" + (int)receiv / 1024000 + " MB\n" +
                        "Wysłano:\t\t" + (int)sent / 1024000 + " MB";
               // BindingExpression bindy = moj.   
        }
    }
}
