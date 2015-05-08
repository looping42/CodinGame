using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThorTailleDuCode
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] sep = new char[] { ' ' };            
            string line = Console.ReadLine();
            string[] split = line.Split(sep);
            int positionxeclair = Convert.ToInt32(split[0]);
            int positionyeclair = Convert.ToInt32(split[1]);
            int positionxthor = Convert.ToInt32(split[2]);
            int positionythor = Convert.ToInt32(split[3]);

            while (true)
            {

                int nbrtour = Convert.ToInt32(Console.ReadLine());

                if ((positionxthor < positionxeclair) && (positionythor > positionyeclair))
                {
                    Console.WriteLine("NE");
                    positionxthor = positionxthor + 1;
                    positionythor = positionythor - 1;
                }
                else if ((positionxthor > positionxeclair) && (positionythor > positionyeclair))
                {
                    Console.WriteLine("NW");
                    positionxthor = positionxthor - 1;
                    positionythor = positionythor - 1;
                }
                else if ((positionxthor < positionxeclair) && (positionythor == positionyeclair))
                {
                    Console.WriteLine("E");
                    positionxthor = positionxthor + 1;
                }
                else if ((positionxthor > positionxeclair) && (positionythor == positionyeclair))
                {
                    Console.WriteLine("W");
                    positionxthor = positionxthor - 1;
                }
                else if ((positionxthor == positionxeclair) && (positionythor > positionyeclair))
                {
                    Console.WriteLine("N");
                    positionythor = positionythor - 1;
                }
                else if ((positionxthor == positionxeclair) && (positionythor < positionyeclair))
                {
                    Console.WriteLine("S");
                    positionythor = positionythor + 1;
                }
                else if ((positionxthor > positionxeclair) && (positionythor < positionyeclair) && (positionythor < 18))
                {
                    Console.WriteLine("SW");
                    positionxthor = positionxthor - 1;
                    positionythor = positionythor + 1;
                    Console.Error.WriteLine(positionythor);
                }
                else if ((positionxthor < positionxeclair) && (positionythor < positionyeclair))
                {
                    Console.WriteLine("SE");
                    positionxthor = positionxthor + 1;
                    positionythor = positionythor + 1;
                }

            }
        }
    }
}
