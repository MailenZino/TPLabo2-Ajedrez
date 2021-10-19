
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //constructor
        public sPosicion(int fila=0, int col=0)
        {
            int FILA = fila;
            int COL = col;
        }
        
        //get set de fila
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
   public class Pieza
   {
        public ePieza pieza { get; }
        public sPosicion posicion;
        public Pieza(ePieza pieza_,int fila=0,int col=0)
        {
            pieza=pieza_;
            posicion=new sPosicion(fila,col);
        }

       
        public int FILA { get { return posicion.FILA; } set { posicion.FILA = value; } }
        public int COL { get { return posicion.COL; } set { posicion.COL = value; } }
    }
    public class Program
    {
        public static int CANT_SOL_TOTALES;
        Pieza[] LOOKUP;
        public Soluciones LookSoluciones;
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
            LOOKUP = new Pieza[8];
            LookSoluciones = new Soluciones();
        }
        
        public void BuscarSoluciones()
        {
            Tablero MatrizPrueba = new Tablero(8);
            // 1 para posicion atacada | 0 libre

            //                   Cargamos ataque de las torres y guardamos la posicion en look up
            TORRE1 = new Torre(ePieza.TORRE, 0, 0);
            TORRE2 = new Torre(ePieza.TORRE, 1, 1);
            LOOKUP[0] = TORRE1;
            LOOKUP[1] = TORRE2;

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

            LOOKUP[2] = ALFIL1;
            LOOKUP[3] = ALFIL2;
            //ya nos aseguramos que quede uno en casilla blanca y otro en negra

            MatrizPrueba.CargarDiagonales(ALFIL1.FILA, ALFIL1.COL);
            MatrizPrueba.CargarDiagonales(ALFIL2.FILA, ALFIL2.COL);


            //                   Cargamos ataque de la reina y guardamos la posicion en look up 
            int auxCol;
            int auxFila;
            do
            {
                auxCol = rd.Next(2, 5);
                auxFila = rd.Next(2, 5);
            } while (!(MatrizPrueba.VerificarLibredeAtaque(auxFila, auxCol))); 
            // no ponemos a la reina donde pueda ser atacada por alfiles porque no tiene sol

            REINA = new Reina(ePieza.REINA, auxFila, auxCol);
            LOOKUP[4] = REINA;
            MatrizPrueba.CargarDiagonales(REINA.posicion.FILA, REINA.posicion.COL);
            MatrizPrueba.CargarFILACOL(auxFila);
            MatrizPrueba.CargarFILACOL(auxFila, false);

            //TODO: seguir con el rey definir la aternativa
            REY = new Rey();
            REY.BuscarPosicionRey(MatrizPrueba, LOOKUP, REY,0,0,0);
            LOOKUP[5] = REY;


            CABALLO1 = new Caballo();
            CABALLO2 = new Caballo();
            CABALLO1.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO1);
            LOOKUP[6] = CABALLO1;
            CABALLO2.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO2);
            LOOKUP[7] = CABALLO2;

            if (LookSoluciones.SolucionExistente(LOOKUP))
                BuscarSoluciones();
            
            LookSoluciones.ReproducirSoluciones(LOOKUP);
        }
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var Programa = new Program();
            Application.Run(new MainForm(Programa));

            //while (CANT_SOL_TOTALES < 10)
            //{
            //    Programa.BuscarSoluciones();
            //}
        }


    }
}
