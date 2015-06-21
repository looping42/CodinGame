using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Calculateur
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            Console.Error.WriteLine("N" + N);
            List<Periode> NewPeriodRegistered = new List<Periode>();
            for (int i = 0; i < N; i++)
            {

                string[] inputs = Console.ReadLine().Split(' ');
                Periode ListPeriode = new Periode();
                ListPeriode.JourDebut = int.Parse(inputs[0]);
                ListPeriode.Duree = int.Parse(inputs[1]);
                ListPeriode.visit = false;
                NewPeriodRegistered.Add(ListPeriode);
                Console.Error.WriteLine("temp.JourDebut" + ListPeriode.JourDebut);
                Console.Error.WriteLine("temp.Duree" + ListPeriode.Duree);

            }

            List<Periode> listResult = new List<Periode>();
            listResult.AddRange(NewPeriodRegistered);

            //remove l'élement num 1


            int compteurLien = 0;
            int compteurTotal = 0;

            //on sauvegarde la premiére periode afin de la comparer au autres
            Periode PeriodeToCompare = new Periode();
            PeriodeToCompare.JourDebut = NewPeriodRegistered[0].JourDebut;
            PeriodeToCompare.Duree = NewPeriodRegistered[0].JourFin;
            NewPeriodRegistered[0].visit = true;

            //Boucle sur la liste de période 
            foreach (var item in NewPeriodRegistered)
            {

                if (((item.visit ==false )&& ((item.JourDebut >= PeriodeToCompare.JourFin) && (item.JourDebut <= PeriodeToCompare.JourDebut))
                    || (item.visit == false) && (item.JourFin >= PeriodeToCompare.JourDebut) && (item.JourFin <= PeriodeToCompare.JourFin)))
                {

                }
                else if (item.visit ==false )
                {
                    compteurLien++;
                    PeriodeToCompare.JourDebut = item.JourDebut;
                    PeriodeToCompare.Duree = item.Duree;
                    item.visit =true;
                    listResult.Add(item);
                }
 
                
                if (compteurLien > compteurTotal)
                {
                    compteurTotal = compteurLien;
                }
            }

            //liste de resultat
            foreach (var item in listResult)
            {
                Console.Error.Write("Résultat debut : " + item.JourDebut);
                Console.Error.Write("Résultat fin : " + item.JourFin);
                Console.Error.WriteLine();
            }
            Console.WriteLine(compteurTotal);
        }
        public class Periode
        {
            public int JourDebut;
            public int Duree;
            public int JourFin { get { return (JourDebut +Duree)-1; } }
            public bool visit;
        }
    }
}
