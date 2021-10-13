using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Alfil
    {
        public Alfil(ePieza pieza, int fila, int col)
        {
            sPieza p_alfil = new sPieza(pieza);
            sPosicion pos = new sPosicion(fila, col);
            p_alfil.posicion = pos;
        }
        public sPieza p_alfil { get { return p_alfil; } }
    }
}
