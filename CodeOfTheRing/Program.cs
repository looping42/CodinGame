using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOfTheRing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alphabet avec l'espace en plus
            List<char> alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

            List<char> magicPhrase = Console.ReadLine().ToList();
            Console.Error.WriteLine(magicPhrase.ToString());

            //Bilbon position au début == 0
            int positionBilbon = 0;

            //Pour chaque lettre de la phrase magique, on sauvegarde son index et la lettre corespondantes
            List<Tuple<int, char>> indexEachLettermagicWord = new List<Tuple<int, char>>();
            SaveMagicPhraseWithIndex(alphabet, magicPhrase, indexEachLettermagicWord);


            //Position de départ : index et index lettre, premiére valeur connu
            Dictionary<int, int> forestLetter = new Dictionary<int, int>();
            forestLetter.Add(0, 0);

            char? leftOrRightLetter;
            char? leftOrRightPosition;
            int savenbrMoveToGoLetter; int savenbrMoveToTurnLetter;
            StringBuilder outTexte = new StringBuilder();
            //Pour chaque index et lettre du mot magique 
            foreach (var item in indexEachLettermagicWord)
            {
                leftOrRightPosition = null;
                leftOrRightLetter = null;
                ResearchShortPathToLetter(forestLetter, item.Item1, item.Item2, positionBilbon, out leftOrRightLetter, out leftOrRightPosition,
                    out savenbrMoveToGoLetter, out savenbrMoveToTurnLetter);

                MoveBilbon(positionBilbon, leftOrRightLetter, leftOrRightPosition
           , savenbrMoveToGoLetter, savenbrMoveToTurnLetter, ref outTexte);

                SavePositionLetterForest('.', positionBilbon, item.Item1, forestLetter);
                positionBilbon = SavePosition('.', positionBilbon);
            }
            Console.WriteLine(outTexte);

            //si une lettre existe déja , et que c'est le chemin le plus court 

            //Comptabilisation du nombre de move 


            //Sauvegarde du positionnement et de la valeur des lettres dans le tableau

            //Console.WriteLine("+.>-.");
        }


        public static void MoveBilbon(int positionBilbon, char? leftOrRightLetter, char? leftOrRightPosition
            , int savenbrMoveToGoLetter, int savenbrMoveToTurnLetter, ref StringBuilder outTexte)
        {
            bool validLetter = false;
            while (validLetter == false)
            {
                //si on est sur la bonne position 
                if (leftOrRightPosition == null)
                {

                }
                else if (leftOrRightPosition == 'L')
                {
                    MoveLeftOrRight(ref savenbrMoveToGoLetter, '<', ref  outTexte);
                    positionBilbon = positionBilbon  - 1;
                }
                else
                {
                    MoveLeftOrRight(ref savenbrMoveToGoLetter, '>', ref  outTexte);
                    positionBilbon = positionBilbon + 1;
                }
                //si la lettre demandé est la bonne
                if (leftOrRightLetter == null)
                {
                    outTexte.Append(".");
                    validLetter = true;
                }
                else if (leftOrRightLetter == 'L')
                {
                    MoveLeftOrRight(ref savenbrMoveToTurnLetter, '-', ref outTexte);
                    leftOrRightLetter = null;
                    
                }
                else
                {
                    MoveLeftOrRight(ref savenbrMoveToTurnLetter, '+', ref  outTexte);
                    leftOrRightLetter = null;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="move"></param>
        /// <param name="sign"></param>
        /// <param name="outTexte"></param>
        private static void MoveLeftOrRight(ref int move, char sign, ref StringBuilder outTexte)
        {
            while (move != 0)
            {
                outTexte.Append(sign);
                move = move - 1;
            }
        }

        /// <summary>
        /// Compatbilisation du nombre de coup pour aller a une lettre 
        /// </summary>
        /// <param name="forestLetter"></param>
        /// <param name="indexMagicWord"></param>
        /// <param name="letterMagicWord"></param>
        /// <param name="positionBilbon"></param>
        private static void ResearchShortPathToLetter(Dictionary<int, int> forestLetter, int indexMagicWord, char letterMagicWord, int positionBilbon,
            out char? leftOrRightLetter, out char? leftOrRightPosition, out int savenbrMoveToGoLetter, out int savenbrMoveToTurnLetter)
        {
            int nbrMoveToGoLetter = 0; ;
            int nbrMoveToTurnLetter;
            savenbrMoveToTurnLetter = 0;
            savenbrMoveToGoLetter = 0;
            int totalMoveToGo = 500;
            leftOrRightLetter = null;
            leftOrRightPosition = null;
            //on vérifie que dans la forêt pour chaque lettre et index 
            foreach (var indexLetter in forestLetter)
            {
                if (forestLetter.Count() > 1)
                {
                    nbrMoveToGoLetter = ChoicePositionningBilbon(positionBilbon, indexMagicWord, ref leftOrRightPosition, indexLetter.Key, indexLetter.Value);
                }
                else
                {

                }
                //Deplacement des lettres sur les pierres
                nbrMoveToTurnLetter = 0;
                //si on a la bonne lettre juste au dessus 
                if (indexLetter.Value == indexMagicWord)
                {
                    leftOrRightLetter = null;
                }
                //si l'index de la lettre de la foret est supérieur a l'index de la lettre du mot magique
                else if (indexLetter.Value >= indexMagicWord)
                {
                    //si le chemin passant par la lettre Z est meilleur
                    int temp = (26 - indexLetter.Value + indexMagicWord - indexLetter.Value);
                    int temp2 = indexLetter.Value - indexMagicWord;

                    if (temp < temp2)
                    {
                        nbrMoveToTurnLetter += temp;
                        leftOrRightLetter = 'R';
                    }
                    else
                    {
                        nbrMoveToTurnLetter += temp2;
                        leftOrRightLetter = 'L';
                    }
                }
                else//si l'index de la lettre de la foret est inférieur à l'index de la lettre du mot magique
                {
                    int temp3 = indexLetter.Value + indexMagicWord ;
                    int temp4 = indexMagicWord - indexLetter.Value;
                    if ((temp3 >0 ) && (temp3 <= temp4))
                    {
                        nbrMoveToTurnLetter += temp3;
                        leftOrRightLetter = 'R';
                    }
                    else
                    {
                        nbrMoveToTurnLetter += temp4;
                        leftOrRightLetter = 'L';
                    }
                }
                if ((nbrMoveToGoLetter + nbrMoveToTurnLetter) < totalMoveToGo)
                {
                    totalMoveToGo = (nbrMoveToGoLetter + nbrMoveToTurnLetter);
                    savenbrMoveToGoLetter = nbrMoveToGoLetter;
                    savenbrMoveToTurnLetter = nbrMoveToTurnLetter;

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionBilbon"></param>
        /// <param name="leftOrRightPosition"></param>
        /// <param name="indexLetter"></param>
        /// <returns></returns>
        private static int ChoicePositionningBilbon(int positionBilbon, int indexMagicWord, ref char? leftOrRightPosition, int indexLetter,int indexValue)
        {

            int nbrMoveToGoLetter;
            //Déplacement au sein de la forêt
            nbrMoveToGoLetter = 0;

            if (positionBilbon == indexLetter)
            {
                leftOrRightPosition = null;
            }
            //si bilbon est placé aprés la position que l'on survole dans la boucle
            else if (positionBilbon >= indexLetter)
            {
                nbrMoveToGoLetter = positionBilbon - indexLetter;
                leftOrRightPosition = 'L';
            }
            else
            {
                nbrMoveToGoLetter = indexLetter - positionBilbon;
                leftOrRightPosition = 'R';
            }
            return nbrMoveToGoLetter;
        }

        /// <summary>
        /// Ajout des lettres et index a la list qui va nous servir pour le mot magique
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="magicPhrase"></param>
        /// <param name="indexEachLettermagicWord"></param>
        private static void SaveMagicPhraseWithIndex(List<char> alphabet, List<char> magicPhrase, List<Tuple<int, char>> indexEachLettermagicWord)
        {
            foreach (var item in magicPhrase)
            {
                int indexLetter = alphabet.FindIndex(x => x.Equals(item));
                char letter = alphabet.Find(x => x.Equals(item));

                Console.Error.Write("indexLettre :" + indexLetter);
                Console.Error.Write("Lettre :" + letter);
                indexEachLettermagicWord.Add(Tuple.Create(indexLetter, letter));
            }
        }

        /// <summary>
        /// Sauvegarde du tableau comprenant la clé égal à la position dans le tableau et sa valeur l'index des lettres de l'alphabet
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="PositionBilbonActuel"></param>
        /// <param name="indexLetter"></param>
        /// <param name="forestLetter"></param>
        public static void SavePositionLetterForest(char sign, int PositionBilbonActuel, int indexLetter, Dictionary<int, int> forestLetter)
        {
            if (sign == '.')
            {
                if (forestLetter.Count() > PositionBilbonActuel)
                {
                    forestLetter[PositionBilbonActuel] = indexLetter;
                }
                else
                {
                    forestLetter.Add(PositionBilbonActuel, indexLetter);
                }
            }
        }

        /// <summary>
        /// sauvegarde et incrémente la nouvel position de bilbon
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="positonActuel"></param>
        /// <returns>sa nouvelle position</returns>
        public static int SavePosition(char sign, int positonActuel)
        {
            if (sign == '>')
            {
                return positonActuel + 1;
            }
            else if (sign == '<')
            {
                return positonActuel - 1;
            }
            else
            {
                return positonActuel;
            }
        }
    }
}
