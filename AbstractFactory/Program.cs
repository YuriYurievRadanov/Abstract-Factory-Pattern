using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory(new OracleFactory());
            factory.Start();

            Console.WriteLine("");
        }
    }
}
