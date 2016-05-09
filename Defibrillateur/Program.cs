using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defibrillateur
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double resultat = double.MaxValue;
            int numerodudefibrilateur = 0;

            //on lit la premiére ligne contenant la longueur du passage du vaisseau
            double longitude = double.Parse(Console.ReadLine().Replace(",", "."));
            double latitude = double.Parse(Console.ReadLine().Replace(",", "."));
            Console.Error.WriteLine("longitude " + longitude);
            Console.Error.WriteLine("latitude " + latitude);
            int nbrdefibrilateur = Convert.ToInt32(Console.ReadLine());

            string[] positiondeffibrilateur = new string[nbrdefibrilateur];
            for (int i = 0; i < nbrdefibrilateur; i++)
            {
                positiondeffibrilateur[i] = Console.ReadLine();
            }

            string pos4;
            string pos5;
            string pos6;
            double posx;
            double posy;
            int j = 0;
            while (j < nbrdefibrilateur)
            {
                pos6 = positiondeffibrilateur[j].Split(';')[1];
                pos5 = positiondeffibrilateur[j].Split(';')[2];
                pos4 = positiondeffibrilateur[j].Split(';')[3];
                posx = double.Parse(positiondeffibrilateur[j].Split(';')[4].Replace(",", "."));
                posy = double.Parse(positiondeffibrilateur[j].Split(';')[5].Replace(",", "."));

                double x = (posx - longitude) * (Math.Cos((posy + latitude) / 2));
                double y = posy - latitude;
                double distance = Math.Sqrt(x * x + y * y) * 6371;

                if (distance < resultat)
                {
                    resultat = distance;
                    numerodudefibrilateur = j;
                }
                j = j + 1;
            }
            Console.WriteLine(positiondeffibrilateur[numerodudefibrilateur].Split(';')[1]);
        }
    }

    //string LON = Console.ReadLine();
    //    string LAT = Console.ReadLine();

    //    int nbrdefibrilateur = Convert.ToInt32(Console.ReadLine());

    //    string[] positiondeffibrilateur = new string[nbrdefibrilateur];
    //    for (int i = 0; i < nbrdefibrilateur; i++)
    //    {
    //        positiondeffibrilateur[i] = Console.ReadLine();
    //    }

    //    double x = (LON - longitude) * (Math.Cos(posy + latitude / 2));
    //    double y = posx - latitude;
    //    double distance = Math.Sqrt(x * x + y * y) * 6371;

    //    Console.WriteLine("answer");
}