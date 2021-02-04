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
        public int Eletkor 
        { 
            get => _eletkor;
            set
            {
                if (value < 0 || value > 1000)
                    throw new Exception("nem megfelelő életkor");
                _eletkor = value;
            }
        }
        abstract public int MaxEletkor { get; set; }
        private int _ehseg = 0;
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
                // if (_el is false) throw new Exception("no resurrection here");
                _el = value;
            }
        }

        protected int eveSzaporodott = 0;

        abstract public bool VanKedve { get; }

        public void Oregszik()
        {
            Eletkor++;
            eveSzaporodott++;
            Ehseg++;
            if (Ehseg >= 2) El = false;
            if (Eletkor >= MaxEletkor) El = false;
        }
        abstract public Allat Szaporodik();

        public void Eszik() => Ehseg = 0;
    }
}
