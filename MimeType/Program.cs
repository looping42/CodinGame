using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimeType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int nbrtype = Convert.ToInt32(Console.ReadLine());
            int nbrfichieraAnalyser = Convert.ToInt32(Console.ReadLine());

            string[] fichiertype = new string[nbrtype];
            string[] fichieraAnalyser = new string[nbrfichieraAnalyser];
            string[] resultat = new string[nbrfichieraAnalyser];

            for (int i = 0; i < nbrtype; i++)
            {
                fichiertype[i] = Console.ReadLine();
            }
            for (int i = 0; i < nbrfichieraAnalyser; i++)
            {
                fichieraAnalyser[i] = Console.ReadLine();
            }

            foreach (var item in fichiertype)
            {
                Console.Error.WriteLine("fichierType :" + item);
            }

            foreach (var item in fichieraAnalyser)
            {
                Console.Error.WriteLine("fichieraAnalyser :" + item);
            }

            List<string> type = new List<string>();
            List<string> typeResult = new List<string>();

            foreach (var item in fichiertype)
            {
                type.Add("." + item.Split('/')[1].ToLower());
                typeResult.Add(item.Split(' ')[1]);
            }

            foreach (var item in type)
            {
                Console.Error.WriteLine("type :" + item);
            }

            foreach (var item in typeResult)
            {
                Console.Error.WriteLine("typeResult :" + item);
            }
            List<string> result = new List<string>();
            for (int i = 0; i < fichieraAnalyser.Count(); i++)
            {
                if ((fichieraAnalyser[i].Contains(".") && fichieraAnalyser[i].Split('.').Last() != ""))
                {
                    string temp = "." + fichieraAnalyser[i].Split('.').Last().ToLower();

                    //bool found = false;
                    //int j = 0;
                    //foreach (string each in type)
                    //{
                    //    if (each.Contains(temp))
                    //    {
                    //        found = true;

                    //    }
                    //    j = j + 1;
                    //}
                    if (type.Exists(x => x.Equals(temp)))
                    {
                        int val = type.FindIndex(x => x.Equals(temp));
                        result.Add(typeResult[val]);
                    }
                    else
                    {
                        result.Add("UNKNOWN");
                    }
                }
                else
                {
                    result.Add("UNKNOWN");
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}