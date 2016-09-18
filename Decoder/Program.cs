using System;
using Runes.Net.Shared;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Console.ReadLine();
            var encoded = Console.ReadLine();

            Console.WriteLine(RomEncoding.DecodePassword(encoded, key));
            Console.ReadKey();
        }
    }
}
