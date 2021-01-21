using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210121_savanna
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main()
        {
            var lista = new Allat[200];


            for (int i = 0; i < 200; i++)
            {
                lista[i] = new Ragadozo();
            }

            Console.ReadKey(true);
        }
    }
}
