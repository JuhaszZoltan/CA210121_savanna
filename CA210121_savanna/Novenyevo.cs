using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210121_savanna
{
    class Novenyevo : Allat
    {
        private int _maxEletkor;
        public override int MaxEletkor 
        {
            get => _maxEletkor;
            set
            {
                if (value > 14) throw new Exception("nem megfelelő max életkor");
                _maxEletkor = value;
            }
        }

        public override bool VanKedve => eveSzaporodott >= 2;

        public override Allat Szaporodik()
        {
            eveSzaporodott = 0;
            return new Novenyevo() { Eletkor = 0, MaxEletkor = Program.rnd.Next(11, 15) };
        }
    }
}
