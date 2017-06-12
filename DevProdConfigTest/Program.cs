using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevProdConfigTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadConfig config = new ReadConfig(Config.Development);
            Console.WriteLine(config.Test1);
            Console.WriteLine(config.Test2);
            Console.WriteLine(config.Test3);
            Console.WriteLine(config.Test4);
        }
    }
}
