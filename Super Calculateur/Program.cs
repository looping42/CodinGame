using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Calculateur
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int nbrJour = int.Parse(Console.ReadLine());
            List<KeyValuePair<int, int>> tableau = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < nbrJour; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                tableau.Add(new KeyValuePair<int, int>(int.Parse(inputs[0]), int.Parse(inputs[1]) + int.Parse(inputs[0]) - 1));
            }
            tableau.Sort(Compare2);

            int[] jourDebut = new int[nbrJour];
            int[] jourFin = new int[nbrJour];
            int j = 0;
            Console.Error.WriteLine("tableau");
            foreach (KeyValuePair<int, int> item in tableau)
            {
                Console.Error.Write("item.Key" + item.Key);
                Console.Error.Write("item.Value" + item.Value);
                jourDebut[j] = item.Key;
                jourFin[j] = item.Value;
                j = j + 1;
            }

            List<int> res = SelectMaxActivities(jourDebut, jourFin);
            foreach (var item in res)
            {
                Console.Error.WriteLine(item);
            }
            Console.Error.WriteLine("result");
            Console.Write(res.Count());

            //Console.ReadLine();
        }

        private static int Compare2(KeyValuePair<int, int> a, KeyValuePair<int, int> b)
        {
            return a.Value.CompareTo(b.Value);
        }

        public static List<int> SelectMaxActivities(int[] s, int[] f)
        {
            //longueur tableau
            int n = f.Length;
            List<int> result = new List<int>();

            // la premiére activité est toujours choisis
            int i = 0;
            result.Add(i);
            // pour le reste
            for (int j = 1; j < n; j++)
            {
                //si l'activité a un départ plus grand ou égal au temps de fin de l'activité déjà préselectionnée
                //on l'a choisi
                if (s[j] > f[i])
                {
                    result.Add(j);
                    i = j;
                }
            }
            return result;
        }
    }
}