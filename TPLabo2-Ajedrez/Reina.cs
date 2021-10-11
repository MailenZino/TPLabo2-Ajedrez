using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Reina
    {
        public Reina()
        {
            sPieza p_reina = new sPieza(ePieza.REINA);
        }
        public sPieza p_reina { get { return p_reina; } }
    }
}
