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
            protected set
            {
                if (value > 14) throw new Exception("nem megfelelő max életkor");
                _maxEletkor = value;
            }
        }

        public override void Eszik() { }


        public override Allat Szaporodik()
        {

            if(EvMulvaTudSzaporodni != 0)
            {
                return null;
            }
            else
            {
                //List<Allat> kornyezoAllatok = Szavanna.KornyezoAllatok(this);


                var ujegyed = new Novenyevo();
                EvMulvaTudSzaporodni = 2;

                return ujegyed;
            }
        }
    }
}
