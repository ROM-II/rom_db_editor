using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Runes.Net.Db
{
    public static class DataFieldsProvider
    {
        public static Dictionary<string, FieldDescriptor[]> ReadFromFile(string csvFile)
        {
            var unknownId = 0;
            var dict = new Dictionary<string, List<FieldDescriptor>>();
            using (var stream = File.OpenText(csvFile))
            {
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    if (line == null)
                        continue;
                    var data = line.Split(';');
                    if (data.Length < 6)
                        continue;
                    var dbname = data[0];
                    List<FieldDescriptor> descriptors;
                    if (!dict.TryGetValue(dbname, out descriptors))
                    {
                        descriptors = new List<FieldDescriptor>();
                        dict[dbname] = descriptors;
                    }
                    var name = data[1];
                    descriptors.Add(new FieldDescriptor
                    {
                        Name = string.IsNullOrWhiteSpace(name) ? "Unknown" + unknownId++: name,
                        Offset = uint.Parse(data[2], NumberStyles.HexNumber),
                        Length = uint.Parse(data[3], NumberStyles.HexNumber),
                        Description = data[5],
                    });
                }
            }

            var dict2 = new Dictionary<string, FieldDescriptor[]>();
            foreach (var key in dict.Keys)
            {
                dict2[key] = dict[key].ToArray();
            }
            return dict2;
        }
    }

    public class FieldDescriptor
    {
        public string Name { get; set; }
        public uint Offset { get; set; }
        public uint Length { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
