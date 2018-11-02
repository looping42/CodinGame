using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WondevWoman.Program;

namespace WondevWoman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputs;
            int size = int.Parse(Console.ReadLine());
            int unitNbr = int.Parse(Console.ReadLine());

            // game loop
            while (true)
            {
                Console.Error.WriteLine("NEW TURN");
                //tableau
                char[,] arrayTab = new char[size, size];
                for (int i = 0; i < size; i++)
                {
                    string row = Console.ReadLine();
                    char[] line = row.ToArray();
                    for (int j = 0; j < line.Length; j++)
                    {
                        arrayTab[i, j] = line[j];
                    }
                }
                tableau tab = new tableau(arrayTab);
                //tab.Displaytab();

                //mes unités
                List<unitsPerPlayer> unitsPerPlayersMine = new List<unitsPerPlayer>();
                for (int i = 0; i < unitNbr; i++)
                {
                    unitsPerPlayer unitsperslayerMine = new unitsPerPlayer();
                    inputs = Console.ReadLine().Split(' ');
                    unitsperslayerMine.MyUnitX = int.Parse(inputs[0]);
                    unitsperslayerMine.MyUnitY = int.Parse(inputs[1]);
                    unitsperslayerMine.NumeroUnits = i;
                    unitsPerPlayersMine.Add(unitsperslayerMine);
                }

                List<unitsPerPlayer> unitsPerPlayersOther = new List<unitsPerPlayer>();
                for (int i = 0; i < unitNbr; i++)
                {
                    unitsPerPlayer unitsperslayerOther = new unitsPerPlayer();
                    inputs = Console.ReadLine().Split(' ');
                    unitsperslayerOther.MyUnitX = int.Parse(inputs[0]);
                    unitsperslayerOther.MyUnitY = int.Parse(inputs[1]);
                    unitsperslayerOther.NumeroUnits = i;
                    unitsPerPlayersOther.Add(unitsperslayerOther);
                }

                //Console.Error.WriteLine("nbrdemesunits" + unitsPerPlayersMine.Count());
                //for (int i = 0; i < unitsPerPlayersMine.Count(); i++)
                //{
                //    Console.Error.WriteLine(unitsPerPlayersMine[i].MyUnitX + " : " + unitsPerPlayersMine[i].MyUnitY);
                //}
                //foreach (var item in unitsPerPlayersOther)
                //{
                //    Console.Error.WriteLine(item.MyUnitX + " : " + item.MyUnitY);
                //}

                int legalActions = int.Parse(Console.ReadLine());
                List<legalAction> legalsAction = new List<legalAction>();
                for (int i = 0; i < legalActions; i++)
                {
                    legalAction laction = new legalAction();
                    inputs = Console.ReadLine().Split(' ');
                    laction.atype = inputs[0];
                    laction.index = int.Parse(inputs[1]);
                    laction.dir1 = inputs[2];
                    laction.dir2 = inputs[3];
                    legalsAction.Add(laction);
                }

                foreach (var item in legalsAction)
                {
                    Console.Error.Write(item.atype + " " + item.index + " " + item.dir1 + " " + item.dir2);
                    Console.Error.WriteLine();
                }

                ActionToDo actionTodo = new ActionToDo(legalsAction, tab, unitsPerPlayersMine, unitsPerPlayersOther);
                List<legalAction> lactionToDo = actionTodo.GetNeightboorMAxhauteur();

                legalAction lastaction = lactionToDo.OrderByDescending(x => x.pointPos1).FirstOrDefault();
                //foreach (var item in lactionToDo)
                //{
                //    Console.Error.WriteLine("moveSTACKER");
                //    Console.Error.WriteLine(item.atype + " " + item.index + " " + item.dir1 + " " + item.dir2);
                //}
                if (lastaction != null)
                {
                    Console.WriteLine(lastaction.atype + " " + lastaction.index + " " + lastaction.dir1 + " " + lastaction.dir2);
                }
                else
                {
                    Console.WriteLine(legalsAction[0].atype + " " + legalsAction[0].index + " " + legalsAction[0].dir1 + " " + legalsAction[0].dir2);
                }
            }
        }
    }

    public class unitsPerPlayer
    {
        public int MyUnitX { get; set; }
        public int MyUnitY { get; set; }
        public int NumeroUnits { get; set; }
        public int units { get; set; }

        public unitsPerPlayer(int v)
        {
            this.units = v;
        }

        public unitsPerPlayer()
        {
        }
    }

    public class tableau
    {
        public char[,] arrayTab { get; set; }

        public tableau(char[,] arrayTab)
        {
            this.arrayTab = arrayTab;
        }

        public void Displaytab()
        {
            for (int i = 0; i < arrayTab.GetLength(0); i++)
            {
                for (int j = 0; j < arrayTab.GetLength(1); j++)
                {
                    Console.Error.Write(arrayTab[i, j]);
                }
                Console.Error.WriteLine();
            }
        }
    }

    public class legalAction
    {
        public int legalActionsNbr { get; set; }
        public int index { get; set; }
        public string atype { get; set; }
        public string dir1 { get; set; }
        public string dir2 { get; set; }
        public int pointPos1 { get; set; }
        public int pointPos2 { get; set; }

        public legalAction(int legalActions)
        {
            this.legalActionsNbr = legalActions;
        }

        public legalAction()
        {
        }
    }

    public class ActionToDo
    {
        public enum Direction
        { N, NE, NW, E, W, S, SW, SE };

        private enum valCell
        { zero, one, two, three, four }

        private List<legalAction> legalsAction;
        private tableau tab;
        private List<unitsPerPlayer> unitsPerPlayersMine;
        private List<unitsPerPlayer> unitsPerPlayersOther;

        public ActionToDo(List<legalAction> legalsAction, tableau tableau, List<unitsPerPlayer> unitsPerPlayersMine, List<unitsPerPlayer> unitsPerPlayersOther)
        {
            this.legalsAction = legalsAction;
            this.tab = tableau;
            this.unitsPerPlayersMine = unitsPerPlayersMine;
            this.unitsPerPlayersOther = unitsPerPlayersOther;
        }

        public List<legalAction> GetNeightboorMAxhauteur()
        {
            int oldvalpostion = 0;
            List<legalAction> legalactiontoSave = new List<legalAction>();

            //parcours chaque positions possible
            foreach (legalAction oneAction in legalsAction)
            {
                Console.Error.WriteLine(oneAction.atype + " " + oneAction.index + " " + oneAction.dir1 + " " + oneAction.dir2);
                unitsPerPlayer unitsplacement = unitsPerPlayersMine.Where(z => z.NumeroUnits == oneAction.index).First();
                int x = unitsplacement.MyUnitX;
                int y = unitsplacement.MyUnitY;
                Console.Error.WriteLine("before x :" + x + " beforey : " + y);
                char valActuelCase = tab.arrayTab[y, x];
                Direction dir = (Direction)Enum.Parse(typeof(Direction), oneAction.dir1, true);
                //futur position apres le move
                TransformDirectionIntoPosition(dir, ref x, ref y);
                Console.Error.WriteLine("x :" + x + " y : " + y);
                //point de la positions gagnés et positions sauvegardés
                //int ValPosition = SearchMaxNeightboorValue(x, y);
                int ValPosition = SearchMaxNeightboorValueV2(valActuelCase, x, y);
                oneAction.pointPos1 = ValPosition;
                Console.Error.WriteLine("ValPosition1 :" + ValPosition);
                //position 2 build
                Direction dir2 = (Direction)Enum.Parse(typeof(Direction), oneAction.dir2, true);
                TransformDirectionIntoPosition(dir2, ref x, ref y);
                //ValPosition += SearchMaxNeightboorValue(x, y);
                char ValActuelNewCase = tab.arrayTab[y, x];
                ValPosition += SearchMaxNeightboorValueV2(ValActuelNewCase, x, y);
                oneAction.pointPos2 = ValPosition;
                Console.Error.WriteLine("ValPosition2 :" + ValPosition);
                if (ValPosition > oldvalpostion)
                {
                    Console.Error.WriteLine("valpositiontosave :" + ValPosition);
                    Console.Error.WriteLine("oldvalpostiontosave :" + oldvalpostion);
                    oldvalpostion = ValPosition;
                    legalactiontoSave.Add(oneAction);
                }
            }
            return legalactiontoSave;
        }

        private void TransformDirectionIntoPosition(Direction dir, ref int x, ref int y)
        {
            switch (dir)
            {
                case (Direction.N):
                    y = y - 1;
                    break;

                case (Direction.S):
                    y = y + 1;
                    break;

                case (Direction.E):
                    x = x + 1;
                    break;

                case (Direction.W):
                    x = x - 1;
                    break;

                case (Direction.NE):
                    x = x + 1;
                    y = y - 1;
                    break;

                case (Direction.NW):
                    x = x - 1;
                    y = y - 1;
                    break;

                case (Direction.SE):
                    x = x + 1;
                    y = y + 1;
                    break;

                case (Direction.SW):
                    x = x - 1;
                    y = y + 1;
                    break;

                default:
                    break;
            }
        }

        private int SearchMaxNeightboorValue(int x, int y)
        {
            //for (int i = 0; i < tab.arrayTab.GetLongLength(0); i++)
            //{
            //    for (int j = 0; j < tab.arrayTab.GetLongLength(1); j++)
            //    {
            //Console.Error.WriteLine("valcell" + (int)value);

            Console.Error.WriteLine("tab.arrayTab[x, y]" + tab.arrayTab[y, x]);
            tab.Displaytab();
            if (tab.arrayTab[y, x] == '3')
            {
                return 3;
            }
            else if (tab.arrayTab[y, x] == '2')
            {
                return 2;
            }
            else if (tab.arrayTab[y, x] == '1')
            {
                return 1;
            }
            else
            {
                Console.Error.WriteLine("outValueNOnValide");
                return 0;
            }

            //    }
            //}
        }

        private int SearchMaxNeightboorValueV2(char NbrActuelThiscase, int x, int y)
        {
            Console.Error.WriteLine("tab.arrayTab[x, y]" + tab.arrayTab[y, x]);
            tab.Displaytab();

            if (NbrActuelThiscase == '3')
            {
                if (tab.arrayTab[y, x] == '3')
                {
                    return 3;
                }
            }
            else if (NbrActuelThiscase == '2')
            {
                if (tab.arrayTab[y, x] == '3')
                {
                    return 3;
                }
                else if (tab.arrayTab[y, x] == '2')
                {
                    return 2;
                }
            }
            else if (NbrActuelThiscase == '1')
            {
                if (tab.arrayTab[y, x] == '2')
                {
                    return 2;
                }
            }
            else
            {
                if (tab.arrayTab[y, x] == '1')
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}