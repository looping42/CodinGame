using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Phase_D_initialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // nombre de celulle sur l'axe x
            int height = int.Parse(Console.ReadLine()); // nombre de celulle sur l'axe y
            Console.Error.WriteLine("width" + width);
            Console.Error.WriteLine("height" + height);

            //Tableau contenant les noeuds
            noeud[,] array = new noeud[height, width];
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine(); // lignes contenant des noeuds            
                for (int j = 0; j < width; j++)
                {
                    noeud temp2 = new noeud();
                    temp2.Valeur = line[j];
                    Console.Error.Write(line[j]);
                    temp2.axeheight = i;
                    temp2.axewidth = j;
                    array[i, j] = temp2;
                }
                Console.Error.WriteLine();
            }
            SearchNodeVoisins(array);
            VisuVoisinNode(array);

            //Console.WriteLine("0 0 1 0 0 1"); // Three coordinates: a node, its right neighbor, its bottom neighbor
        }
        public class noeud
        {
            public char Valeur;
            public int axeheight;
            public int axewidth;
            public List<noeud> voisins;
        }

        public static void VisuVoisinNode(noeud[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].Valeur != '.')
                    {
                        //Si on est sur un Noeud qui est 0
                        //if (array[i, j].Valeur != '.')
                        // {
                        Console.Error.WriteLine("array[i, j].axeheight " + array[i, j].axeheight);
                        Console.Error.WriteLine("array[i, j].axewidth " + array[i, j].axewidth);
                        Console.Error.WriteLine("array[i, j].voisins.Count : " + array[i, j].voisins.Count);

                        //Pour chaque noeud dans le tableau ,Si pas de voisins pour ce noeud 
                        if (array[i, j].voisins.Count == 0)
                        {
                            Console.WriteLine(j + " " + i + " -1 -1 -1 -1"); //Pas de voisins
                        }
                        else if (array[i, j].voisins.Count == 1) // si il a 1 voisin 
                        {
                            Console.Error.WriteLine(array[i, j].voisins[0].axewidth);

                            if ((j + 1 < array.GetLength(1)) && (array[i, j].voisins[0].axewidth == array[i, j + 1].axewidth))
                            {
                                Console.Error.WriteLine(array[i, j + 1].axewidth);
                                Console.Error.WriteLine("passage 1");
                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " -1 -1"); //Voisins a droite
                            }
                            else if ((i + 1 < array.GetLength(0)) && (array[i, j].voisins[0].axewidth == array[i+1, j ].axewidth))
                            {
                                Console.Error.WriteLine("passage 2");
                                Console.WriteLine(j + " " + i + " -1 -1 " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight); //Voisins en bas 
                            }

                            else if ((j + 2 < array.GetLength(1)) && (array[i, j].voisins[0].axewidth == array[i, j + 2].axewidth))
                            {
                                Console.Error.WriteLine("passage 3");
                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " -1 -1"); //Voisins a 2 touche d'ecart 
                            }
                            else if ((i + 2 < array.GetLength(0)) && (array[i, j].voisins[0].axewidth == array[i + 2, j].axewidth))
                            {
                                Console.Error.WriteLine("passage4");
                                Console.WriteLine(j + " " + i + "-1 -1 " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight); //Voisins a 2 touche d'ecart 
                            }

                        }
                        else //Si 2 voisins 
                        {
                            string result="";
                            //si les 2 voisins sont à coté
                            if (array[i, j].voisins[0].axewidth == array[i, j + 1].axewidth)
                            {
                                Console.Error.WriteLine("passage 5");
                                result += j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight +" ";

                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " " + array[i, j].voisins[1].axewidth + " " + array[i, j].voisins[1].axeheight); //Voisins a droite
                            }
                            else if (array[i, j].voisins[0].axewidth == array[i+1 , j].axewidth)
                            {
                                Console.Error.WriteLine("passage 9");
                                result += array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " ";
                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[1].axewidth + " " + array[i, j].voisins[1].axeheight + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight); //Voisins en bas 
                            }
                            else if (array[i, j].voisins[0].axeheight == array[i+1, j].axeheight)
                            {
                                Console.Error.WriteLine("passage 6");
                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " " + array[i, j].voisins[1].axewidth + " " + array[i, j].voisins[1].axeheight); //Voisins a droite
                            }
                            else if ((j + 2 < array.GetLength(0)) && (array[i, j].voisins[0].axewidth == array[i, j + 2].axewidth))
                            {
                                Console.Error.WriteLine("passage7");
                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " " + array[i, j].voisins[1].axewidth + " " + array[i, j].voisins[1].axeheight); //Voisins a 2 touche d'ecart 
                            }
                            else if ((i + 2 < array.GetLength(0)) && (array[i, j].voisins[0].axewidth == array[i + 2, j ].axewidth))
                            {
                                Console.Error.WriteLine("passage8");
                                Console.WriteLine(j + " " + i + " " + array[i, j].voisins[0].axewidth + " " + array[i, j].voisins[0].axeheight + " " + array[i, j].voisins[1].axewidth + " " + array[i, j].voisins[1].axeheight); //Voisins a 2 touche d'ecart 
                            }
                        }
                    }
                    //}
                }
            }
        }
        /// <summary>
        /// Recherche les noeuds voisins 
        /// </summary>
        /// <param name="array"></param>
        public static void SearchNodeVoisins(noeud[,] array)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    bool NothingNearWidth = true;
                    bool NothingNearHeight = true;
                    array[i, j].voisins = new List<noeud>();
                    if ((j + 1 < array.GetLength(1)) && (array[i, j + 1].Valeur == '0'))
                    {
                        array[i, j].voisins.Add(array[i, j + 1]);
                        NothingNearWidth = false;
                    }

                    if ((i + 1 < array.GetLength(0)) && (array[i + 1, j].Valeur == '0'))
                    {
                        array[i, j].voisins.Add(array[i + 1, j]);
                        NothingNearHeight = false;
                    }

                    //si les 2 noeuds proche sont vide 
                    if (NothingNearWidth == true)
                    {
                        if ((j + 2 < array.GetLength(1)) && (array[i, j + 2].Valeur == '0'))
                        {
                            array[i, j].voisins.Add(array[i, j + 2]);
                        }
                    }

                    if (NothingNearHeight == true)
                    {
                        if ((i + 2 < array.GetLength(0)) && (array[i + 2, j].Valeur == '0'))
                        {
                            array[i, j].voisins.Add(array[i + 2, j]);
                        }
                    }
                }
            }
        }
    }
}

