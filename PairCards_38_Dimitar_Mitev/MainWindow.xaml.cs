using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PairCards_38_Dimitar_Mitev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page CurrentGame;
        public Stopwatch time = new Stopwatch();
        TimeSpan record = new TimeSpan();
        DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            rbtn5x5.IsChecked = true;
        }
        void dt_Tick(object sender, EventArgs e)
        {
            if (time.IsRunning)
            {
                TimeSpan ts = time.Elapsed;
                txtCurrentTime.Content = String.Format("{0:00}:{1:00}:{2:00}",ts.Hours, ts.Minutes, ts.Seconds);
            }
        }
        void pageHome_SomethingHappened(object sender, EventArgs e)
        {
            this.Background = Brushes.Black;
        }
        public void color_me(object sender, EventArgs e)
        {
            this.Background = Brushes.Black;
        }
        void StartTimer(object sender, EventArgs e)
        {
            time.Reset();
            time.Start();
        }
        void StopTimer(object sender, EventArgs e)
        {
            time.Stop();
            if (record > time.Elapsed || record.TotalSeconds==0)
            {
                TimeSpan ts = time.Elapsed;
                record = ts;
                txtCurrentRecord.Content = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            }
            
            //mustafa koca adding -1
            MessageBox.Show("completed successfully!") //bittiğinde çıkar
             
            //mustafa koca adding -2
            SoundPlayer player = new SoundPlayer("beep.wav");
            player.Load();
            player.Play();
             //------------------------------------------------------------------------------------------------------
        }
        private void SetupGame5x5()
        {
            CurrentGame = new _5by5();
            myFrame.NavigationService.RemoveBackEntry();
            myFrame.Content = CurrentGame;
            (CurrentGame as _5by5).SomethingHappened += new EventHandler(pageHome_SomethingHappened);
            (CurrentGame as _5by5).Started += new EventHandler(StartTimer);
            (CurrentGame as _5by5).Stoped += new EventHandler(StopTimer);
        }
        private void SetupGame5x6()
        {
            CurrentGame = new _5by6();
            myFrame.NavigationService.RemoveBackEntry();
            myFrame.Content = CurrentGame;
            (CurrentGame as _5by6).SomethingHappened += new EventHandler(pageHome_SomethingHappened);
            (CurrentGame as _5by6).Started += new EventHandler(StartTimer);
            (CurrentGame as _5by6).Stoped += new EventHandler(StopTimer);
        }
        private void SetupGame6x6()
        {
            CurrentGame = new _6by6();
            myFrame.NavigationService.RemoveBackEntry();
            myFrame.Content = CurrentGame;
            (CurrentGame as _6by6).SomethingHappened += new EventHandler(pageHome_SomethingHappened);
            (CurrentGame as _6by6).Started += new EventHandler(StartTimer);
            (CurrentGame as _6by6).Stoped += new EventHandler(StopTimer);
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if(rbtn5x5.IsChecked.Value)
                SetupGame5x5();
            if (rbtn5x6.IsChecked.Value)
                SetupGame5x6();
            if (rbtn6x6.IsChecked.Value)
                SetupGame6x6();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt.Start();
            time.Reset();
        }
    }
}
