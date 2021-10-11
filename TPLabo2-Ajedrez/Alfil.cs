using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Alfil
    {
        public Alfil()
        {
            sPieza p_alfil = new sPieza(ePieza.ALFIL);
        }
        public sPieza p_alfil { get { return p_alfil; } }
    }
}
