using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Storage
{
    public class StoreInFile : IStorage
    {
        public string Path { get; set; }

        public StoreInFile(string path)
        {
            Path = path;
        }
        public void Write(string operation)
        {
            File.AppendAllText(Path, operation);
        }

        public string[] Read(int countString)
        {
            if (!File.Exists(Path))
            {
                return null;
            }
            var historyOfOperation = new string[countString];
            historyOfOperation = File.ReadLines(Path).Reverse().Take(countString).Reverse().ToArray();
            return historyOfOperation;
        }
    }
}
