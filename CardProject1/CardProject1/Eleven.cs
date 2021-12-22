using System;
using System.Collections.Generic;
using System.Text;

namespace CardProject1
{
    class Eleven
    {
        List<Card> ElevenCard = new List<Card>();


        public bool CheckPossibility(List<Card> list)
        {
            bool check = false;
            int sum = 0;
            int rankValue;
            bool checkJ = false;
            bool checkQ = false;
            bool checkK = false;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    sum = ((int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1) + ((int)System.Enum.Parse(typeof(Rank), list[j].Rank) + 1);
                    if (sum == 11)
                    {
                        check = true;
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                rankValue = (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                if (rankValue == 11)
                {
                    checkJ = true;
                }
                else if (rankValue == 12)
                {
                    checkQ = true;
                }
                else if (rankValue == 13)
                {
                    checkK = true;
                }

                if (checkJ && checkQ && checkK)
                {
                    check = true;
                }
            }
            return check;
        }

        public bool checkCard(List<Card> list)
        {
            int sum = 0;
            bool check = false;
            int rankValue;
            bool checkJ = false;
            bool checkQ = false;
            bool checkK = false;

            if (list.Count == 2)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sum += (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                }
                if (sum == 11)
                {
                    check = true;
                }
            }
            else if (list.Count == 3)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    rankValue = (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                    if (rankValue == 11)
                    {
                        checkJ = true;
                    }
                    else if (rankValue == 12)
                    {
                        checkQ = true;
                    }
                    else if (rankValue == 13)
                    {
                        checkK = true;
                    }

                    if (checkJ && checkQ && checkK)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
    }
}




