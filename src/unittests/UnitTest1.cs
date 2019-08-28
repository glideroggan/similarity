using Microsoft.VisualStudio.TestTools.UnitTesting;
using sim;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("Advenica", "Advenica AB publ", true)]
        [DataRow("Advenica AB", "Advenica AB publ", true)]
        [DataRow("Advenica AB publ", "Advenica AB publ", true)]
        [DataRow("Advenica Aktiebolag", "Advenica AB publ", true)]
        [DataRow("Adveinca Atiebolag", "Advenica AB publ", true)]
        [DataRow("Advent Atiebolag", "Advenica AB publ", false)]
        [DataRow("AB Advenica Aktiebolag", "Advenica AB publ", true)]
        [DataRow("A City", "A City Media", true)]
        [DataRow("A City Media", "A City Media", true)]
        [DataRow("A City Media AB", "A City Media", true)]
        [DataRow("A City Media AB", "Advenica AB publ", false)]
        [DataRow("A Cityy Media AB", "A City Media", true)]
        public void Test(string input, string source, bool expected)
        {
            var actual = Matcher.Match(input, source);

            Assert.AreEqual(expected, actual, $"'{input}' didn't match '{source}'");
        }
    }
}
