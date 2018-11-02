using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plightFellowShipRing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] inputs;
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int XS = int.Parse(inputs[0]);
                int YS = int.Parse(inputs[1]);
            }
            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int XO = int.Parse(inputs[0]);
                int YO = int.Parse(inputs[1]);
            }
            for (int i = 0; i < L; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs[0]);
                int N2 = int.Parse(inputs[1]);
            }
            int S = int.Parse(Console.ReadLine());
            int E = int.Parse(Console.ReadLine());

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("path");
        }
    }
}
}