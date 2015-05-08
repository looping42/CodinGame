using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_TailleduCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int nbFloors = int.Parse(inputs[0]); // nombre étages
            int width = int.Parse(inputs[1]); // largeur de la zone 
            int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
            int exitFloor = int.Parse(inputs[3]); // étage de l'aspirateur
            int exitPos = int.Parse(inputs[4]); // position aspirateur a son étage
            int nbTotalClones = int.Parse(inputs[5]); //  le nombre de clones qui sortiront du générateur au cours de la partie
            int nbAdditionalElevators = int.Parse(inputs[6]); // nombre d'ascenseur additionnel
            int nbElevators = int.Parse(inputs[7]); //le nombre d'ascenseurs présents sur la zone

            List<int> elevatorPos = new List<int>();
            List<int> elevatorFloor = new List<int>();

            for (int i = 0; i < nbElevators; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                elevatorFloor.Add(int.Parse(inputs[0])); // floor on which this elevator is found
                elevatorPos.Add(int.Parse(inputs[1])); // position of the elevator on its floor
                Console.Error.WriteLine("etage elevator   " + elevatorFloor[i]);
                Console.Error.WriteLine("etage pos   " + elevatorPos[i]);
            }


            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
                int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
                Console.Error.WriteLine("clone etage " + cloneFloor);
                Console.Error.WriteLine("clone pos " + clonePos);

                String direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
                Console.Error.WriteLine("direction " + direction);

                Console.Error.WriteLine("nombre etages " + nbFloors);
                Console.Error.WriteLine("largeur zone   " + width);
                Console.Error.WriteLine("nombre rounds   " + nbRounds);
                Console.Error.WriteLine("etage aspirateur   " + exitFloor);
                Console.Error.WriteLine("pos aspirateur   " + exitPos);
                Console.Error.WriteLine("nbTotalClones   " + nbTotalClones);
                Console.Error.WriteLine("nbElevators   " + nbElevators);
                Console.Error.WriteLine("nbAdditionalElevators   " + nbAdditionalElevators);

                int copieElevator = 0;
                int i = 0;

                while (i < elevatorFloor.Count())
                {
                    if (elevatorFloor[i] == cloneFloor)
                    {
                        copieElevator = elevatorPos[i];
                        Console.Error.WriteLine("copie elevelator " + copieElevator);
                    }
                    i = i + 1;
                }

                if ((clonePos == -1) || (elevatorPos.Count() > 0) && (copieElevator == clonePos))
                {
                    Console.WriteLine("WAIT");
                }
                //else if ((nbElevators == 0) && (nbAdditionalElevators > 0))
                //{
                //    Console.WriteLine("ELEVATOR");
                //    nbAdditionalElevators = nbAdditionalElevators - 1;
                //    elevatorFloor.Add(cloneFloor);
                //    elevatorPos.Add(clonePos);

                //    //Console.Error.WriteLine("elevator ajouter le dernier " + elevatorPos[elevatorPos.Count() - 1] );
                //}
                else if ((direction == "LEFT") && (clonePos == 0))
                {
                    Console.WriteLine("BLOCK");


                }
                else if (clonePos == (width - 1))
                {
                    Console.WriteLine("BLOCK");

                }
                else
                {

                    if ((cloneFloor == exitFloor) && (clonePos != copieElevator))
                    {
                        if ((clonePos > exitPos) && (direction == "RIGHT"))
                        {
                            Console.WriteLine("BLOCK");
                        }
                        else if ((clonePos < exitPos) && (direction == "LEFT"))
                        {
                            Console.WriteLine("BLOCK");
                        }
                        else
                        {
                            Console.WriteLine("WAIT");
                        }

                    }
                    else if (clonePos != copieElevator)
                    {
                        if ((clonePos > copieElevator) && (direction == "RIGHT"))
                        {
                            Console.WriteLine("BLOCK");
                        }
                        else if ((clonePos < copieElevator) && (direction == "LEFT"))
                        {
                            Console.WriteLine("BLOCK");
                        }
                        else
                        {
                            Console.WriteLine("WAIT");
                        }

                    }
                    else
                    {
                        Console.WriteLine("WAIT");

                    }
                }
            }
        }

    }
}
