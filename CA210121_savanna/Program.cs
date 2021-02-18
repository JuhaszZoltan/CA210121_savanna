using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA210121_savanna
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main()
        {
            var szavanna = new Szavanna(20, 20);

            #region benépesítés
            for (int i = 0; i < 200; )
            {
                int x = rnd.Next(szavanna.Terulet.GetLength(0));
                int y = rnd.Next(szavanna.Terulet.GetLength(1));

                if(szavanna.Terulet[x, y] is null)
                {
                    if(rnd.Next(100) < 60)
                    {
                        var me = rnd.Next(11, 15);
                        var ae = rnd.Next(me /2);
                        szavanna.Terulet[x, y] = new Novenyevo()
                        {
                            MaxEletkor = me,
                            Eletkor = ae,
                        };

                    }
                    else
                    {
                        var me = rnd.Next(9, 13);
                        var ae = rnd.Next(me/2);
                        szavanna.Terulet[x, y] = new Ragadozo()
                        {
                            MaxEletkor = me,
                            Eletkor = ae,
                        };
                    }

                    i++;
                }

            }
            #endregion

            #region 100 év

            for (int i = 0; i < 100; i++)
            {
                szavanna.EltelikEgyEv();
                szavanna.Kirajzol();
                //Console.ReadKey();
                Console.Clear();
            }

            #endregion


            Console.ReadKey(true);
        }
        static void Tesz01()
        {
            Szavanna sz = new Szavanna(2, 2);

            sz.Terulet[0, 0] = new Ragadozo();
            sz.Terulet[0, 1] = new Novenyevo();
            sz.Terulet[1, 0] = null;
            sz.Terulet[1, 1] = new Novenyevo();

            var lista = sz.KornyezoAllatok(sz.Terulet[1, 1], false);

            Console.WriteLine(lista.Contains(sz.Terulet[0, 1]).ToString());
            //--> true
            Console.WriteLine(lista.Contains(sz.Terulet[0, 0]).ToString());
            //--> false!!
            Console.WriteLine(lista.Contains(sz.Terulet[1, 1]).ToString());
            //--> true
        }
    }
}
