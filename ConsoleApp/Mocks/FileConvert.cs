using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp.Mocks
{
    class FileConvert : IFile
    {
        string path = "file.txt";
        public List<string> RemoveDuplicates(List<string> ipList)
        {
            var query = ipList.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

            foreach (string s in query)
            {
                Console.WriteLine($"This duplicate: {s} will be removed");
            }
            List<string> result = ipList.Distinct().ToList();
            return result;
        }
        public void SaveToFile(List<string> ipList)
        {
            FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            foreach (string str in ipList)
            {
                sw.WriteLine(str + "\n");
            }
            sw.Close();
            Console.WriteLine("Data saved!");
            Console.ReadLine();
        }
    }
}
