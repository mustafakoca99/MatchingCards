using System;
using System.Collections.Generic;
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

namespace PairCards_38_Dimitar_Mitev
{
    /// <summary>
    /// Interaction logic for _5by6.xaml
    /// </summary>
    public partial class _5by6 : Page
    {
        public event EventHandler SomethingHappened;
        public event EventHandler Started;
        public event EventHandler Stoped;
        public bool gamestarted = false;

        public Game Current { get => current; set => current = value; }
        private Game current;
        public _5by6()
        {
            Current = new Game("5x6");
            Current.PrepareGame();
            this.DataContext = this;
            InitializeComponent();

        }

        private void card_click(object sender, MouseButtonEventArgs e)
        {
            //MakeSomethingHappen(e);
            //(this.Parent as MainWindow).color_me( sender, e);
            Current.Flip(Current.getPos((sender as Image).Name.ToString()));
            if (!gamestarted)
            {
                StartTimer(e);
                gamestarted = true;
            }
            if (gamestarted && Current.CheckFinished())
                StopTimer(e);

        }
        private void MakeSomethingHappen(EventArgs e)
        {
            if (SomethingHappened != null)
            {
                SomethingHappened(this, e);
            }
        }
        public void StartTimer(EventArgs e)
        {
            Started?.Invoke(this, e);
        }
        public void StopTimer(EventArgs e)
        {
            Stoped?.Invoke(this, e);
        }
    }
}
