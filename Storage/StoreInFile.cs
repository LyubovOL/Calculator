using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class StoreInFile : IStorage
    {

        public void Write(string operation, string path)
        {
            File.AppendAllText(path, operation);
        }

        public string[] Read(string path, int countString)
        {
            var historyOfOperation = new string[countString];
            historyOfOperation = File.ReadLines(path).Reverse().Take(countString).Reverse().ToArray();
            if (historyOfOperation.Length == 0)
                return null;
            return historyOfOperation;
        }
    }
}
