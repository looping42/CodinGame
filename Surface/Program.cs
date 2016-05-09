using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surface
{
    internal class Program
    {
        public const char LAC = 'O';

        private static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());

            char[,] tab = new char[H, L];
            bool[,] tabVisitOrNot = new bool[H, L];

            for (int i = 0; i < H; i++)
            {
                char[] row = Console.ReadLine().ToArray();
                for (int j = 0; j < row.Length; j++)
                {
                    tab[i, j] = row[j];
                }
            }

            int N = int.Parse(Console.ReadLine());
            List<KeyValuePair<int, int>> listTotest = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                listTotest.Add(new KeyValuePair<int, int>(int.Parse(inputs[1]), int.Parse(inputs[0])));
            }
            List<KeyValuePair<int, int>> allVoisin = new List<KeyValuePair<int, int>>();

            foreach (var item in listTotest)
            {
                if (GetVoisins(tab, item.Key, item.Value))
                {
                    initVisitOrNot(tabVisitOrNot);
                    Parse2(tab, tabVisitOrNot, item.Key, item.Value, ref allVoisin);
                    //Console.Error.WriteLine(allVoisin.Count());
                    if (allVoisin.Count() == 0)
                    {
                        Console.WriteLine("1");
                    }
                    else
                    {
                        //Console.Error.WriteLine(allVoisin.Count());
                        Console.WriteLine(allVoisin.Count());
                    }

                    allVoisin.Clear();
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            //Console.WriteLine(allVoisin.Count());
        }

        public static void Parse(char[,] tab, bool[,] visitOrNot, int h, int l, ref List<KeyValuePair<int, int>> allVoisin)
        {
            List<KeyValuePair<int, int>> thisVoisins = CheckVoisins(tab, visitOrNot, h, l);
            //List<KeyValuePair<int, int>> thisVoisinstemp = new List<KeyValuePair<int, int>>();
            //thisVoisinstemp.AddRange(thisVoisins);
            foreach (var item in thisVoisins)
            {
                visitOrNot[item.Key, item.Value] = true;
                allVoisin.Add(new KeyValuePair<int, int>(item.Key, item.Value));
                Parse(tab, visitOrNot, item.Key, item.Value, ref allVoisin);
            }
        }

        public static void Parse2(char[,] tab, bool[,] visitOrNot, int h, int l, ref List<KeyValuePair<int, int>> allVoisin)
        {
            //if (visitOrNot[h, l])
            //{
            //    return;
            //}

            //List<KeyValuePair<int, int>> thisVoisinstemp = new List<KeyValuePair<int, int>>();
            //thisVoisinstemp.Add(new KeyValuePair<int, int>(h, l));
            //while (thisVoisinstemp.Count() > 0)
            //{
            //    KeyValuePair<int, int> first = thisVoisinstemp[0];
            //    allVoisin.Add(thisVoisinstemp[0]);
            //    thisVoisinstemp.RemoveAt(0);

            //    List<KeyValuePair<int, int>> thisVoisins = CheckVoisins(tab, visitOrNot, h, l);
            //    foreach (var item in thisVoisins)
            //    {
            //        if (!visitOrNot[h, l])
            //        {
            //            visitOrNot[item.Key, item.Value] = true;
            //            thisVoisinstemp.Add(new KeyValuePair<int, int>(item.Key, item.Value));
            //            allVoisin.Add(new KeyValuePair<int, int>(item.Key, item.Value));
            //            //Parse(tab, visitOrNot, item.Key, item.Value, ref allVoisin);
            //        }
            //    }

            //}
            KeyValuePair<int, int> premierLoc = new KeyValuePair<int, int>(h, l);
            List<KeyValuePair<int, int>> thisVoisinstemp = new List<KeyValuePair<int, int>>();
            thisVoisinstemp.Add(premierLoc);
            while (thisVoisinstemp.Count() > 0)
            {
                KeyValuePair<int, int> prems = thisVoisinstemp[0];
                thisVoisinstemp.Remove(prems);
                visitOrNot[prems.Key, prems.Value] = true;
                allVoisin.Add(new KeyValuePair<int, int>(prems.Key, prems.Value));
                List<KeyValuePair<int, int>> thisVoisinstampon = CheckVoisins(tab, visitOrNot, prems.Key, prems.Value);

                for (int i = 0; i < thisVoisinstampon.Count(); i++)
                {
                    if (!visitOrNot[thisVoisinstampon[i].Key, thisVoisinstampon[i].Value])
                    {
                        visitOrNot[thisVoisinstampon[i].Key, thisVoisinstampon[i].Value] = true;
                        allVoisin.Add(new KeyValuePair<int, int>(thisVoisinstampon[i].Key, thisVoisinstampon[i].Value));
                        //List<KeyValuePair<int, int>> thisVoisinstampon = CheckVoisins(tab, visitOrNot, item.Key, item.Value);
                        thisVoisinstemp.Add(new KeyValuePair<int, int>(thisVoisinstampon[i].Key, thisVoisinstampon[i].Value));
                    }
                }
            }
        }

        public static List<KeyValuePair<int, int>> CheckVoisins(char[,] tab, bool[,] visitOrNot, int h, int l)
        {
            List<KeyValuePair<int, int>> res = new List<KeyValuePair<int, int>>();
            if (CheckhauteurLargeur(tab, h + 1, l))
            {
                if (GetVoisins(tab, h + 1, l) && (!visitOrNot[h + 1, l]))
                {
                    visitOrNot[h + 1, l] = true;
                    res.Add(new KeyValuePair<int, int>(h + 1, l));
                }
            }
            if (CheckhauteurLargeur(tab, h - 1, l))
            {
                if (GetVoisins(tab, h - 1, l) && (!visitOrNot[h - 1, l]))
                {
                    visitOrNot[h - 1, l] = true;
                    res.Add(new KeyValuePair<int, int>(h - 1, l));
                }
            }
            if (CheckhauteurLargeur(tab, h, l + 1))
            {
                if (GetVoisins(tab, h, l + 1) && (!visitOrNot[h, l + 1]))
                {
                    visitOrNot[h, l + 1] = true;
                    res.Add(new KeyValuePair<int, int>(h, l + 1));
                }
            }
            if (CheckhauteurLargeur(tab, h, l - 1))
            {
                if (GetVoisins(tab, h, l - 1) && (!visitOrNot[h, l - 1]))
                {
                    visitOrNot[h, l - 1] = true;
                    res.Add(new KeyValuePair<int, int>(h, l - 1));
                }
            }
            return res;
        }

        public static bool CheckhauteurLargeur(char[,] tab, int h, int l)
        {
            if ((h < tab.GetLength(0)) && (h >= 0) && (l >= 0) && (l < tab.GetLength(1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetVoisins(char[,] tab, int h, int l)
        {
            if (tab[h, l] == LAC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void initVisitOrNot(bool[,] tabVisitOrNot)
        {
            for (int i = 0; i < tabVisitOrNot.GetLength(0); i++)
            {
                for (int j = 0; j < tabVisitOrNot.GetLength(1); j++)
                {
                    tabVisitOrNot[i, j] = false;
                }
            }
        }
    }
}