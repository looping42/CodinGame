using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianMultiplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);

            int resmultiplication = a * b;
            StringBuilder res = new StringBuilder();
            if (a > b)
            {
                int temp;
                temp = b;
                b = a;
                a = temp;
            }
            //int btemp = b;

            res.Append(b + " * " + a);
            res.Append("\n");
            string btemp = "";
            bool inpairvalid = false;

            if ((a == 0) || (b == 0))
            {
            }
            else
            {
                while (a != 1)
                {
                    bool isinpair = IsOdd(a);
                    if (isinpair)
                    {
                        btemp += " + " + b;
                        res.Append("= ");
                        res.Append(b + " * " + (a - 1) + btemp);
                        a = a - 1;
                        res.Append("\n");
                        Console.Error.WriteLine("isunpair");
                        inpairvalid = true;
                    }
                    else
                    {
                        a = a / 2;
                        b = b * 2;
                        //Reste de la division
                        int rest = a % 2;
                        //if (inpairvalid)
                        //{
                        res.Append("= " + b + " * " + a);
                        //}

                        if (inpairvalid)
                        {
                            res.Append(btemp);
                        }
                        res.Append("\n");
                    }
                }
                if (inpairvalid)
                {
                    res.Append("= ");
                    res.Append(b + " * " + (a - 1) + btemp + " + " + b);
                }
                else
                {
                    res.Append("= ");
                    res.Append(b + " * " + (a - 1) + " + " + b);
                }
            }
            res.Append("\n= " + resmultiplication);

            Console.WriteLine(res);
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}