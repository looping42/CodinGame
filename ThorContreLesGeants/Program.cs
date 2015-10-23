using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThorContreLesGeants
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int TX = int.Parse(inputs[0]);
            int TY = int.Parse(inputs[1]);

            // game loop
            while (true)
            {
                //tableau de 40 par 18
                string[,] carte = new string[40, 18];
                carte[TX, TY] = "T";

                InitCarteAZero(carte);

                inputs = Console.ReadLine().Split(' ');
                int H = int.Parse(inputs[0]); // the remaining number of hammer strikes.
                int N = int.Parse(inputs[1]); // the number of giants which are still present on the map.
                for (int i = 0; i < N; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    int X = int.Parse(inputs[0]);
                    int Y = int.Parse(inputs[1]);
                    carte[X, Y] = "G";
                }


                VisuCarte(carte);
                int k = 1;
                while ((TX + k < carte.GetLength(0)) && (TX + k < TX + 9))
                {
                     
                    k = k + 1;
                }
                int compteurGeant = 0;
                //Parcours du tableau depuis la position X
                for (int i = TX; i < carte.GetLength(0) && i < (TX + 10); i++)
                {
                    //si Egal au géant , on ajoute au compteur
                    if ((carte[i, TY] != null) && (carte[i, TY] == "G"))
                    {
                        compteurGeant = compteurGeant + 1;
                    }
                }

                if (compteurGeant > 0)
                {
                    Console.WriteLine("STRIKE"); // The movement or action to be carried out: WAIT STRIKE N NE E SE S SW W or N
                }
                else
                {
                    Console.WriteLine("WAIT");
                }
            }
        }
        /// <summary>
        /// Visualisation de la carte a zero
        /// </summary>
        /// <param name="carte"></param>
        private static void VisuCarte(string[,] carte)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    Console.Error.Write(carte[i, j]);

                }
                Console.Error.WriteLine();
            }
        }
        /// <summary>
        /// Initlisation des valeurs de la carte a zero
        /// </summary>
        /// <param name="carte"></param>
        private static void InitCarteAZero(string[,] carte)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    carte[i, j] = "0";
                }
            }
        }
    }
}
