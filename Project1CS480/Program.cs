using System.Runtime.CompilerServices;
using System.Text;

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
        internal List<String> stringToBlocks(String input)
        {
            String inputCleaned = cleanString(input);
            List<String> stringBlocks = createBlocks(inputCleaned);
           
            return stringBlocks;
        }

        internal new List<String> createBlocks(string input) {
            int counter = 0;
            string holder = "";
            StringBuilder sb = new StringBuilder(holder);
            List<string> letterList = new List<string>();
            StringBuilder inputholder = new StringBuilder(input);

            if (input.Length % 16!= 0)
            {
                int leftovernumbers = input.Length % 16;
                int remainder = 16 - leftovernumbers;
                for(int i=0; i < remainder; i++)
                {
                    inputholder.Append("a");
                }
            }

            foreach (char item in inputholder.ToString())
            {
                sb.Append(item);
                counter++;
                if(counter%16==0)
                {
                    letterList.Add(sb.ToString());
                    if (DEBUG) Console.WriteLine(sb);
                    sb.Clear();
                }

            }

            return letterList;
        }

        internal string cleanString(string input)
        {

            string result = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
            return result.Replace(" ", "").ToLower();
        }

        internal string[,] createTwoDimensionArrayFromString(string input)
        {
            if (input.Length != 16){
                throw new Exception("Invalid length");
            }

            int counter = 0;
            int row = 0;
            int col = 0;

            string[,] result = new string[4, 4];

            foreach (char item in input)
            {
                counter++;
                if (counter == 1) col = 0;

                if (DEBUG)
                {
                    Console.Out.Write(item);
                    Console.Out.Write("[" + row + "," + col + "]");
                }

                result[row, col] = Char.ToString(item);

                col++;
                if ((counter % 4) == 0)
                {
                    row++;
                    col = 0;
                }
            }
            return result;
            //
        }

        /* So I want to pass in result to this method
        internal string[,] rotateTwoDimensionArray(string[,])
        {
            string[,] result = new string[4, 4];

            return result;
        }
        */

    }
}