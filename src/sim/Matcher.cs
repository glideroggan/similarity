using System;
using System.Linq;
using Similarity;

namespace sim
{
    public static class Matcher
    {
        public static bool Match(string companyName, string word2)
        {
            var words = new string[2];
            if (companyName.Contains(' '))
            {
                var splits = companyName.Split(' ');
                var s = splits.First(x => x.Length > 2);
                words[0] = s;
            }
            else words[0] = companyName;
            if (word2.Contains(' '))
            {
                var splits = word2.Split(' ');
                var s = splits.First(x => x.Length > 2);
                words[1] = s;
            } else words[1] = word2;

            var similarity = LevensteinDistance.Similarity(words[0], words[1]);
            return similarity >= .7f;
        }
    }
}