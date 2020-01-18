using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = new List<string>();
            int numberOfSuits = 3;
            int numberOfRanks = 7;
            string[,] pile = new string[3, 7];
            cards = initialiseCards(cards, numberOfSuits, numberOfRanks);
            cards = shuffle(cards, numberOfSuits, numberOfRanks);
            for (int i = 0; i <= 2; i++) cards = rearrange(cards, pile);
            displayUsersCard(cards, numberOfSuits, numberOfRanks);
            Console.ReadKey();
        }


        static List<string> initialiseCards(List<string> cards, int numberOfSuits, int numberOfRanks)
        {
            string suit = "";
            string rank = "";
            string card = "";

            for (int i = 0; i < numberOfSuits; i++)
            {
                for (int j = 0; j < numberOfRanks; j++)
                {
                    switch (i)
                    {
                        case 0:
                            suit = "Diamonds";
                            break;
                        case 1:
                            suit = "Clubs";
                            break;
                        case 2:
                            suit = "Hearts";
                            break;
                        case 3:
                            suit = "Spades";
                            break;
                    }

                    switch (j)
                    {
                        case 0:
                            rank = "Ace";
                            break;
                        case 10:
                            rank = "Jack";
                            break;
                        case 11:
                            rank = "Queen";
                            break;
                        case 12:
                            rank = "King";
                            break;
                        default:
                            rank = Convert.ToString(j + 1);
                            break;
                    }

                    card = string.Format("{0} of {1}", rank, suit);
                    cards.Add(card);
                    //Console.WriteLine(card);
                }
            }
            return cards;
        }


        static List<string> shuffle(List<string> cards, int numberOfSuits, int numberOfRanks)
        {
            Random random = new Random();
            string temp = "";
            int numberOfCards = numberOfSuits * numberOfRanks;
            int numberOfShuffles = 1000;

            for (int i = 0; i < numberOfShuffles; i++)
            {
                int chosenCard = random.Next(0, numberOfCards);
                temp = cards[chosenCard];
                cards.Remove(cards[chosenCard]);
                cards.Add(temp);
            }

            //foreach (string element in cards) Console.WriteLine(element);
            return cards;
        }


        static List<string> rearrange(List<string> cards, string[,] pile)
        {
            int count = 0;
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    pile[j, i] = cards[count];
                    count++;
                }
            }
            cards.Clear();

            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Pile {0}:", i + 1);
                for (int j = 0; j <= 6; j++) Console.WriteLine(pile[i, j]);
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("Please select a card and enter what pile you see it in.");
            int chosenPile = Convert.ToInt16(Console.ReadLine()) - 1;

            Random random = new Random();
            int firstPile = -1;
            for (int i = 0; i <= 2; i++)
            {
                    int thePile = (i == 1) ? chosenPile : -2;
                    if (thePile == -2) do thePile = random.Next(0, 3); while (thePile == chosenPile || thePile == firstPile);
                    if (i == 0) firstPile = thePile;
                    for (int j = 6; j >= 0; j--) cards.Add(pile[thePile, j]);
            }
            return cards;
        }


        static void displayUsersCard(List<string> cards, int numberOfSuits, int numberOfRanks)
        {
            int numberOfCards = numberOfSuits * numberOfRanks;
            Console.WriteLine("You chose: {0}", cards[(numberOfCards + 1)/2 - 1]);
        }
    }
}