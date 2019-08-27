using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Similarity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /* call the program with an argument
            if the argument matches something in file with more than 90% accuracy, then add +1 to it
            otherwise add it as another item
             */

            if (args.Length < 2)
            {
                // TODO:
            }
            var word = args[0];
            var items = await LoadFileAsync();
            var keys = new string[items.Keys.Count];
            items.Keys.CopyTo(keys, 0);
            var foundMatch = false;
            foreach (var key in keys)
            {
                var similarity = LevensteinDistance.Similarity(word, key);
                if (similarity >= .7f)
                {
                    items[key]++;
                    foundMatch = true;
                    break;
                }
            }
            if (!foundMatch)
            {
                items.Add(word, 0);
            }

            await SaveFileAsync(items);
        }

        private static async Task SaveFileAsync(Dictionary<string, int> items)
        {
            var lines = new List<string>();
            foreach (var item in items)
            {
                var l = $"{item.Key} {item.Value}";
                lines.Add(l);
            }
            await File.WriteAllLinesAsync("items.dat", lines);
        }

        private static async Task<Dictionary<string, int>> LoadFileAsync()
        {
            var res = new Dictionary<string, int>();
            if (!File.Exists("items.dat"))
            {
                await File.Create("items.dat").DisposeAsync();
                return res;
            }
            
            var lines = await File.ReadAllLinesAsync("items.dat");
            foreach (var line in lines)
            {
                var key = line.Substring(0, line.IndexOf(' '));
                var val = line.Substring(line.LastIndexOf(' ') + 1);
                res.Add(key, int.Parse(val));
            }
            return res;
        }
    }
}
