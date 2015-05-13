using System;
using System.Collections.Generic;
using System.Linq;

namespace Teeds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int n = Convert.ToInt32(line);
            Console.Error.WriteLine(n);

            //Liste des liens
            List<Lien> LinkList = new List<Lien>();

            for (int i = 0; i < n; i++)
            {
                //Ajout des liens à a la liste
                Lien data = new Lien();
                string donnees = Console.ReadLine();
                data.Valeurlink1 = Convert.ToInt32(donnees.Split(' ')[0]);
                data.Valeurlink2 = Convert.ToInt32(donnees.Split(' ')[1]);
                LinkList.Add(data);
                Console.Error.WriteLine(donnees);
            }

            //Nombre de noeud distinct de la list
            var noeudDistinct1 = (from c in LinkList
                                  select c.Valeurlink1).Union(from c in LinkList
                                                              select c.Valeurlink2).Distinct();

            List<Noeud> NodeList = new List<Noeud>();
            foreach (var item in noeudDistinct1)
            {
                Noeud temp = new Noeud();
                temp.Valeur = item;
                temp.Visite = false;
                NodeList.Add(temp);
            }

            //List de noeud compléte
            Console.WriteLine(ParcoursNode(LinkList, NodeList));
        }

        /// <summary>
        /// Lien
        /// </summary>
        public class Lien
        {
            public int Valeurlink1;
            public int Valeurlink2;
        }

        public class Noeud
        {
            public int Valeur;
            public bool Visite;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="listLien"></param>
        /// <param name="listNode"></param>
        /// <returns></returns>
        ///
        public static int ParcoursNode(List<Lien> listLien, List<Noeud> listNode)
        {
            List<Noeud> listNodeTemp = new List<Noeud>();
            int comptNbrPassage;
            int resultTemp = 0;
            comptNbrPassage = 0;
            resultTemp = 1000;
            //pour chaque noeud contenu dans la liste
            foreach (var noeud in listNode)
            {
                //Si le Noeud n'a pas été visité
                if (noeud.Visite != true)
                {
                    DFS(listLien, listNode, ref comptNbrPassage, ref resultTemp, noeud);
                }
            }
            return resultTemp;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="listLien"></param>
        /// <param name="listNode"></param>
        /// <param name="compteurNoeudVisite"></param>
        /// <param name="comptNbrPassage"></param>
        /// <param name="resultTemp"></param>
        /// <param name="listNodeTemp"></param>
        /// <param name="noeud"></param>
        private static void DFS(List<Lien> listLien, List<Noeud> listNode, ref int comptNbrPassage, ref int resultTemp, Noeud noeud)
        {
            noeud.Visite = true;
            //Liste lien vers noeuds voisins
            var lienVoisin = from c in listLien
                             where c.Valeurlink1 == noeud.Valeur || c.Valeurlink2 == noeud.Valeur
                             select c;

            //liste des noeuds voisins
            var noeudVoisins = (from c in lienVoisin
                                where c.Valeurlink1 != noeud.Valeur
                                select c.Valeurlink1).Union(from c in lienVoisin
                                                            where c.Valeurlink2 != noeud.Valeur
                                                            select c.Valeurlink2).Distinct();

            //Recherche des noeuds voisins pour validation visit
            foreach (var item in noeudVoisins)
            {
                var NoeudEnCoursDeVisit = (from c in listNode
                                           where item == c.Valeur && c.Visite != true
                                           select c).FirstOrDefault();
                if (NoeudEnCoursDeVisit != null)
                {
                    comptNbrPassage += 1;
                    DFS(listLien, listNode, ref  comptNbrPassage, ref  resultTemp, NoeudEnCoursDeVisit);
                }

            }
            if (comptNbrPassage < resultTemp)
            {
                resultTemp = comptNbrPassage;
            }
        }
    }
}