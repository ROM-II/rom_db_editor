using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            var luaOut = new StreamWriter("luad.lua");
            foreach (var fileName in Directory.EnumerateFiles(args[0]))
            {
                if (Path.GetExtension(fileName) != ".lua")
                    continue;
                luaOut.WriteLine("-- File: "+ fileName);
                luaOut.WriteLine(File.ReadAllText(fileName));
                Console.WriteLine("Done {0}", fileName);
            }
            luaOut.Close();
        }
    }
}
