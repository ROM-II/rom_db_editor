using NUnit.Framework;
using Runes.Net.Shared;

namespace Tests
{
    [TestFixture]
    public class RomDecodeTest
    {
        [TestCase("0304011d16021711", "USERNAME", ExpectedResult = "PASSWORD")]
        [TestCase("0304011d1602177567", "USERNAME1", ExpectedResult = "PASSWORD2")]
        public string Decode(string passwordEncoded, string key) 
            => RomEncoding.DecodePassword(passwordEncoded, key);
    }
}
