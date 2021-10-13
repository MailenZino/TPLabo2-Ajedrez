using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Reina
    {
        public Reina(ePieza pieza, int fila, int col)
        {
            sPieza p_reina = new sPieza(pieza);
            p_reina.COL = col;
            p_reina.FILA = fila;
            //sPosicion pos = new sPosicion(fila, col);
            //p_reina.posicion = pos;
        }
        public sPieza p_reina { get { return p_reina; } }
    }
}
