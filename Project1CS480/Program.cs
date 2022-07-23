using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ToyTetragraphHash.Tests")]
namespace ToyTetragraphHash
{
    class ToyTetragraphHash
    {
        static void Main(string[] args)
        {
            ToyTetragraphHash hash = new ToyTetragraphHash();
            System.Console.WriteLine(hash.outTitle());
        }
        internal String outTitle()
        {
            return "ToyTetragraphHash";
        }
        internal List<string[,]> stringToBlocks(String input) {
            List<String[,]> blocks = new List<String[,]>();
            String[,] block = new String[3,3];
            blocks.Add(block);

            return blocks;
        }
    }
}