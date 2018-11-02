using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bataille
{
    internal class Program
    {
        //public enum AllCards { un, deux, trois, quatre, cinq, six, sept, huit, neuf, dix };

        //public enum CardHigh { J, K, D, A };

        private static void Main(string[] args)
        {
            List<string> cardValue = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            //int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
            CardPlayer cards1 = new CardPlayer();
            cards1.Cards = new Queue();
            //for (int i = 0; i < n; i++)
            //{
            //    string cardp1 = Console.ReadLine(); // the n cards of player 1
            //    cards1.Cards.Enqueue(cardp1);
            //}
            cards1.Cards.Enqueue("A");
            cards1.Cards.Enqueue("4");
            cards1.Cards.Enqueue("5");
            cards1.Cards.Enqueue("6");
            cards1.Cards.Enqueue("Q");
            cards1.Cards.Enqueue("J");
            cards1.Cards.Enqueue("8");
            cards1.Cards.Enqueue("2");
            cards1.Cards.Enqueue("7");
            cards1.Cards.Enqueue("J");
            cards1.Cards.Enqueue("J");
            cards1.Cards.Enqueue("6");
            cards1.Cards.Enqueue("K");
            cards1.Cards.Enqueue("Q");
            cards1.Cards.Enqueue("9");
            cards1.Cards.Enqueue("2");
            cards1.Cards.Enqueue("5");
            cards1.Cards.Enqueue("9");
            cards1.Cards.Enqueue("6");
            cards1.Cards.Enqueue("8");
            cards1.Cards.Enqueue("A");
            cards1.Cards.Enqueue("4");
            cards1.Cards.Enqueue("2");
            cards1.Cards.Enqueue("2");
            cards1.Cards.Enqueue("7");
            cards1.Cards.Enqueue("8");
            //int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
            CardPlayer cards2 = new CardPlayer();
            cards2.Cards = new Queue();
            //for (int i = 0; i < m; i++)
            //{
            //    string cardp2 = Console.ReadLine(); // the m cards of player 2
            //    cards2.Cards.Enqueue(cardp2);
            //}
            cards2.Cards.Enqueue("10");
            cards2.Cards.Enqueue("4");
            cards2.Cards.Enqueue("6");
            cards2.Cards.Enqueue("3");
            cards2.Cards.Enqueue("K");
            cards2.Cards.Enqueue("J");
            cards2.Cards.Enqueue("10");
            cards2.Cards.Enqueue("A");
            cards2.Cards.Enqueue("5");
            cards2.Cards.Enqueue("K");
            cards2.Cards.Enqueue("10");
            cards2.Cards.Enqueue("9");
            cards2.Cards.Enqueue("9");
            cards2.Cards.Enqueue("8");
            cards2.Cards.Enqueue("5");
            cards2.Cards.Enqueue("A");
            cards2.Cards.Enqueue("3");
            cards2.Cards.Enqueue("4");
            cards2.Cards.Enqueue("K");
            cards2.Cards.Enqueue("7");
            cards2.Cards.Enqueue("3");
            cards2.Cards.Enqueue("Q");
            cards2.Cards.Enqueue("10");
            cards2.Cards.Enqueue("3");
            cards2.Cards.Enqueue("7");
            cards2.Cards.Enqueue("Q");
            Console.Error.WriteLine("carte joueur 1");
            cards1.FilterCards();
            foreach (var item in cards1.Cardtrims)
            {
                Console.Error.WriteLine(item);
            }

            Console.Error.WriteLine("carte joueur 2");
            cards2.FilterCards();
            foreach (var item in cards2.Cardtrims)
            {
                Console.Error.WriteLine(item);
            }

            int nbrTurn = 0;
            int carteCourante = 0;
            bool end = false;
            bool player1Win = false;
            Queue queueEgaliteval1 = new Queue();
            Queue queueEgaliteval2 = new Queue();
            bool egalite = false;
            while (!end)
            {
                //cards1.FilterCards();
                //cards2.FilterCards();
                string val = cards1.Cardtrims.Dequeue().ToString();
                //Valeur lié à la postion pour la carte courante provenant du joueur 1
                int pos = cardValue.FindIndex(x => x == val);

                Console.Error.WriteLine("Poscard1 : " + pos);
                string val2 = cards2.Cardtrims.Dequeue().ToString();
                //Valeur lié à la postion pour la carte courante provenant du joueur 2
                int pos2 = cardValue.FindIndex(x => x == val2);
                Console.Error.WriteLine("Poscard2 : " + pos2);

                if (pos > pos2)
                {
                    if (egalite)
                    {
                        foreach (string queuee in queueEgaliteval1)
                        {
                            cards1.Cardtrims.Enqueue(queuee);
                        }
                        cards1.Cardtrims.Enqueue(val);
                        foreach (string queuee in queueEgaliteval2)
                        {
                            cards1.Cardtrims.Enqueue(queuee);
                        }
                        cards1.Cardtrims.Enqueue(val2);
                        queueEgaliteval1.Clear();
                        queueEgaliteval2.Clear();
                    }
                    else
                    {
                        cards1.Cardtrims.Enqueue(val);
                        cards1.Cardtrims.Enqueue(val2);
                    }
                    egalite = false;
                    nbrTurn++;
                }
                else if (pos < pos2)
                {
                    if (egalite)
                    {
                        foreach (string queuee in queueEgaliteval1)
                        {
                            cards2.Cardtrims.Enqueue(queuee);
                        }
                        cards2.Cardtrims.Enqueue(val);
                        foreach (string queuee in queueEgaliteval2)
                        {
                            cards2.Cardtrims.Enqueue(queuee);
                        }
                        cards2.Cardtrims.Enqueue(val2);
                        queueEgaliteval1.Clear();
                        queueEgaliteval2.Clear();
                    }
                    else
                    {
                        cards2.Cardtrims.Enqueue(val);
                        cards2.Cardtrims.Enqueue(val2);
                    }
                    egalite = false;
                    nbrTurn++;
                }
                else //cas d'égalité
                {
                    queueEgaliteval2.Enqueue(val2);
                    if (cards2.Cardtrims.Count < 3)
                    {
                        end = true;
                        Console.WriteLine("PAT");
                    }
                    queueEgaliteval2.Enqueue(cards2.Cardtrims.Dequeue().ToString());
                    queueEgaliteval2.Enqueue(cards2.Cardtrims.Dequeue().ToString());
                    queueEgaliteval2.Enqueue(cards2.Cardtrims.Dequeue().ToString());
                    queueEgaliteval1.Enqueue(val);
                    if (cards1.Cardtrims.Count < 3)
                    {
                        end = true;
                        Console.WriteLine("PAT");
                    }
                    queueEgaliteval1.Enqueue(cards1.Cardtrims.Dequeue().ToString());
                    queueEgaliteval1.Enqueue(cards1.Cardtrims.Dequeue().ToString());
                    queueEgaliteval1.Enqueue(cards1.Cardtrims.Dequeue().ToString());
                    egalite = true;
                }

                carteCourante++;
                Console.Error.WriteLine("cards1.Cardtrims.Count() : " + cards1.Cardtrims.Count);

                if (cards1.Cardtrims.Count == 0)
                {
                    end = true;
                    player1Win = false;
                }
                Console.Error.WriteLine("cards2.Cardtrims.Count() : " + cards2.Cardtrims.Count);
                if (cards2.Cardtrims.Count == 0)
                {
                    end = true;
                    player1Win = true;
                }
            }
            if (player1Win)
            {
                Console.WriteLine("1 " + nbrTurn);
            }
            else
            {
                Console.WriteLine("2 " + nbrTurn);
            }

            Console.ReadLine();
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            //Console.WriteLine("PAT");
        }

        public class CardPlayer
        {
            public Queue Cards { get; set; }
            //public List<string> Cards { get; set; }

            public Queue Cardtrims { get; set; }
            //public List<string> Cardtrims { get; set; }

            public void FilterCards()
            {
                Cardtrims = new Queue();
                foreach (var item in Cards)
                {
                    Cardtrims.Enqueue(item.ToString().Trim(new Char[] { 'D', 'H', 'C', 'S' }));
                }
            }

            //public void FindAndRemoveFirstelement(string valToSearch)
            //{
            //    for (int i = 0; i < Cardtrims.Count(); i++)
            //    {
            //        if (Cardtrims[i] == valToSearch)
            //        {
            //            Cardtrims.RemoveAt(i);
            //            break;
            //        }
            //    }
            //}
        }
    }
}