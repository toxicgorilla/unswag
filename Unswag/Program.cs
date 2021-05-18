using System.Collections.Generic;
using System.IO;

namespace UrlsFromSwagger
{
    public class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                System.Console.WriteLine("Please supply a file");
                
                return -1;
            }

            System.Console.WriteLine($"Input file: {args[0]}");

            var path = args[0];
            var lines = File.ReadAllLines(path);

            var verbs = new List<string> {"GET", "POST", "PUT", "DELETE"};
            var urls = new List<string>();

            for (var i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];
                if (verbs.Contains(currentLine))
                {
                    i++;
                    var nextLine = lines[i];
                    urls.Add($"{currentLine} {nextLine}");
                }
            }

            urls.ForEach(System.Console.WriteLine);

            return 0;
        }
    }
}
