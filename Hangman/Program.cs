using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] listPendu = new string[] { "+--+\n|\n|\n|\\", "+--+\n|  o\n|\n|\\", "+--+\n|  o\n|  |\n|\\",
                "+--+\n|  o\n| /|\n|\\",  "+--+\n|  o\n| /|\\\n|\\",  "+--+\n|  o\n| /|\\\n|\\/",  "+--+\n|  o\n| /|\\\n|\\/ \\"};
            string word = Console.ReadLine();
            string chars = Console.ReadLine();
            string[] charSplit = chars.Split(' ');
            Console.Error.WriteLine(word);
            Console.Error.WriteLine(chars);

            List<char> result = new List<char>();
            List<char> alreadyAsk = new List<char>();
            int numberedPenduDIsplay = 0;
            foreach (var charunique in charSplit)
            {
                if (word.Contains(charunique) && !result.Contains(Convert.ToChar(charunique)))
                {
                    result.Add(Convert.ToChar(charunique));
                }
                else
                {
                    numberedPenduDIsplay++;
                }
            }
            StringBuilder NameResult = new StringBuilder();
            foreach (char letter in word)
            {
                if (result.Contains(Convert.ToChar(letter.ToString().ToLower())))
                {
                    NameResult.Append(letter);
                }
                else if (letter == ' ')
                {
                    NameResult.Append(" ");
                }
                else
                {
                    NameResult.Append("_");
                }
            }
            Console.WriteLine(listPendu[numberedPenduDIsplay]);
            Console.WriteLine(NameResult);
        }
    }
}