using System;
using System.Collections.Generic;
using System.Text;

namespace CardProject1
{
    public class Table
    {
        List<Card> tableCard = new List<Card>();
        List<Card> selectCardValue = new List<Card>();
        List<string> selectedIndex = new List<string>();

        Deck deck = new Deck();

        Ten ten = new Ten();
        Eleven eleven = new Eleven();
        Thirteen thirteen = new Thirteen();



        public Table()
        {

        }

        //play game 
        public void playGame()
        {
            string[] selectedCardIndext;
            bool isPos;
            string action;
            int gamechioce;
            deck.reset();
            deck.Shuffle();

            gamechioce = getGame();

            tableCard = getCard(gamechioce);


            do
            {
                PrintCard(tableCard);
                remainCard();


                isPos = checkPos(tableCard, gamechioce);

                if (isPos)
                {

                    Console.WriteLine("There is a possibility pair of card, pleases enter all the cards you want to select using spaces.");

                    selectedCardIndext = Console.ReadLine().Split(' ');

                    foreach (string s in selectedCardIndext)
                    {
                        selectedIndex.Add(s);
                    }

                    selectCardValue = selectedCard(selectedIndex);

                    Console.WriteLine("Please select action\n1.Replace \n2.Restart ");
                    action = Console.ReadLine();

                    if (action == "1" || action == "Replace")
                    {
                        if (checkIsCondition(selectCardValue, gamechioce))
                        {
                            replaceCard(selectedIndex, checkIsCondition(selectCardValue, gamechioce));
                        }
                        else
                        {
                            while (!checkIsCondition(selectCardValue, gamechioce))
                            {
                                selectedIndex.Clear();
                                selectCardValue.Clear();
                                Console.WriteLine("FAIL The selected card does not meet the condition. Please select again");
                                selectedCardIndext = Console.ReadLine().Split(' ');

                                foreach (string s in selectedCardIndext)
                                {
                                    selectedIndex.Add(s);
                                }
                                selectCardValue = selectedCard(selectedIndex);
                            }
                            replaceCard(selectedIndex, checkIsCondition(selectCardValue, gamechioce));
                        }

                    }
                    else if (action == "2" || action == "Restart")
                    {
                        tableCard.Clear();
                        selectedIndex.Clear();
                        selectCardValue.Clear();

                        playGame();
                    }
                }
                else
                {
                    Console.WriteLine("There is no possibility pair of card,you lost");
                    Console.WriteLine("Please select action\n1.Exit \n2.Restart ");
                    action = Console.ReadLine();
                    winDisplay(gamechioce, winCount(gamechioce));
                    if (action == "1" || action == "Exit")
                    {
                        break;
                    }
                    else if (action == "2" || action == "Restart")
                    {
                        tableCard.Clear();
                        selectedIndex.Clear();
                        selectCardValue.Clear();

                        playGame();
                    }


                }
                selectedIndex.Clear();
                selectCardValue.Clear();
            } while (!isWin());
            if (isWin())
            {
                Console.WriteLine("Win!");
                winDisplay(gamechioce, winCount(gamechioce));
            }


        }

        //get user input for select game 
        public int getGame()
        {
            int gameselect;
            Console.WriteLine("Please select number of game type");
            Console.WriteLine("1. Ten");
            Console.WriteLine("2. Eleven");
            Console.WriteLine("3. Thirteen");
            Console.WriteLine("4. Exit");

            gameselect = Convert.ToInt32(Console.ReadLine());
            return gameselect;
        }
        /*
        public string getPlayerName()
        {
            string playerName;
            Console.WriteLine("Please enter player name");
            playerName = Console.ReadLine();

            return playerName;
        }*/

        //get card from the deck depanding on game 
        public List<Card> getCard(int n)
        {

            int index;

            if (n == 1)
            {
                index = 13;
                for (int i = 0; i < index; i++)
                {
                    tableCard.Add(deck.TakeTopCard());
                }
                return tableCard;
            }
            else if (n == 2)
            {
                index = 9;
                for (int i = 0; i < index; i++)
                {
                    tableCard.Add(deck.TakeTopCard());
                }
                return tableCard;
            }
            else if (n == 3)
            {
                index = 10;
                for (int i = 0; i < index; i++)
                {
                    tableCard.Add(deck.TakeTopCard());
                }
                return tableCard;
            } else
            {
                return null;
            }
        }

        public int winCount(int n)
        {
            int count10 = 0;
            int count11 = 0;
            int count13 = 0;

            if (isWin())
            {
                if (n == 1)
                {
                    count10++;
                    return count10;
                }
                else if (n == 2)
                {
                    count11++;
                    return count11;
                }
                else if (n == 3)
                {
                    count13++;
                    return count13;
                }
            }
            return 0;
        }

        public void winDisplay(int n, int count)
        {
            if (n == 1)
            {
                Console.WriteLine("You've won " + count + " out of " + 8 + " games.");
            }
            else if (n == 2)
            {
                Console.WriteLine("You've won " + count + " out of " + 2 + " games.");
            }
            else if (n == 3)
            {
                Console.WriteLine("You've won " + count + " out of " + 2 + " games.");
            }


        }
        public bool checkPos(List<Card> list, int n)
        {
            bool checkCard = false;
            if (n == 1)
            {
                checkCard = ten.CheckPossibility(tableCard);
            }
            else if (n == 2)
            {
                checkCard = eleven.CheckPossibility(tableCard);
            }
            else if (n == 3)
            {
                checkCard = thirteen.CheckPossibility(tableCard);
            }
            return checkCard;
        }

        public bool checkIsCondition(List<Card> list, int n)
        {
            bool checkCard = false;
            if (n == 1)
            {
                checkCard = ten.checkCard(list);
            }
            else if (n == 2)
            {
                checkCard = eleven.checkCard(list);
            }
            else if (n == 3)
            {
                checkCard = thirteen.checkCard(list);
            }
            return checkCard;
        }
        public void PrintCard(List<Card> list)
        {
            int n = 1;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Card Number " + (n++) + ": Rank is " + list[i].Rank + " Suit is " + list[i].Suit);
            }
        }


        public void replaceCard(List<string> index, bool check)
        {
            if (check)
            {
                for (int i = 0; i < index.Count; i++)
                {
                    if (deck.Empty)
                    {
                        tableCard.RemoveAt(Convert.ToInt32(index[i]) - 1);
                    } else
                    {
                        tableCard.RemoveAt(Convert.ToInt32(index[i]) - 1);
                        tableCard.Insert((Convert.ToInt32(index[i]) - 1), deck.TakeTopCard());
                    }
                }
                Console.WriteLine("Replace Success");
            }

        }


        public void remainCard()
        {
            Console.WriteLine("remain number of card in the deck :" + deck.Cut());
        }

        public bool Empty()
        {
            return tableCard.Count == 0; 
    }

        public bool isWin()
        {
            if (deck.Empty)
            {
                if (Empty())
                {
                    return true; 
                }
            }
            return false; 
        }

        public List<Card> selectedCard(List<string> list)
        {
            for (int i =0; i<list.Count; i++)
            {
                selectCardValue.Add(tableCard[Convert.ToInt32(list[i])-1]);
            }
            return selectCardValue;
        }

    }
}
