using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210121_savanna
{
    class Ragadozo : Allat
    {
        private int _maxEletkor;
        public override int MaxEletkor
        {
            get => _maxEletkor;
            set
            {
                if (value > 12) throw new Exception("nem megfelelő max életkor");
                _maxEletkor = value;
            }
        }

        public override bool VanKedve => Ehseg == 0 && eveSzaporodott >= 3;

        public override Allat Szaporodik()
        {
            eveSzaporodott = 0;
            return new Ragadozo() { Eletkor = 0, MaxEletkor = Program.rnd.Next(9, 13)};
        }
    }
}
