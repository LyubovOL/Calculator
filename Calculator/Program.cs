using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"First operand_Operation_Second operand\" ");
            Console.WriteLine("Example: 12 + 4");
            var str = Console.ReadLine();
            
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
