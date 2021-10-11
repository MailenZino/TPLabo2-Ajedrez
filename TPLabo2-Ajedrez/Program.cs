
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
        sPieza TORRE2;
        sPieza ALFIL1;
        sPieza ALFIL2;
        sPieza REINA;
        public Program()
        {
            CANT_SOL = 0;
            LOOKUP = new sPieza[8];
        }
        public void BuscarSoluciones()
        {
            Tablero MatrizPrueba = new Tablero(8);
            // 1 para posicion atacada | 0 libre

            //                   Cargamos ataque de las torres y guardamos la posicion en look up
            TORRE1 = new sPieza(ePieza.TORRE, 0, 0);
            TORRE2 = new sPieza(ePieza.TORRE, 1, 1);
            LOOKUP[0] = TORRE1;
            LOOKUP[1] = TORRE2;

            MatrizPrueba.CargarFILACOL(0);
            MatrizPrueba.CargarFILACOL(1);
            MatrizPrueba.CargarFILACOL(0, false);
            MatrizPrueba.CargarFILACOL(1, false);


            //                   Cargamos ataque de alfiles y guardamos la posicion en look up 

            Random rd = new Random(); int auxPos = rd.Next(2, 5); //llega a 5 o a 4??

            ALFIL1 = new sPieza(ePieza.ALFIL, auxPos, auxPos);

            if (auxPos == 2)
                ALFIL2 = new sPieza(ePieza.ALFIL, auxPos, auxPos + 1);
            else
                ALFIL2 = new sPieza(ePieza.ALFIL, auxPos, auxPos - 1);

            LOOKUP[2] = ALFIL1;
            LOOKUP[3] = ALFIL2;
            //ya nos aseguramos que quede uno en casilla blanca y otro en negra

            MatrizPrueba.CargarDiagonales(ALFIL1.posicion.FILA, ALFIL1.posicion.COL);
            MatrizPrueba.CargarDiagonales(ALFIL2.posicion.FILA, ALFIL2.posicion.COL);


            //                   Cargamos ataque de la reina y guardamos la posicion en look up 
            int auxCol;
            int auxFila;
            do
            {
                auxCol = rd.Next(2, 5);
                auxFila = rd.Next(2, 5);
            } while (!(MatrizPrueba.VerificarLibredeAtaque(auxFila, auxCol)));
            REINA = new sPieza(ePieza.REINA, auxFila, auxCol);
            LOOKUP[4] = REINA;
            MatrizPrueba.CargarDiagonales(REINA.posicion.FILA, REINA.posicion.COL);
            MatrizPrueba.CargarFILACOL(auxFila);
            MatrizPrueba.CargarFILACOL(auxFila, false);

            //seguir con el rey

        }
        static void Main(string[] args)
        {
            var Tablero = new Program();
            while (Tablero.CANT_SOL < 10)
            {
                Tablero.BuscarSoluciones();
                Tablero.CANT_SOL++;
            }
        }

    }
}
