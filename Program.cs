using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace uniqгуWordsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = "Grey.txt";
            Dictionary<string,int> keyValuePairs = new Dictionary<string,int>();
            foreach(var line in File.ReadLines(pathToFile))
            {
                var words = line.Split(new char[] { ' ', ',', '.', '!', '?', ':', '-', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var word in words)
                {
                    if (!keyValuePairs.ContainsKey(word))
                    {
                        keyValuePairs.Add(word, 1);
                    }
                    else
                    {
                        keyValuePairs[word]++;
                    }
                }
            }
            using(StreamWriter file =  new StreamWriter("dict.txt")) {
                foreach(var row in keyValuePairs.OrderByDescending(_=>_.Value)) { 
                    file.WriteLine($"{row.Key} {row.Value}");
                }
            }
            Console.WriteLine("Файл создан");
        }
    }
}
