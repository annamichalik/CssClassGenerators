using System;
using System.Collections.Generic;
using System.IO;

namespace CoreAppConsolGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var columnsPath = Path.Combine(baseDirectory, @"templateForCSS.txt");
            var xmlResultPath = Path.Combine(baseDirectory, @"ResultClasses.txt");

            var textToCreate = File.ReadAllText(columnsPath);
            var replacedValues = new List<string>();
            for (int i =2; i<40; i++)
            {
                var outputChunk = textToCreate;
                var replaced = outputChunk.Replace("%css_class%", string.Format("l{0}",i));
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                replaced = replaced.Replace("%color%", color);
                replacedValues.Add(replaced);

            }

            File.WriteAllLines(xmlResultPath, replacedValues);
            Console.ReadKey();
        }
    }
}
