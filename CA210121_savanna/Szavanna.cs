using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210121_savanna
{
    class Szavanna
    {
        public Allat[,] Terulet { get; set; }

        public Cella Megkeres(Allat allat)
        {
            for (int x = 0; x < Terulet.GetLength(0); x++)
            {
                for (int y = 0; y < Terulet.GetLength(1); y++)
                {
                    if (Terulet[x, y] == allat) return new Cella(x, y);
                }
            }
            return null;
        }

        private void Torol(Allat allat)
        {
            var c = Megkeres(allat);
            if (c != null)
            {
                Terulet[c.X, c.Y] = null;
            }
        }

        public void Elpusztult(Novenyevo allat)
        {
            Torol(allat);
            allat.El = false;
        }

        public void Elhelyez(Allat allat, Cella c)
        {
            Terulet[c.X, c.Y] = allat;
        }

        public void Mozgat(Allat allat, Cella c)
        {
            Torol(allat);
            Elhelyez(allat, c);
        }

        public List<Allat> KornyezoAllatok(Allat allat, bool nov)
        {
            var c = Megkeres(allat);
            if (c is null) return null;

            var allatok = new List<Allat>();

            for (int x = Math.Max(0, c.X - 1);
                x <= Math.Min(c.X + 1, Terulet.GetLength(0) - 1);
                x++)
            {
                for (int y = Math.Max(0, c.Y - 1);
                    y <= Math.Min(c.Y + 1, Terulet.GetLength(1) - 1);
                    y++)
                {
                    if (!(x == c.X && y == c.Y) && Terulet[x, y] != null)
                    {
                        if (nov && Terulet[x, y] is Novenyevo) allatok.Add(Terulet[x, y]);
                        if (!nov && Terulet[x, y] is Ragadozo) allatok.Add(Terulet[x, y]);
                    }
                }
            }
            return allatok;
        }

        public List<Cella> KornyezoUresCellak(Allat allat)
        {
            var c = Megkeres(allat);
            if (c is null) return null;

            var cellak = new List<Cella>();

            for (int x = Math.Max(0, c.X - 1);
                x <= Math.Min(c.X + 1, Terulet.GetLength(0) - 1);
                x++)
            {
                for (int y = Math.Max(0, c.Y - 1);
                    y <= Math.Min(c.Y + 1, Terulet.GetLength(1) - 1);
                    y++)
                {
                    if (!(x == c.X && y == c.Y) && Terulet[x, y] == null)
                    {
                        cellak.Add(new Cella(x, y));
                    }
                }
            }
            return cellak;
        }


        public void EltelikEgyEv()
        {
            var osszesAllat = OsszesAllatMegkeverve();

            foreach (var a in osszesAllat)
            {
                //eszik
                if (a.El)
                {                   
                    if (a is Novenyevo) a.Eszik();
                    else
                    {
                        var kornyezoNovenyevok = KornyezoAllatok(a, true);
                        if (kornyezoNovenyevok != null && kornyezoNovenyevok.Count > 0)
                        {
                            var zsakmany = kornyezoNovenyevok[Program.rnd.Next(kornyezoNovenyevok.Count)];
                            Elpusztult(zsakmany as Novenyevo);
                            a.Eszik();
                        }
                    }
                }

                var kornyezoFajtarsak = KornyezoAllatok(a, a is Novenyevo);
                var kornyezoCellak = KornyezoUresCellak(a);

                //szaporodás
                if (a.El)
                {                   
                    if (a.VanKedve &&
                        kornyezoFajtarsak != null && kornyezoFajtarsak.Count > 0 &&
                        kornyezoCellak != null && kornyezoCellak.Count > 0)
                    {
                        var utod = a.Szaporodik();
                        Elhelyez(utod, kornyezoCellak[Program.rnd.Next(kornyezoCellak.Count)]);
                    }
                }

                //mozgás
                if (a.El)
                {
                    kornyezoCellak = KornyezoUresCellak(a);
                    if (kornyezoCellak != null && kornyezoCellak.Count > 0)
                    {
                        Mozgat(a, kornyezoCellak[Program.rnd.Next(kornyezoCellak.Count)]);
                    }
                }


                //öregedés
                if (a.El)
                {
                    a.Oregszik();
                    if (!a.El) Torol(a);
                }
            }
        }

        private List<Allat> OsszesAllatMegkeverve()
        {
            var allatok = new List<Allat>();
            foreach (var e in Terulet) if (e != null) allatok.Add(e);
            for (int i = 0; i < allatok.Count; i++)
            {
                var a = Program.rnd.Next(allatok.Count);
                var b = Program.rnd.Next(allatok.Count);

                var c = allatok[a];
                allatok[a] = allatok[b];
                allatok[b] = c;
            }
            return allatok;
        }
        public void Kirajzol()
        {
            for (int x = 0; x < Terulet.GetLength(0); x++)
            {
                for (int y = 0; y < Terulet.GetLength(1); y++)
                {
                    if(Terulet[x, y] is Ragadozo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('R');
                    }
                    else if(Terulet[x, y] is Novenyevo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('N');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('.');
                    }
                    Console.ResetColor();
                }
                Console.Write('\n');
            }
        }

        public Szavanna(int x, int y)
        {
            Terulet = new Allat[x, y];
        }
    }
}
