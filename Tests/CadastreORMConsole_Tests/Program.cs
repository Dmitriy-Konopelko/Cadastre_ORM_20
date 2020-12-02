using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogging;

namespace CadastreORMConsole_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            LogerService.ReadWriteAsync("Журнал работы программы");
            LogerService.ReadWriteAsync("Double 1");

            Console.WriteLine("Некоторая работа");

            LogerService.ReadWriteAsync("Double 2");

            Console.WriteLine("Еще некоторая работа");

            LogerService.ReadWriteAsync("Double 3");

            Console.Read();
        }
    }
}
