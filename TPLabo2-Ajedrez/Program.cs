
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPLabo2_Ajedrez
{
    static class Constants
    {
        public const int SOL_A_MOSTRAR = 10;
        public const int N = 8;
    }
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
            FILA = fila;
            COL = col;
        }
        
        //get set de fila
        public int FILA 
        {
            get; set;
        }
        public int COL 
        {
            get; set;
        }
        // si fuera read only init  var p2 = p1 with { X = 3 };
    }
    public class Pieza
   {
        public ePieza pieza { get; set; }
        public sPosicion posicion;
        public Pieza(ePieza pieza_,int fila=0,int col=0)
        {
            pieza=pieza_;
            posicion=new sPosicion(fila,col);
        }
        public Pieza(Pieza Pieza)
        {
            this.pieza = Pieza.pieza;
            this.posicion = Pieza.posicion;
        }

       
        public int getFILA() { return posicion.FILA;  }
        public int getCOL() { return posicion.COL;  }
        public void setFILA(int value) { posicion.FILA=value; }
        public void setCOL(int value) {posicion.COL=value; }
    }
    public class Program
    {
        Torre TORRE1;
        Torre TORRE2;
        Alfil ALFIL1;
        Alfil ALFIL2;
        Reina REINA;
        Rey REY;
        Caballo CABALLO1;
        Caballo CABALLO2;
        Pieza[] LOOKUP;
        //vector que guarda cada pieza y su posicion en la matriz
        
        public Soluciones LookSoluciones;
        public static int CANT_SOL_TOTALES;

        public Program()
        {
            CANT_SOL_TOTALES = 0;
            LOOKUP = new Pieza[8];
            LookSoluciones = new Soluciones();
        }
        

        public void BuscarSoluciones()
        {
            Tablero MatrizPrueba = new Tablero(8); // en cada casilla: 1 (atacada) | 0 (libre)


            //--------------------------------- Creamos, cargamos a matriz y guardamos en lookup TORRES --------------------------------------

            TORRE1 = new Torre(ePieza.TORRE, 0, 0);
            TORRE2 = new Torre(ePieza.TORRE, 1, 1);
            LOOKUP[0] = TORRE1;
            LOOKUP[1] = TORRE2;

            MatrizPrueba.CargarFILACOL(0);
            MatrizPrueba.CargarFILACOL(1);
            MatrizPrueba.CargarFILACOL(0, false);
            MatrizPrueba.CargarFILACOL(1, false);


            //-------------------------------- Creamos, cargamos a matriz y guardamos en lookup ALFILES -------------------------------------------

            // Los posicionaremos de manera que queden dentro de un 3x4 casi centrado en medio del tablero

            Random rd_col = new Random();
            int auxCol = rd_col.Next(3, 6);    //random de 3 a 5 para col
            Random rd_fila = new Random(); 
            int auxFila = rd_fila.Next(3, 7);  //random de 3 a 6 para fila

            
            ALFIL1 = new Alfil(ePieza.ALFIL, auxFila, auxCol); // creamos ALFIL1 y lo colocamos en esa pos


            //ALFIL2 se coloca arriba o abajo del ALFIL1 segun los limites del rectangulo 3x4
            if (auxFila < 6)
            {
                ALFIL2 = new Alfil(ePieza.ALFIL, auxFila + 1, auxCol);
                MatrizPrueba.matriz[auxFila+1, auxCol] = 1;
            }
            else
            {
                ALFIL2 = new Alfil(ePieza.ALFIL, auxFila - 1, auxCol);
                MatrizPrueba.matriz[auxFila-1, auxCol] = 1;
            }


            LOOKUP[2] = ALFIL1;
            LOOKUP[3] = ALFIL2;

            MatrizPrueba.CargarDiagonales(ALFIL1.getFILA(), ALFIL1.getCOL());
            MatrizPrueba.CargarDiagonales(ALFIL2.getFILA(), ALFIL2.getCOL());



            //-------------------------------- Creamos, cargamos a matriz y guardamos en lookup REINA ------------------------------------------

            // Cargamos a la reina en = columna que alfiles, justo abajo o arriba de ellos. La fila depende de la pos de los alfiles y el 3x4 :

            if (ALFIL1.getFILA() < 6)  // si entra ALFIL2 esta debajo de ALFIL1
            {
                if(ALFIL2.getFILA() < 6)
                {
                    auxFila = ALFIL2.getFILA() + 1;
                }
                else
                {
                    auxFila = ALFIL1.getFILA() - 1;
                }
            }
            else // sino ALFIL1 en fila 6 y ALFIL2 en fila 5
            {
                auxFila = ALFIL2.getFILA() - 1;
            }
            

            REINA = new Reina(ePieza.REINA, auxFila, auxCol);
            LOOKUP[4] = REINA;
            MatrizPrueba.CargarDiagonales(REINA.getFILA(), REINA.getCOL());
            MatrizPrueba.CargarFILACOL(REINA.getFILA());
            MatrizPrueba.CargarFILACOL(REINA.getCOL(), false);


            //-------------------------------- Creamos, cargamos a matriz y guardamos en lookup REY -----------------------------------------------------

            REY = new Rey();

            REY.BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, 0,2,2);
            
            MatrizPrueba.matriz[REY.getFILA(), REY.getCOL()] = 1;
            REY.CargarPosRey(MatrizPrueba, REY.getFILA(), REY.getCOL());

            LOOKUP[5] = REY;


            //-------------------------------- Creamos, cargamos a matriz y guardamos en lookup CABALLOS -----------------------------------------------------

            CABALLO1 = new Caballo();
            CABALLO2 = new Caballo();

            CABALLO1.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO1);
            
            MatrizPrueba.matriz[CABALLO1.getFILA(), CABALLO1.getCOL()] = 1;
            CABALLO1.CargarPosCaballo(MatrizPrueba, CABALLO1.getFILA(), CABALLO1.getCOL());
            LOOKUP[6] = CABALLO1;

            CABALLO2.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO2);
            MatrizPrueba.matriz[CABALLO2.getFILA(), CABALLO2.getCOL()] = 1;
            CABALLO2.CargarPosCaballo(MatrizPrueba, CABALLO2.getFILA(), CABALLO2.getCOL());
            LOOKUP[7] = CABALLO2;
            

            if (LookSoluciones.SolucionExistente(LOOKUP)) //chequeamos que no sea una solucion existente --- tendriamos que agregar algo que borre objetos viejos de los ya instanciado?
                BuscarSoluciones();
            
            LookSoluciones.ReproducirSoluciones(LOOKUP);

        }


        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var Programa = new Program();
            Application.Run(new MainForm(Programa));

        }


    }
}
