using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PairCards_38_Dimitar_Mitev
{
    public class Game
    {
        private Card[] cards;
        public String size;
        public Card[] Cards { get => cards; set => cards = value; }
        private int uncovered = 0;
        private int[] uncoveredCards=new int[2];
        int cardsCount;
        private int done = 0;
        public List<BitmapImage> FreeCards = new List<BitmapImage>();
        Random rnd = new Random();

        public Game(String size)
        {
            this.size = size;
            cardsCount = (size[0] - '0') * (size[2] - '0');
            Card.FillCards();
            for(int i=0;i<52;i++)
            {
                FreeCards.Add(Card.Cards[i]);
            }
        }
        public int PrepareGame()
        {
            cards = new Card[cardsCount];
            if (cardsCount % 2 == 1)
                setACard(Card.joker, cardsCount);
            for (int i = 0; i < cardsCount/2; i++)
            {
                BitmapImage face = GetAFace();
                setACard(face, cardsCount);
                setACard(face, cardsCount);
            }
            return cardsCount;
        }
        public int getPos(string name)
        {
            int pos;
            pos = int.Parse(name[3].ToString());
            pos *= int.Parse(size[0].ToString());
            pos += int.Parse(name[5].ToString());
            return pos;
        }
        public void Flip(int pos)
        {
            if(this.Cards[pos].Face==Card.joker)
            {
                if (!this.Cards[pos].Flipped)
                {
                    this.Cards[pos].Flip();
                    done++;
                    CheckFinished();
                }
                return;
            }
            if (uncovered < 2)
            {
                if (Cards[pos].Done == true) return;
                this.Cards[pos].Flip();
                if (Cards[pos].Flipped == true)
                {
                    uncoveredCards[uncovered] = pos;
                    ++uncovered;
                }
                else
                {
                    if(uncovered>0)--uncovered;
                }
                if (uncovered == 2)
                {
                    if (this.Cards[uncoveredCards[0]].Face == this.Cards[uncoveredCards[1]].Face)
                    {
                        this.Cards[uncoveredCards[0]].Done = true;
                        this.Cards[uncoveredCards[1]].Done = true;
                        done += 2;
                        CheckFinished();
                        uncovered = 0;
                    }
                }
            }
           else if (uncovered==2)
            {
                this.Cards[uncoveredCards[0]].Hide();
                this.Cards[uncoveredCards[1]].Hide();
                uncovered = 0;
                if(Cards[pos].Done!=true)
                {
                    this.Cards[pos].Flip();
                    uncovered++;
                    uncoveredCards[0] = pos;
                }
            }
        }
        public bool CheckFinished()
        {
            return done >= cardsCount;
        }
        public BitmapImage GetAFace()
        {
            int pos = rnd.Next(0, FreeCards.Count);
            BitmapImage n= FreeCards[pos];
            FreeCards.RemoveAt(pos);
            return n;
        }
        public void setACard(BitmapImage d,int cards)
        {
            int position=0;
            do
            {
                position = rnd.Next(0,cards);
            } while (this.cards[position] != null);
            this.cards[position] = new Card(d);
        }
    }
}
