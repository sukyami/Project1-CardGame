using System;
using System.Collections.Generic;
using System.Text;

namespace CardProject1
{
    class Thirteen
    {
        List<Card> ThirteenCard = new List<Card>();

        public bool CheckPossibility(List<Card> list)
        {
            int rankValue = 0;
            int sum = 0;
            bool check = false;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i+1; j < list.Count; j++)
                {
                    sum = ((int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1)+((int)System.Enum.Parse(typeof(Rank), list[j].Rank) + 1);
                    if (sum == 13)
                    {
                        check = true;
                    }
                }
            }
            for ( int i = 0; i < list.Count; i++)
            {
                rankValue = (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                if(rankValue == 13)
                {
                    check = true;
                }
            }
            return check; 
        }

        public bool checkCard(List<Card> list)
        {
            bool check = false;
            int sum = 0;
            int rankValue = 0;


            if (list.Count == 2)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sum += (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                }
                if (sum == 13)
                {
                    check = true;
                }
            } else if (list.Count == 1){
                rankValue = (int)System.Enum.Parse(typeof(Rank), list[0].Rank) + 1;
                if( rankValue == 13)
                {
                    check = true; 
                }
            }
            return check;
        }
    }
}

