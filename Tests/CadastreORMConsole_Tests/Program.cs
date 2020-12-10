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
            LogerService.WriteLogAsync("Начало работы программы");
            LogerService.WriteLogAsync("Double 1");

            Console.WriteLine("Некоторая работа");

            LogerService.WriteLogAsync("Double 2");

            Console.WriteLine("Еще некоторая работа");

            LogerService.WriteLogAsync("Double 3");

            Console.Read();
            LogerService.WriteLogAsync("Окончание работы программы");
        }
    }
}
