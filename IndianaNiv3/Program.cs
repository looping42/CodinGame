using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaNiv3
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // number of columns.
            int H = int.Parse(inputs[1]); // number of rows.
            int[,] chemin = new int[W, H];//tableau comprenant le chemin de haut en bas

            for (int t = 0; t < H; t++)
            {
                string LINE = Console.ReadLine(); // each line represents a line in the grid and contains W integers T. The absolute value of T specifies the type of the room. If T is negative, the room cannot be rotated.
                //Console.Error.WriteLine(LINE);
                string[] temp = LINE.Split(new char[] { ' ' });

                for (int o = 0; o < temp.Length; o++)
                {
                    chemin[o, t] = Convert.ToInt32(temp[o]);
                    Console.Error.Write(chemin[o, t]);
                }
                Console.Error.WriteLine();
            }

            int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit.

            // game loop
            while (true)
            {
                //Position indy
                inputs = Console.ReadLine().Split(' ');
                int XI = int.Parse(inputs[0]);
                int YI = int.Parse(inputs[1]);
                string POSI = inputs[2];

                //Point d'entrée ( valeur nombre )
                int pointEntreeIndy = choiceEnterStart(POSI);
                //Case actuel à chaque tour
                int CaseActuel = chemin[XI, YI];

                #region Rocher

                //Position rochers
                int R = int.Parse(Console.ReadLine()); // the number of rocks currently in the grid.
                for (int i = 0; i < R; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    int XR = int.Parse(inputs[0]);
                    int YR = int.Parse(inputs[1]);
                    string POSR = inputs[2];
                }

                #endregion

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                Console.WriteLine("WAIT"); // One line containing on of three commands: 'X Y LEFT', 'X Y RIGHT' or 'WAIT'
            }
        }

        /// <summary>
        /// retourne le texte de sortie concernant le nombre entrée
        /// </summary>
        /// <param name="sortie"></param>
        /// <returns></returns>
        public static string choiceSortieOut(int sortie)
        {
            if (sortie == 2)
            {
                return "RIGHT";
            }
            else if (sortie == 3)
            {
                return "TOP";
            }
            else
            {
                return "LEFT";
            }
        }

        /// <summary>
        /// retourne le texte d'entrée pour le nombre sortie
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int choiceEnterStart(string direction)
        {
            if (direction == "TOP")
            {
                return 1;
            }
            else if (direction == "RIGHT")
            {
                return 2;
            }
            else
            {
                return 4;
            }
        }

        /// <summary>
        /// selon move right or left affiche le nouveau type de case
        /// </summary>
        /// <param name="newCase"></param>
        /// <returns></returns>
        public static int ChoiceCaseSelonRightMove(int newCase, char leftOrRight)
        {
            if (newCase > 1)
            {
                //Toute les cases de 2 à 5 , aprés un move left ou right
                if (newCase < 6)
                {
                    if ((newCase == 3) && (newCase == 5))
                    {
                        return newCase - 1;
                    }
                    else
                    {
                        return newCase + 1;
                    }
                }//toute les cases qui sont à a la limite droite
                else if ((newCase == 9) && (newCase == 13) && (leftOrRight == 'R'))
                {
                    return newCase - 3;
                }
                else if (leftOrRight == 'R')
                {
                    return newCase + 1;
                }//toute les cases qui sont à a la limite gauche
                else if ((newCase == 6) && (newCase == 10) && (leftOrRight == 'L'))
                {
                    return newCase + 3;
                }
                else if (leftOrRight == 'L')
                {
                    return newCase - 1; ;
                }
                else
                {
                    return newCase;
                }
            }
            else
            {
                return newCase;
            }

        }

        public static bool VerifPossibleMove(int newCase)
        {
            if (newCase < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public static int ChoiceCaseSelonLeftMove(int newCase)
        //{
        //    if ((newCase > 1) && (newCase < 14) && (newCase != 6)
        //    {
        //        return newCase - 1;
        //    }
        //    else
        //    {
        //        return newCase;
        //    }

        //}

        /// <summary>
        /// Choix selon la case en entrée + direction entrée
        /// Retourne le coté qui est concerné en sortie
        /// la sortie ne peu pas etre en haut 
        /// la sortie ne peu pas être hors du tableau
        /// </summary>
        public static bool ChoiceOutForEnterCase(int caseActuel, int[,] chemin)
        {

            return true;
        }
        /// <summary>
        /// retourne la sortie 
        /// </summary>
        /// <param name="caseActuel"></param>
        /// <returns></returns>
        //public static int ChoiceSortieSelonEnter(int caseActuel)
        //{


        //    if (caseActuel == 1)
        //    {
        //        return 3;
        //    }
        //    else 
        //    {

        //        //Toute les cases de 2 à 5 , aprés un move left ou right
        //        if (caseActuel < 6)
        //        {
        //            if ((caseActuel == 3) && (caseActuel == 5))
        //            {
        //                return caseActuel - 1;
        //            }
        //            else
        //            {
        //                return caseActuel + 1;
        //            }
        //        }//toute les cases qui sont à a la limite droite
        //        else if ((caseActuel == 9) && (caseActuel == 13))
        //        {
        //            return caseActuel - 3;
        //        }
        //        else if ((caseActuel == 6) && (caseActuel == 10))
        //        {
        //            return caseActuel + 3;
        //        }

        //    }
        //}
    }
    public class Piece
    {
        public int Name;

        public bool TopEnter;
        public bool RightEnterOut;
        public bool LeftEnterOut;

        public bool DownOut;

        public Piece(bool topEnter, bool rightEnterOut, bool leftEnterOut, bool downOut)
        {
            this.TopEnter = topEnter;
            this.RightEnterOut = rightEnterOut;
            this.LeftEnterOut = leftEnterOut;

            this.DownOut = downOut;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topEnter"></param>
        /// <param name="rightEnterOut"></param>
        /// <param name="leftEnterOut"></param>
        /// <param name="downOut"></param>
        /// <returns></returns>
        public List<int> CheckEnter(bool topEnter, bool rightEnterOut, bool leftEnterOut, bool downOut)
        {
            List<int> tableau = new List<int>();
            if (TopEnter)
            {
                tableau.Add(1);
            }
            if (rightEnterOut)
            {
                tableau.Add(2);
            }
            if (leftEnterOut)
            {
                tableau.Add(4);
            }
            if (downOut)
            {
                tableau.Add(3);
            }
            return tableau;
        }
    }
}
