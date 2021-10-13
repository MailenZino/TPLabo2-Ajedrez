using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Torre
    {
        public Torre(ePieza pieza, int fila, int col)
        {
            sPieza p_torre = new sPieza(pieza);
            p_torre.COL = col;
            p_torre.FILA = fila;
            //sPosicion pos = new sPosicion(fila, col);
            //p_torre.posicion = pos;
        }
        public sPieza p_torre { get { return p_torre; } }
    }
}
