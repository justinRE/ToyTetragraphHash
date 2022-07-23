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
    }
}