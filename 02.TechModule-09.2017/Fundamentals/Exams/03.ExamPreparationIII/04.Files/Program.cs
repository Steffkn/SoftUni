using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^([\w0-9]+)[\W].*?\\+([\w. ]+);([0-9]+)$";
            Regex reg = new Regex(pattern);
            var dirs = new Dictionary<string, Dictionary<string, MyFile>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = reg.Match(input);
                var root = match.Groups[1].Value;
                var file = match.Groups[2].Value;
                var fileSize = match.Groups[3].Value;
                
                if (!dirs.ContainsKey(root))
                {
                    dirs.Add(root, new Dictionary<string, MyFile>());
                }

                if (!dirs[root].ContainsKey(file))
                {
                    dirs[root].Add(file, new MyFile(root, file, fileSize));
                }
                else
                {
                    dirs[root][file].FileSize = BigInteger.Parse(fileSize);
                }
            }

            var conditions = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (dirs.ContainsKey(conditions[2]))
            {
                bool found = false;
                foreach (var dir in dirs[conditions[2]]
                    .Where(x => x.Value.FileExtension == conditions[0].ToLower())
                    .OrderByDescending(x=>x.Value.FileSize)
                    .ThenBy(x=>x.Value.FileName)
                    .ToList())
                {
                    found = true;
                    Console.WriteLine($"{dir.Value.FileName} - {dir.Value.FileSize} KB");
                }

                if (!found)
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }

    class MyFile
    {
        public string Root { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public BigInteger FileSize { get; set; }

        public MyFile(string root, string name, string fileSize)
        {
            this.Root = root;
            this.FileName = name;
            this.FileExtension = name.Substring(name.LastIndexOf('.') + 1).ToLower();
            this.FileSize = BigInteger.Parse(fileSize);
        }
    }
}
