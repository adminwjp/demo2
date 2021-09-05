using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utility.Menus;
using Utility.Wpf;

namespace Shop.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected System.Timers.Timer Timer;
        List<MenuEntry> menus = new List<MenuEntry>();
        public MainWindow()
        {
            InitializeComponent();
            MenuHelper.LoadXml("Config//Menu.Xml", menus);
            WpfComponent.T_TabControl = tab;
            WpfComponent.Initial(menu,tree,menus);
            this.Timer = new System.Timers.Timer();
            this.Timer.AutoReset = true;
            this.Timer.Interval = 1000;
            this.Timer.Elapsed -= _timer_Elapsed;
            this.Timer.Elapsed += _timer_Elapsed;
            this.Timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() => {
                var msg = $"当前时间为:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                time.Content = msg;
            }));
        }
    }
}
