using System;
using System.IO;
using Runes.Net.Fdb;

namespace FdbExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: <exe> <*.fdb file> [fileToExtract]");
                return;
            }
            var fdbFileName = args[0];
            var fdb = new Fdb();
            try
            {
                fdb.LoadFromFile(fdbFileName);
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to open FDB file - {0}", e.Message);
                return;
            }

            var interactive = args.Length < 2;

            string fileToExtract = null;
            if (!interactive)
                fileToExtract = args[1];
            else
            {
                Console.WriteLine("Files avaliable:");
                foreach (var fileEntry in fdb.Entries)
                {
                    Console.WriteLine("\t" + fileEntry);
                }
                Console.WriteLine("Enter a filename to extract");
                fileToExtract = Console.ReadLine();
            }
            if (fileToExtract == null)
                return;

            try
            {
                ONE_MORE_TIME:
                ExtractFile(fdb, fileToExtract);
                if (interactive)
                {
                    Console.WriteLine("Another one? (y/whatever):");
                    var a = Console.ReadKey();
                    if (a.KeyChar != 'y')
                        return;
                    Console.WriteLine("Enter a filename to extract");
                    fileToExtract = Console.ReadLine();
                    goto ONE_MORE_TIME;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            if (interactive)
                Console.ReadKey();
        }

        public static void ExtractFile(Fdb fdb, string fileToExtract)
        {
            var path = Path.GetDirectoryName(Path.GetFullPath(fileToExtract));
            Console.WriteLine("Creating " + path);
            Directory.CreateDirectory(path);
            var f = new BinaryWriter(new StreamWriter(fileToExtract).BaseStream);
            Console.WriteLine("Extracting ...");
            fdb.ExtractFile(fileToExtract, f);
            f.Close();
            Console.WriteLine("Done!");
        }
    }
}
