
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
        TORRE,
        ALFIL,
        REINA,
        REY,
        CABALLO
    }
    public struct sPosicion
    {
        public sPosicion(int fila, int col)
        {
            int FILA = fila;
            int COL = col;
        }
        public int FILA 
        { 
            get { return FILA; }
            set { FILA = value; }
        }
        public int COL 
        { 
            get { return COL; } 
            set { COL = value; }
        }

    }
   public struct sPieza
   {
        public sPieza(ePieza pieza_,int fila=0,int col=0)
        {
            ePieza pieza=pieza_;
            sPosicion posicion=new sPosicion(fila,col);
        }
        public sPosicion posicion { get { return posicion; } set { posicion = value; } }
        public ePieza pieza { get { return pieza; } }
   }
   class Program
   {
       int CANT_SOL;
       sPieza[] LOOKUP;
       sPieza TORRE1; 
        public Program()
        { 
            CANT_SOL=0;
            LOOKUP = new sPieza[8];
        }
        public void CargarFILACOL()
        {

        }
        public void BuscarSoluciones()
        {
            bool[,] MatrizPrueba = new bool[8, 8];
            // 1 posicion atacada | 0 libre

            // Posicionamos las torres para trabajar en un 6x6
            sPieza TORRE1 = new sPieza(ePieza.TORRE, 0, 0);
            sPieza TORRE2 = new sPieza(ePieza.TORRE, 1, 1);
            LOOKUP[0] = TORRE1;
            LOOKUP[0] = TORRE2;
            CargarFILACOL(0);
            CargarFILACOL(1);
            CargarFILACOL(0,false);
            CargarFILACOL(1,false);

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
