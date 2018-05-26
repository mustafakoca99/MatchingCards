using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PairCards_38_Dimitar_Mitev
{
    public class Card : INotifyPropertyChanged
    {
        public static BitmapImage back_base = new BitmapImage(new Uri("pack://application:,,,/cards/back.jpg"));
        public static BitmapImage empty_base = new BitmapImage(new Uri("pack://application:,,,/cards/face_empty.png"));
        public static BitmapImage joker = new BitmapImage(new Uri("pack://application:,,,/cards/joker.png"));
        public BitmapImage See { get => see; set { see = value; OnPropertyChanged(new PropertyChangedEventArgs("See")); } }
        public BitmapImage Face { get => face; set { face = value; OnPropertyChanged(new PropertyChangedEventArgs("Face")); } }
        public BitmapImage Back { get => back; set { back = value; OnPropertyChanged(new PropertyChangedEventArgs("Back")); } }
        public bool Done { get => done; set { done = value; OnPropertyChanged(new PropertyChangedEventArgs("Done")); } }
        public bool Flipped { get => flipped; set { flipped = value; OnPropertyChanged(new PropertyChangedEventArgs("Flipped")); } }
        public static BitmapImage[] Cards = new BitmapImage[52];

        private BitmapImage face;
        private BitmapImage back;
        private BitmapImage see;
        bool done;
        bool flipped;
        public event PropertyChangedEventHandler PropertyChanged;
        public Card() { }
        public Card(BitmapImage face)
        {
            this.Face = face;
            this.See = back_base;
            this.Back = back_base;
            this.done = false;
            this.flipped = false;
        }

        public Card(BitmapImage _back, BitmapImage _face)
        {
            this.Face = _face;
            this.Back = _back;
            this.Done = false;
            this.Flipped = false;
        }
        public static void FillCards()
        {
            Cards[0] = new BitmapImage(new Uri("pack://application:,,,/cards/as.png"));
            Cards[1] = new BitmapImage(new Uri("pack://application:,,,/cards/2s.png"));
            Cards[2] = new BitmapImage(new Uri("pack://application:,,,/cards/3s.png"));
            Cards[3] = new BitmapImage(new Uri("pack://application:,,,/cards/4s.png"));
            Cards[4] = new BitmapImage(new Uri("pack://application:,,,/cards/5s.png"));
            Cards[5] = new BitmapImage(new Uri("pack://application:,,,/cards/6s.png"));
            Cards[6] = new BitmapImage(new Uri("pack://application:,,,/cards/7s.png"));
            Cards[7] = new BitmapImage(new Uri("pack://application:,,,/cards/8s.png"));
            Cards[8] = new BitmapImage(new Uri("pack://application:,,,/cards/9s.png"));
            Cards[9] = new BitmapImage(new Uri("pack://application:,,,/cards/10s.png"));
            Cards[10] = new BitmapImage(new Uri("pack://application:,,,/cards/js.png"));
            Cards[11] = new BitmapImage(new Uri("pack://application:,,,/cards/qs.png"));
            Cards[12] = new BitmapImage(new Uri("pack://application:,,,/cards/ks.png"));

            Cards[13] = new BitmapImage(new Uri("pack://application:,,,/cards/ad.png"));
            Cards[14] = new BitmapImage(new Uri("pack://application:,,,/cards/2d.png"));
            Cards[15] = new BitmapImage(new Uri("pack://application:,,,/cards/3d.png"));
            Cards[16] = new BitmapImage(new Uri("pack://application:,,,/cards/4d.png"));
            Cards[17] = new BitmapImage(new Uri("pack://application:,,,/cards/5d.png"));
            Cards[18] = new BitmapImage(new Uri("pack://application:,,,/cards/6d.png"));
            Cards[19] = new BitmapImage(new Uri("pack://application:,,,/cards/7d.png"));
            Cards[20] = new BitmapImage(new Uri("pack://application:,,,/cards/8d.png"));
            Cards[21] = new BitmapImage(new Uri("pack://application:,,,/cards/9d.png"));
            Cards[22] = new BitmapImage(new Uri("pack://application:,,,/cards/10d.png"));
            Cards[23] = new BitmapImage(new Uri("pack://application:,,,/cards/jd.png"));
            Cards[24] = new BitmapImage(new Uri("pack://application:,,,/cards/qd.png"));
            Cards[25] = new BitmapImage(new Uri("pack://application:,,,/cards/kd.png"));

            Cards[26] = new BitmapImage(new Uri("pack://application:,,,/cards/ac.png"));
            Cards[27] = new BitmapImage(new Uri("pack://application:,,,/cards/2c.png"));
            Cards[28] = new BitmapImage(new Uri("pack://application:,,,/cards/3c.png"));
            Cards[29] = new BitmapImage(new Uri("pack://application:,,,/cards/4c.png"));
            Cards[30] = new BitmapImage(new Uri("pack://application:,,,/cards/5c.png"));
            Cards[31] = new BitmapImage(new Uri("pack://application:,,,/cards/6c.png"));
            Cards[32] = new BitmapImage(new Uri("pack://application:,,,/cards/7c.png"));
            Cards[33] = new BitmapImage(new Uri("pack://application:,,,/cards/8c.png"));
            Cards[34] = new BitmapImage(new Uri("pack://application:,,,/cards/9c.png"));
            Cards[35] = new BitmapImage(new Uri("pack://application:,,,/cards/10c.png"));
            Cards[36] = new BitmapImage(new Uri("pack://application:,,,/cards/jc.png"));
            Cards[37] = new BitmapImage(new Uri("pack://application:,,,/cards/qc.png"));
            Cards[38] = new BitmapImage(new Uri("pack://application:,,,/cards/kc.png"));


            Cards[39] = new BitmapImage(new Uri("pack://application:,,,/cards/ah.png"));
            Cards[40] = new BitmapImage(new Uri("pack://application:,,,/cards/2h.png"));
            Cards[41] = new BitmapImage(new Uri("pack://application:,,,/cards/3h.png"));
            Cards[42] = new BitmapImage(new Uri("pack://application:,,,/cards/4h.png"));
            Cards[43] = new BitmapImage(new Uri("pack://application:,,,/cards/5h.png"));
            Cards[44] = new BitmapImage(new Uri("pack://application:,,,/cards/6h.png"));
            Cards[45] = new BitmapImage(new Uri("pack://application:,,,/cards/7h.png"));
            Cards[46] = new BitmapImage(new Uri("pack://application:,,,/cards/8h.png"));
            Cards[47] = new BitmapImage(new Uri("pack://application:,,,/cards/9h.png"));
            Cards[48] = new BitmapImage(new Uri("pack://application:,,,/cards/10h.png"));
            Cards[49] = new BitmapImage(new Uri("pack://application:,,,/cards/jh.png"));
            Cards[50] = new BitmapImage(new Uri("pack://application:,,,/cards/qh.png"));
            Cards[51] = new BitmapImage(new Uri("pack://application:,,,/cards/kh.png"));
        }
        public void Flip()
        {
            if(Face==See)
            {
                See = Back;
            }
            else
            {
                See = Face;
            }
            Flipped = !flipped;
           
        }
        public void Show()
        {
            See = Face;
            Flipped = true;
         
        }
        public void Hide()
        {
            See = Back;
          
            Flipped = false;
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
