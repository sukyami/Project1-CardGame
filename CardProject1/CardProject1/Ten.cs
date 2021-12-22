using System;
using System.Collections.Generic;
using System.Text;

namespace CardProject1
{
    class Ten
    {
        List<Card> TenCard = new List<Card>();

        public bool CheckPossibility(List<Card> list)
        {
            int rankValue = 0; 
            int countT = 0;
            int countJ = 0;
            int countQ = 0;
            int countK = 0;
            int sum = 0;
            bool check = false;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    sum = ((int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1) + ((int)System.Enum.Parse(typeof(Rank), list[j].Rank) + 1);
                    if (sum == 10)
                    {
                        check = true;
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                rankValue = (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                if(rankValue == 10)
                {
                    countT++;
                }else if (rankValue == 11)
                {
                    countJ++;
                }
                else if (rankValue == 12)
                {
                    countQ++;
                }
                else if (rankValue == 13)
                {
                    countK++;
                }
                if (countT == 4 || countJ == 4 || countQ == 4 || countK == 4)
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
            int rankValue1 = 0;
            int rankValue2 = 0;

            if (list.Count == 2)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sum += (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                }
                if (sum == 10)
                {
                    check = true;
                }
            }
            else if (list.Count == 4)
            {
                for (int i = 0; i< list.Count; i++)
                {
                    for ( int j = i+1; j<list.Count; j++)
                    {
                        rankValue1 = (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                        rankValue2 = (int)System.Enum.Parse(typeof(Rank), list[j].Rank) + 1;
                        if (rankValue1 == rankValue2)
                        {
                            check = true; 
                        }else
                        {
                            check = false;
                        }
                                
                    }
                }
               
            }
            return check;
        }
    }
}
