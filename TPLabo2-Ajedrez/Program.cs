
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    public enum ePieza
    {
        LIBRE=0,
        TORRE1,
        TORRE2,
        ALFIL1,
        ALFIL2,
        REINA,
        REY,
        CABALLO1,
        CABALLO2
    }
    public struct sPosicion
    {
        public sPosicion(int fila, int col)
        {
            int FILA = fila;
            int COL = col;
        }
        public int FILA { get { return FILA; } }
        public int COL { get { return COL; } }
    }
   public struct sPieza
   {
        public sPieza(ePieza pieza_,int fila,int col)
        {
            ePieza pieza=pieza_;
            sPosicion posicion=new sPosicion(fila,col);
        }
        public sPosicion posicion { get { return posicion; } }
   }
   class Program
   {
       int CANT_SOL;
       sPieza[] LOOKUPResolucion;
        public Program()
        { 
            CANT_SOL=0;
            LOOKUPResolucion = new sPieza[8];
        }
        public void BuscarSoluciones()
        {

        }
        static void Main(string[] args)
       {
            var Tablero=new Program();
            while (Tablero.CANT_SOL < 10)
            {
                Tablero.BuscarSoluciones();
                Tablero.CANT_SOL++;
            }
       }
       
   }
}
