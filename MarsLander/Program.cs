using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsLander
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string line;
            char[] sep = new char[] { ' ' };
            string[] split;
            int nbrpoint;

            int pointx, pointy;
            int solplat1 = 0;
            int solplat2 = 0;
            int vithorizontale, vitverticale;
            int anglerotation;
            int fuel;
            int puissance;

            // on lit la ligne et on récupére le nombre de point
            nbrpoint = Convert.ToInt32(Console.ReadLine());
            //  zone de plat
            int ancienvaleury = 0;
            int ancienvaleurx = 0;
            for (int i = 1; i <= nbrpoint; i++)
            {
                line = Console.ReadLine();
                split = line.Split(sep);              //on la split  en  2
                pointx = Convert.ToInt32(split[0]);   //on récupére les positions
                pointy = Convert.ToInt32(split[1]);

                if (pointy != ancienvaleury)
                {
                    ancienvaleury = pointy;
                    ancienvaleurx = pointx;
                }
                else
                {
                    solplat1 = ancienvaleurx;
                    solplat2 = pointx;
                }
            }

            while (true)
            {
                // point x et y de la capsule , vitesse horizontale et vitesse verticale , le fuel , la rotation , la puissance
                line = Console.ReadLine();
                split = line.Split(sep);

                pointx = Convert.ToInt32(split[0]);
                pointy = Convert.ToInt32(split[1]);
                vithorizontale = Convert.ToInt32(split[2]);
                vitverticale = Convert.ToInt32(split[3]);
                fuel = Convert.ToInt32(split[4]);
                anglerotation = Convert.ToInt32(split[5]);
                puissance = Convert.ToInt32(split[6]);
                Console.Error.WriteLine("pointx : " + pointx);
                Console.Error.WriteLine("pointy : " + pointy);

                Console.Error.WriteLine("vithorizontale : " + vithorizontale);

                Console.Error.WriteLine("vitverticale : " + vitverticale);

                Console.Error.WriteLine("fuel : " + fuel);
                Console.Error.WriteLine("anglerotation : " + anglerotation);
                Console.Error.WriteLine("puissance : " + puissance);

                if (anglerotation > 0)
                {
                    anglerotation = anglerotation - 15;
                }
                if (anglerotation < 0)
                {
                    anglerotation = anglerotation + 15;
                }

                if (vitverticale <= -40)
                {
                    if (puissance < 4)
                    {
                        puissance = puissance + 1;
                    }
                }
                if (vitverticale >= -10)
                {
                    if (puissance == 4)
                    {
                        puissance = puissance - 1;
                    }
                }
                if (pointx < solplat1) //si avant le zone de plat
                {
                    Console.Error.WriteLine("si avant la zone sol");
                    anglerotation = anglerotation - 15;
                }
                else if (pointx > solplat2) //si aprés la zone de plat
                {
                    Console.Error.WriteLine("si aprés la zone sol");
                    anglerotation = anglerotation + 15;
                }
                else
                {
                    Console.Error.WriteLine("si pos dans la zone sol");
                    if (pointx < solplat1) //si avant le zone de plat
                    {
                        if (vithorizontale >= 20)
                        {
                            anglerotation = anglerotation + 15;
                        }
                    }
                    else if (pointx > solplat2) //si aprés la zone de plat
                    {
                        anglerotation = anglerotation - 15;
                    }
                    AjusteVitesseVerticale(vitverticale, vithorizontale, ref anglerotation);
                }
                Console.Error.WriteLine("puissance : " + puissance);
                if (vitverticale <= -40)
                {
                    Console.Error.WriteLine("vitverticale<=40");
                    if (puissance < 4)
                    {
                        Console.Error.WriteLine("vitverticale inférieur -4");
                        puissance = puissance + 1;
                    }
                }
                if (vitverticale >= -10)
                {
                    Console.Error.WriteLine("vitverticale >= -10");
                    if (puissance == 4)
                    {
                        Console.Error.WriteLine("vitverticale >= -10");
                        puissance = puissance - 1;
                    }
                }
                Console.WriteLine(anglerotation + " " + puissance);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="vitverticale"></param>
        /// <param name="anglerotation"></param>
        /// <param name="puissance"></param>
        private static void AjusteVitesseVerticale(int vitverticale, int vithorizontale, ref int anglerotation)
        {
            //if (puissance < 3)
            //{
            //    puissance = puissance + 1;
            //}
            Console.Error.WriteLine("si vite verticale dans la zone sol");
            if ((anglerotation > 0) && (anglerotation < 90))
            {
                anglerotation = anglerotation - 15;
            }
            else if ((anglerotation < 0) && (anglerotation > -90))
            {
                anglerotation = anglerotation + 15;
            }
            if ((vithorizontale > 20) && (anglerotation < 90))
            {
                Console.Error.WriteLine("si vite horizontale 1 dans la zone sol");
                anglerotation = anglerotation + 15;
            }
            else if ((vithorizontale < -20) && (anglerotation > -90))
            {
                Console.Error.WriteLine("si vite horizontale 2 dans la zone sol");
                anglerotation = anglerotation - 15;
            }
        }
    }
}