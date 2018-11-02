using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> lstGrille = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                string[] test = row.Split(' ');
                foreach (var item in test)
                {
                    lstGrille.Add(Convert.ToInt32(item));
                }
            }
            string calls = Console.ReadLine();
            string[] callsSplit = calls.Split(' ');

            foreach (var item in callsSplit)
            {
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("answer");
        }
    }
}