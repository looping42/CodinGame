using System;

namespace ThorTailleDuCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] l = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }), int.Parse);
            int x = l[0];
            int y = l[1];
            int o = l[2];
            int p = l[3];
            string r = "";
            var n = "NE";
            var e = "E";
            var s = "SE";
            var m = "N";
            var k = "S";
            var w = "NW";
            var f = "W";
            var g = "SW";

            while (true)
            {
                var t = Console.ReadLine();
                if (o < x)
                {
                    if (p > y)
                    {
                        r = n;
                    }
                    if (p == y)
                    {
                        r = e;
                    }
                    if (p < y)
                    {
                        r = s;
                    }
                }
                else if (o == x)
                {
                    if (p > y)
                    {
                        r = m;
                    }
                    else
                    {
                        r =k;
                    }
                }
                else if (p > y)
                {
                    r = w;
                }
                else if (p == y)
                {
                    r = f;
                }
                else
                {
                    r = g;
                }

                if ((r == n) || (r == e) || (r == s))
                {
                    o = o + 1;
                }
                if ((r == s) || (r == g) || (r == k))
                {
                    p = p + 1;
                }
                if ((r == n) || (r == m) || (r == w))
                {
                    p = p - 1;
                }
                if ((r == f) || (r == w) || (r == g))
                {
                    o = o - 1;
                }
                Console.WriteLine(r);
            }
        }
    }
}