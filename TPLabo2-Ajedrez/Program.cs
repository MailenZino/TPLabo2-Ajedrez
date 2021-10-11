
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
        int CANT_SOL_TOTALES;
        int CANT_SOL_MAESTRA;
        sPieza[] LOOKUP;
        Soluciones LookSoluciones;
        Torre TORRE1;
        Torre TORRE2;
        Alfil ALFIL1;
        Alfil ALFIL2;
        Reina REINA;
        Rey REY;
        Caballo CABALLO1;
        Caballo CABALLO2;


        public Program()
        {
            CANT_SOL_TOTALES = 0;
            LOOKUP = new sPieza[8];
            LookSoluciones = new Soluciones();
        }

        public bool PosLibre(int fila, int col)
        {
            for(int i=0;i<8;i++)
            {
                if (LOOKUP[i].posicion.FILA == fila && LOOKUP[i].posicion.COL == col)
                    return false;
            }
            return true;
        }
        
        public void BuscarSoluciones()
        {
            Tablero MatrizPrueba = new Tablero(8);
            // 1 para posicion atacada | 0 libre

            //                   Cargamos ataque de las torres y guardamos la posicion en look up
            TORRE1 = new Torre(ePieza.TORRE, 0, 0);
            TORRE2 = new Torre(ePieza.TORRE, 1, 1);
            LOOKUP[0] = TORRE1.p_Torre;
            LOOKUP[1] = TORRE2.p_Torre;

            MatrizPrueba.CargarFILACOL(0);
            MatrizPrueba.CargarFILACOL(1);
            MatrizPrueba.CargarFILACOL(0, false);
            MatrizPrueba.CargarFILACOL(1, false);


            //                   Cargamos ataque de alfiles y guardamos la posicion en look up 

            Random rd = new Random(); int auxPos = rd.Next(2, 5); //llega a 5 o a 4??

            ALFIL1 = new Alfil(ePieza.ALFIL, auxPos, auxPos);

            if (auxPos == 2)
                ALFIL2 = new Alfil(ePieza.ALFIL, auxPos, auxPos + 1);
            else
                ALFIL2 = new Alfil(ePieza.ALFIL, auxPos, auxPos - 1);

            LOOKUP[2] = ALFIL1.p_alfil;
            LOOKUP[3] = ALFIL2.p_alfil;
            //ya nos aseguramos que quede uno en casilla blanca y otro en negra

            MatrizPrueba.CargarDiagonales(ALFIL1.p_alfil.posicion.FILA, ALFIL1.posicion.COL);
            MatrizPrueba.CargarDiagonales(ALFIL2.p_alfil.posicion.FILA, ALFIL2.posicion.COL);


            //                   Cargamos ataque de la reina y guardamos la posicion en look up 
            int auxCol;
            int auxFila;
            do
            {
                auxCol = rd.Next(2, 5);
                auxFila = rd.Next(2, 5);
            } while (!(MatrizPrueba.VerificarLibredeAtaque(auxFila, auxCol)));
            REINA = new Reina(ePieza.REINA, auxFila, auxCol);
            LOOKUP[4] = Reina.p_reina;
            MatrizPrueba.CargarDiagonales(REINA.p_reina.posicion.FILA, REINA.posicion.COL);
            MatrizPrueba.CargarFILACOL(auxFila);
            MatrizPrueba.CargarFILACOL(auxFila, false);

            //TODO: seguir con el rey definir la aternativa
            REY = new Rey();
            REY.BuscarPosicionRey(MatrizPrueba, LOOKUP, REY);
            LOOKUP[5] = REY.p_rey;


            CABALLO1 = new Caballo();
            CABALLO2 = new Caballo();
            CABALLO1.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO1);
            LOOKUP[6] = CABALLO1.p_caballo;
            CABALLO2.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO2);
            LOOKUP[7] = CABALLO2.p_caballo;

            
            LookSoluciones.ReproducirSoluciones(LOOKUP);
        }
        static void Main(string[] args)
        {
            var Programa = new Program();
            while (Programa.CANT_SOL_TOTALES < 10)
            {
                Programa.BuscarSoluciones();
            }
        }

    }
}
