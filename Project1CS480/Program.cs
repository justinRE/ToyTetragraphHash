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
        }

        internal string[,] rotateTwoDimensionArray(string[,] result)
        {
            string[,] rotatedArray = new string[4, 4];

            //rotate1
            rotatedArray[0, 3] = result[0, 0];
            rotatedArray[0, 0] = result[0, 1];
            rotatedArray[0, 1] = result[0, 2];
            rotatedArray[0, 2] = result[0, 3];
            //rotate2
            rotatedArray[1, 2] = result[1, 0];
            rotatedArray[1, 3] = result[1, 1];
            rotatedArray[1, 0] = result[1, 2];
            rotatedArray[1, 1] = result[1, 3];
            //rotate3
            rotatedArray[2, 1] = result[2, 0];
            rotatedArray[2, 2] = result[2, 1];
            rotatedArray[2, 3] = result[2, 2];
            rotatedArray[2, 0] = result[2, 3];
            //reverse
            rotatedArray[3, 3] = result[3, 0];
            rotatedArray[3, 2] = result[3, 1];
            rotatedArray[3, 1] = result[3, 2];
            rotatedArray[3, 0] = result[3, 3];

            return rotatedArray;
        }

/*        internal int[,] convertToInts(string[,] result)
        {
            int[,] arrayToInt = new int[4, 4];
            result.ToCharArray();
            arrayToInt[0, 0] = char.ToUpper(result[0, 0].ToCharArray) - 64;
            //int index = char.ToUpper(c) - 64;
            return arrayToInt[,];
        }
*/
    }
}