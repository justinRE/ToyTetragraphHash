using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("ToyTetragraphHash.Tests")]
namespace ToyTetragraphHash
{
    class ToyTetragraphHash
    {
        private const Boolean DEBUG = true;

        static void Main(string[] args)
        {
            ToyTetragraphHash hash = new ToyTetragraphHash();
            System.Console.WriteLine(hash.outTitle());
        }
        internal String outTitle()
        {
            return "ToyTetragraphHash";
        }
        internal List<string[,]> stringToBlocks(String input)
        {
            List<String[,]> blocks = new List<String[,]>();
            String[,] block = new String[3, 3];
            blocks.Add(block);

            return blocks;
        }

        internal string cleanString(string input)
        {

            string result = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
            return result.Replace(" ", "").ToLower();
        }

        internal string[,] createTwoDimensionArrayFromString(string input)
        {
            if (input.Length != 16){
                throw new Exception("Invalid length"); //expection
            }

            int counter = 0;
            int row = 0;
            int col = 0;

            foreach (char item in input)
            {
                counter++;
                if (counter == 1) col = 0;

                if (DEBUG)
                {
                    Console.Out.Write(item);
                    Console.Out.Write("[" + row + "," + col + "]");
                }

                col++;
                if ((counter % 4) == 0 && counter !=0)
                {
                    row++;
                    col = 0;
                }
            }
            return new string[0, 0];
        }
    }
}