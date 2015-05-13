using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calcul_maya
{
    class Program
    {
        static void Main(string[] args)
        {
            string hauteurlargeur = Console.ReadLine();
            int hauteur = Convert.ToInt32(hauteurlargeur.Split(' ')[0]);
            int largeur = Convert.ToInt32(hauteurlargeur.Split(' ')[1]);
            Console.Error.WriteLine(hauteur);
            Console.Error.WriteLine(largeur);
            char[,] representationMaya = new char[hauteur, (largeur * 20)];

            //ligne representation tout les chiffres maya
            for (int i = 0; i < hauteur; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                Console.Error.WriteLine(line);
                for (int j = 0; j < largeur * 20; j++)
                {
                    representationMaya[i, j] = line[j];
                }
            }

            List<char[,]> tabgeneralPremierChiffre = new List<char[,]>();
            //nombre ligne pour le premier nombres
            int nbrlignePremierNombre = Convert.ToInt32(Console.ReadLine());
            Console.Error.WriteLine(nbrlignePremierNombre);
            //Premier chiffre


            int EachHeight = 0;
            //pour le nombre de chiffre total contenu sur la premiére lignes
            for (int k = 0; k < nbrlignePremierNombre / hauteur; k++)
            {
                char[,] representationPremierChiffre = new char[hauteur, largeur];
                int m = 0;
                for (int i = EachHeight; i < (hauteur + EachHeight); i++)
                {
                    char[] line2 = Console.ReadLine().ToCharArray();
                    Console.Error.WriteLine(line2);
                    for (int j = 0; j < largeur; j++)
                    {
                        representationPremierChiffre[m, j] = line2[j];

                    }
                    m = m + 1;
                }
                EachHeight += hauteur;
                tabgeneralPremierChiffre.Add(representationPremierChiffre);
            }

            List<char[,]> tabGeneralSecondChiffre = new List<char[,]>();

            //nombre ligne pour le deuxieme nombres
            int nbrlignedeuxiemeNombre = Convert.ToInt32(Console.ReadLine());
            //Deuxiemes chiffre           

            EachHeight = 0;
            for (int k = 0; k < nbrlignedeuxiemeNombre / hauteur; k++)
            {
                char[,] representationDeuxiemeChiffre = new char[hauteur, largeur];
                int m = 0;
                for (int i = EachHeight; i < hauteur + EachHeight; i++)
                {
                    char[] line3 = Console.ReadLine().ToCharArray();

                    Console.Error.WriteLine(line3);
                    for (int j = 0; j < largeur; j++)
                    {
                        representationDeuxiemeChiffre[i, j] = line3[j];
                    }
                    m = m + 1;
                }
                EachHeight += hauteur;
                tabGeneralSecondChiffre.Add(representationDeuxiemeChiffre);
            }

            char operateur = char.Parse(Console.ReadLine());

            //To do pour premier nombre compris dans ce tableau on regarde dans le tableau
            //comprenant tout les nombre en parcourant 4 a 4 et en comparant les 4 prochains
            //si on trouve on sauve le numéro (concernant le nombre dans ce tableau )
            //meme chose second nombre ,ensuite on compte pour obtenir le resultat 
            int[] saveNumberUn = new int[tabgeneralPremierChiffre.Count];
            int o = 0;
            foreach (var item in tabgeneralPremierChiffre)
            {

                for (int p = 0; p < representationMaya.GetLongLength(1); p = p + largeur)
                {
                    bool valideNumeroUn = true;
                    int u = 0;
                    for (int i = 0; i < representationMaya.GetLongLength(0); i++)
                    {
                        int k = 0;
                        for (int j = p; j < (p + largeur); j++)
                        {

                            if ((j < representationMaya.GetLongLength(1)) && (representationMaya[i, j] != item[u, k]))
                            {
                                valideNumeroUn = false;
                            }
                            k = k + 1;
                        }
                        u = u + 1;
                    }
                    if (valideNumeroUn == true)
                    {
                        saveNumberUn[o] = p / largeur;
                        o = o + 1;
                    }
                }
            }
            Console.Error.WriteLine("save" + saveNumberUn[0]);
            //Console.Error.WriteLine("save"+saveNumberUn[1]);


            int[] saveNumberDeux = new int[tabGeneralSecondChiffre.Count];
            o = 0;
            foreach (var item in tabGeneralSecondChiffre)
            {

                for (int p = 0; p < representationMaya.GetLongLength(1); p = p + largeur)
                {
                    bool ValideNumerodeux = true;
                    int u = 0;
                    for (int i = 0; i < representationMaya.GetLongLength(0); i++)
                    {
                        int k = 0;
                        for (int j = p; j < (p + largeur); j++)
                        {

                            if ((j < representationMaya.GetLongLength(1)) && (representationMaya[i, j] != item[u, k]))
                            {
                                ValideNumerodeux = false;
                            }
                            k = k + 1;
                        }
                        u = u + 1;
                    }
                    if (ValideNumerodeux == true)
                    {
                        saveNumberDeux[o] = p / largeur;
                        o = o + 1;
                    }
                }
            }
            //Console.Error.WriteLine(saveNumberDeux[0]);

            //Console.Error.WriteLine(saveNumberUn.Length);
            int resultnumberUn = 0;
            if (saveNumberUn.Length > 0)
            {
                //Console.Error.WriteLine(saveNumberUn[0]);
                //debut au dernier élement
                int l = 0;
                for (int j = saveNumberUn.Length - 1; j >= 0; j--)
                {
                    //Console.Error.WriteLine(saveNumberUn[0]);
                    if (j != 0)
                    {
                        Console.Error.WriteLine("saveNumberUn[j] :" + saveNumberUn[l]);
                        resultnumberUn += (saveNumberUn[l] * 20) * (j * 20);
                        Console.Error.WriteLine("resultnumberUn" + resultnumberUn);
                        l = l + 1;
                    }
                    else
                    {
                        resultnumberUn += saveNumberUn[l];
                        l = l + 1;
                        //Console.Error.WriteLine(resultnumberUn);
                    }
                }
            }
            else
            {
                resultnumberUn = saveNumberUn[0];
            }

            //Console.Error.WriteLine(resultnumberUn);
            int resultNumberdeux = 0;
            if (saveNumberDeux.Length > 0)
            {
                int l = 0;
                for (int j = (saveNumberDeux.Length - 1); j >= 0; j--)
                {

                    if (j != 0)
                    {
                        resultNumberdeux += (saveNumberDeux[l] * 20) * (j * 20);
                        l = l + 1;
                    }
                    else
                    {
                        resultNumberdeux += saveNumberDeux[l];
                        l = l + 1;
                    }
                }
            }
            else
            {
                resultNumberdeux = saveNumberDeux[0];
            }
            //Console.Error.WriteLine(resultNumberdeux);
            //ensuite creation du resultat 
            //si 0 on affiche le premier nombre 
            //sinon si on affiche un seul nombre 
            //si plus de 20 ca sera sur plusieurs lignes 
            //on divise par 20 jusqua obtenir un nombre en dessous des 20 (on compte le nombre de divison qui permet dtobtenir le nombre detage de maya)
            //on recalcule a chaque nombre ajouter
            int Resultat = 0;
            if (operateur == '+')
            {
                Resultat = resultnumberUn + resultNumberdeux;
            }
            else if (operateur == '-')
            {
                Resultat = resultnumberUn - resultNumberdeux;
            }
            else if (operateur == '*')
            {
                Resultat = resultnumberUn * resultNumberdeux;
            }
            else
            {
                Resultat = resultnumberUn / resultNumberdeux;
            }

            Console.Error.WriteLine(Resultat);

            if (Resultat == 0)
            {
                for (int i = 0; i < representationMaya.GetLongLength(0); i++)
                {
                    for (int j = (largeur * Resultat); j < representationMaya.GetLongLength(1) && j < (largeur * Resultat) + 4; j++)
                    {
                        Console.Write(representationMaya[i, j]);
                    }
                    Console.WriteLine();
                }

            }
            else if (Resultat < 20)
            {

                for (int i = 0; i < representationMaya.GetLongLength(0); i++)
                {
                    for (int j = (largeur * Resultat); j < representationMaya.GetLongLength(1) && j < (largeur * Resultat) + 4; j++)
                    {
                        Console.Write(representationMaya[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                int resultTemp = Resultat;
                while (resultTemp != 0)
                {
                    //Console.Error.WriteLine(resultTemp);
                    int puissance = 0;
                    while (resultTemp > 19)
                    {
                        resultTemp = resultTemp / 20;

                        puissance = puissance + 1;
                    }
                    if (puissance != 0)
                    {
                        //nombre temporaire qui va permettre de retirer au resultat les nombres petit a petit 
                        int Nbrtemp = (resultTemp * 20) * puissance;
                        //Console.Error.WriteLine(resultTemp);
                        Resultat = Resultat - Nbrtemp;
                        //resultTemp =Resultat;
                    }
                    else
                    {
                        resultTemp = Resultat;
                    }
                    //Console.Error.WriteLine(resultTemp);
                    //affichage chiffre
                    for (int i = 0; i < representationMaya.GetLongLength(0); i++)
                    {
                        for (int j = (largeur * resultTemp); j < representationMaya.GetLongLength(1) && j < (largeur * resultTemp) + 4; j++)
                        {

                            Console.Write(representationMaya[i, j]);
                        }
                        Console.WriteLine();
                    }
                    if (puissance == 0)
                    {
                        resultTemp = 0;
                    }
                }

                //Console.WriteLine("result");
            }

        }
    }
}