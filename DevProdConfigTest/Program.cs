using System;

namespace DevProdConfigTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Config setting = Config.Development;
#if (DEBUG)
            setting = Config.Development;
#else
            setting = Config.Production;
#endif

            ReadConfig config = new ReadConfig(setting);
            Console.WriteLine(config.Test1);
            Console.WriteLine(config.Test2);
            Console.WriteLine(config.Test3);
            Console.WriteLine(config.Test4);
            Console.Read();
        }
    }
}
