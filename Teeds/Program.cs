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

            //liste des noeuds Distinct
            List<Noeud> NodeList = new List<Noeud>();
            foreach (var item in noeudDistinct1)
            {
                Noeud temp = new Noeud();
                temp.Valeur = item;
                temp.Visite = false;
                temp.EstUnefEuilleSansEnfant = true;
                NodeList.Add(temp);
            }

            foreach (Noeud NoeudUnique in NodeList)
            {
                NoeudUnique.noeudEnfant = new List<Noeud>();
                foreach (Lien lienunique in LinkList)
                {
                    if (lienunique.Valeurlink1 == NoeudUnique.Valeur)
                    {
                        Noeud toAdd = NodeList.Where(x => x.Valeur == lienunique.Valeurlink2).FirstOrDefault();
                        NoeudUnique.EstUnefEuilleSansEnfant = false;
                        NoeudUnique.noeudEnfant.Add(toAdd);
                    }
                    if (lienunique.Valeurlink2 == NoeudUnique.Valeur)
                    {
                        Noeud toAdd = NodeList.Where(x => x.Valeur == lienunique.Valeurlink1).FirstOrDefault();
                        NoeudUnique.EstUnefEuilleSansEnfant = false;
                        NoeudUnique.noeudEnfant.Add(toAdd);
                    }
                }
            }

            foreach (Noeud NoeudUnique in NodeList)
            {
                Console.Error.WriteLine("noeud" + NoeudUnique.Valeur);
                Console.Error.WriteLine("EstUnefEuilleSansEnfant" + NoeudUnique.EstUnefEuilleSansEnfant);
                foreach (var item in NoeudUnique.noeudEnfant)
                {
                    Console.Error.WriteLine("noeud enfant" + item.Valeur);
                    Console.Error.WriteLine("EstUnefEuilleSansEnfant" + item.EstUnefEuilleSansEnfant);
                }
            }
            int result = 0;
            foreach (Noeud NoeudUnique in NodeList)
            {
                NoeudUnique.Visite = true;
                result = Getheight(NoeudUnique);
            }
            //List de noeud compléte
            Console.WriteLine(result);
        }

        private int depthOfTree(private struct Node *ptr)

{
    // Base case
    if (!ptr)
        return 0;

    // Check for all children and find
    // the maximum depth
    private int maxdepth = 0;

    for (vector<Node*>::iterator it = ptr->child.begin();
                              it != ptr->child.end(); it++)

        maxdepth = privatemax(maxdepth, depthOfTree(* it));

    return maxdepth + 1 ;
}

    private static int Getheight(Noeud NoeudUnique)
    {
        int result = 0;
        //List<Noeud> NodeChildTemp = new List<Noeud>();
        //pour chause noeud enfant non visité
        foreach (Noeud noeudEnfantUnique in NoeudUnique.noeudEnfant.Where(x => x.Visite == false))
        {
            result = Math.Max(result, Getheight(noeudEnfantUnique));
            //if (noeudEnfantUnique.noeudEnfant.Count > 0)
            //{
            //    result = result + 1;
            //}
            //NodeChildTemp.Add(noeudEnfantUnique);
        }

        return result + 1;
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
        public int Valeur { get; set; }
        public bool Visite { get; set; }
        public List<Noeud> noeudEnfant { get; set; }
        public bool EstUnefEuilleSansEnfant { get; set; }
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
                DFS(listLien, listNode, ref comptNbrPassage, ref resultTemp, NoeudEnCoursDeVisit);
            }
        }
        if (comptNbrPassage < resultTemp)
        {
            resultTemp = comptNbrPassage;
        }
    }
}
}