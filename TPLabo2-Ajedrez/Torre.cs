using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Torre
    {
        public Torre()
        {
            sPieza p_torre = new sPieza(ePieza.TORRE);
        }
        public sPieza p_torre { get { return p_torre; } }
    }
}
