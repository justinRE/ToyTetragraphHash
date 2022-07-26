using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("ToyTetragraphHash.Tests")]
namespace ToyTetragraphHash
{
    class ToyTetragraphHash
    {
        private const Boolean DEBUG = false;


        static void Main(string[] args)
        {
            ToyTetragraphHash hash = new ToyTetragraphHash();
            System.Console.WriteLine(hash.outTitle());

            Console.WriteLine("Enter the String to be hashed: ");
            string input = "I leave twenty million dollars to my friendly cousin Bill."; //Console.ReadLine();

            List<string> blocks = hash.stringToBlocks(input);
            int counter = 0;
            int[] runningTotal = new int[4];
            //calls cleanString and createBlocks
            char[] finalResults = new char[4];
            foreach (string block in blocks)
            {
                if (DEBUG)
                {
                    Console.Out.WriteLine(" ");
                    Console.Out.Write("Block {0}: ", counter);
                    Console.Out.Write(block);
                }


                string[,] results = hash.createTwoDimensionArrayFromString(block);
                int[,] intResults = hash.convertToInts(results);
                int[] columnResults = hash.addColumns(intResults);
                runningTotal = hash.addRunningTotal(runningTotal,columnResults);
                counter++;

                if(DEBUG)
                {
                    Console.Out.Write(" - ");
                    foreach (int i in columnResults)
                    {
                        Console.Write("{0} ", i);
                    }
                    Console.Out.Write(" ");
                }


                string[,] rotatedArray = hash.rotateTwoDimensionArray(results);
                int[,] intArrayResults = hash.convertToIntsresult(rotatedArray);
                int[] rotatedColumnResults = hash.addColumns(intArrayResults);
                runningTotal = hash.addRunningTotal(runningTotal, rotatedColumnResults);

                finalResults = hash.runningTotalToString(runningTotal);

            }
            foreach (var item in finalResults)
            {
                Console.Write(item);
            }

        }

        internal String outTitle()
        {
            return "Toy Tetragraph Hash: ";
        }

        internal string cleanString(string input)
        {
            string result = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());

            result = result.Replace(" ", "").ToLower();
            if (result.Any(char.IsDigit))
            {
                throw new Exception("Input may not contain numbers");
            }

            return result;
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
            int counter = 0;
            int totalNumber = 0;
            int[] runningTotal = new int[4];

            const int COL = 1;
            const int ROW = 0;

            for (int column = 0; column < numArray.GetLength(COL); column++)
            {
                for (int row = 0; row < numArray.GetLength(ROW); row++)
                {
                    counter += numArray[row, column];
                    totalNumber = counter % 26;
                }
                if (column == 0)
                {
                    runningTotal[0] += totalNumber;
                    runningTotal[0] = runningTotal[0] % 26;
                    totalNumber = 0;
                    counter = 0;
                }
                if (column == 1)
                {
                    runningTotal[1] += totalNumber;
                    runningTotal[1] = runningTotal[1] % 26;
                    totalNumber = 0;
                    counter = 0;
                }
                if (column == 2)
                {
                    runningTotal[2] += totalNumber;
                    runningTotal[2] = runningTotal[2] % 26;
                    totalNumber = 0;
                    counter = 0;
                }
                if (column == 3)
                {
                    runningTotal[3] += totalNumber;
                    runningTotal[3] = runningTotal[3] % 26;
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

        internal int[] addRunningTotal(int[] runningTotal, int[] columnResults)
        {
            int[] newTotal = new int[4];
            int holder = 0;
            int holderone = 0;

            const int ROW = 0;

            for (int i = 0; i < runningTotal.GetLength(ROW); i++)
            {
                holder = runningTotal[i] + columnResults[i];
                holderone = holder % 26;
                newTotal[i] = holderone;
            }
            return newTotal;
        }

    }
}