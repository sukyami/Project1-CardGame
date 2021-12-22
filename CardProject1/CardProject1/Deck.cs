using System;
using System.Collections.Generic;
using System.Text;

namespace CardProject1
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }
        }

        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            }
            else
            {
                return null;
            }


        }

        public void Shuffle()
        {
            
            //swap the random number with i 
            for (int i = cards.Count - 1; i > 0; i--)
            {
                Random rand = new Random();
                //create random number 
                int num = rand.Next(cards.Count);
                //check the overlap number 
                for (int j = 0; j < cards.Count - i; j++)
                {
                    if (cards[cards.Count - j - 1] == cards[num])
                    {
                        num = rand.Next(cards.Count);
                        break;
                    }
                }

                //create  value temp for current temporary element 
                Card temp = cards[i];

                //save a random number generated at the last digit of the current array.
                cards[i] = cards[num];

                //Temporarily created values ​​are stored in place of random numbers.
                cards[num] = temp;
            }
        }

        public int Cut()
        {
            int count = cards.Count;

            return count;
        }

        public void reset()
        {
            cards.Clear();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }
        }





    }
}
