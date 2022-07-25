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
            /*
            Console.WriteLine("Enter the String to be hashed: ");
            string input = Console.ReadLine();

            hash.stringToBlocks(input);
            //calls cleanString and createBlocks
            foreach(block in StringBlocks)
            {
                createTwoDimensionArrayFromString()
                convertToIntsresult()
                addColumns()

                rotateTwoDimensionArray()
                convertToInts()
                addColumns()

            }
            */
        }

        internal String outTitle()
        {
            return "Toy Tetragraph Hash: ";
        }

        internal string cleanString(string input)
        {

            string result = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
            return result.Replace(" ", "").ToLower();
        }

        internal List<String> stringToBlocks(String input)
        {
            String inputCleaned = cleanString(input);
            List<String> stringBlocks = createBlocks(inputCleaned);

            return stringBlocks;
        }

        internal new List<String> createBlocks(string input)
        {
            int counter = 0;
            string holder = "";
            StringBuilder sb = new StringBuilder(holder);
            List<string> letterList = new List<string>();
            StringBuilder inputholder = new StringBuilder(input);

            if (input.Length % 16 != 0)
            {
                int leftovernumbers = input.Length % 16;
                int remainder = 16 - leftovernumbers;
                for (int i = 0; i < remainder; i++)
                {
                    inputholder.Append("a");
                }
            }

            foreach (char item in inputholder.ToString())
            {
                sb.Append(item);
                counter++;
                if (counter % 16 == 0)
                {
                    letterList.Add(sb.ToString());
                    if (DEBUG) Console.WriteLine(sb);
                    sb.Clear();
                }

            }

            return letterList;
        }

        //think I could have to .ToCharArray()
        internal string[,] createTwoDimensionArrayFromString(string input)
        {
            if (input.Length != 16)
            {
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

        //also need result as nums
        internal int[,] convertToInts(string[,] rotatedArray)
        {
            int[,] numArray = new int[4, 4];
            char[,] charRotatedArray = new char[4, 4];

            for (int row1 = 0; row1 < 4; row1++)
            {
                for (int column1 = 0; column1 < 4; column1++)
                {
                    char character;
                    char.TryParse(rotatedArray[row1, column1], out character);
                    charRotatedArray[row1, column1] = character;
                }
            }

            //toint
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    numArray[row, column] = charRotatedArray[row, column] - 97;
                }
            }

            return numArray;
        }

        internal int[,] convertToIntsresult(string[,] result)
        {
            int[,] numArray = new int[4, 4];
            char[,] charRotatedArray = new char[4, 4];

            for (int row1 = 0; row1 < 4; row1++)
            {
                for (int column1 = 0; column1 < 4; column1++)
                {
                    char character;
                    char.TryParse(result[row1, column1], out character);
                    charRotatedArray[row1, column1] = character;
                }
            }

            //toint
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    numArray[row, column] = charRotatedArray[row, column] - 97;
                }
            }

            return numArray;
        }

        internal int[] addColumns(int[,] numArray)
        {
            int[] runningTotal = new int[4];
            int counter = 0;
            int totalNumber = 0;


            for (int column = 0; column < 4; column++)
            {
                for (int row = 0; row < 4; row++)
                {
                    counter += numArray[column, row];
                    totalNumber = counter % 26;
                }
                if (column == 0)
                {
                    runningTotal[0] = totalNumber;
                    totalNumber = 0;
                    counter = 0;
                }
                if (column == 1)
                {
                    runningTotal[1] = totalNumber;
                    totalNumber = 0;
                    counter = 0;
                }
                if (column == 2)
                {
                    runningTotal[2] = totalNumber;
                    totalNumber = 0;
                    counter = 0;
                }
                if (column == 3)
                {
                    runningTotal[3] = totalNumber;
                    totalNumber = 0;
                    counter = 0;
                }
            }
            if (DEBUG)
            {
                foreach (var item in runningTotal)
                {
                    Console.WriteLine(item);
                }
            }
            return runningTotal;

        }


        internal char[] runningTotalToString(int[] runningTotal)
        {
            char[] result = new char[4];
           
            result[0] = (char)(runningTotal[0] + 65);
            result[1] = (char)(runningTotal[1] + 65);
            result[2] = (char)(runningTotal[2] + 65);
            result[3] = (char)(runningTotal[3] + 65);

            return result;
        }
    }
}