using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IStorage
    {
        void Write(string operation);
        string[] Read(int countString);
    }
}
