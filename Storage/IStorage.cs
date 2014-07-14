using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorage
    {
        void Write(string operation, string path);
        string[] Read(string path, int countString);
    }
}
