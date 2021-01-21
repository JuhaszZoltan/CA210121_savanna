using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210121_savanna
{
    abstract class Allat
    {
        private int _eletkor;

        //TODO: Max Eletkor?
        public int Eletkor { 
            get => _eletkor;
            set
            {
                if (value < 0 || value > 1000)
                    throw new Exception("nem megfelelő életkor");
                _eletkor = value;
            }
        }
        abstract public int MaxEletkor { get; protected set; }
        private int _ehseg;
        public int Ehseg
        {
            get => _ehseg;
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("nem megfelelő éhség");
                _ehseg = value;
            }
        }

        private bool _el = true;
        public bool El 
        { 
            get => _el;
            set
            {
                if (_el is false) throw new Exception("no resurrection here");
                _el = value;
            }
        }

        //TODO: ?????
        protected Szavanna Szavanna { get; set; }

        protected int EvMulvaTudSzaporodni = 0;
        public void Oregszik()
        {
            Eletkor++;
            if (EvMulvaTudSzaporodni != 0) EvMulvaTudSzaporodni--;
            if (Eletkor == MaxEletkor) El = false;
        }
        abstract public Allat Szaporodik();

        abstract public void Eszik();

        //TODO: ??????
        public void Mozog()
        {
            throw new NotImplementedException();
        }
    }
}
