
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

       
        public int getFILA() { return posicion.FILA;  }
        public int getCOL() { return posicion.COL;  }
        public void setFILA(int value) { posicion.FILA=value; }
        public void setCOL(int value) {posicion.COL=value; }
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
            //Posicionamos a los alfiles de mandera que queden dentro de un rectángulo de 3x4 casi centrado en el medio del tablero
            Random rd_col = new Random(); int auxCol = rd_col.Next(3, 6); //random de 3 a 5
            Random rd_fila = new Random(); int auxFila = rd_fila.Next(3, 7);//random de 3 a 6
            ALFIL1 = new Alfil(ePieza.ALFIL, auxFila, auxCol);//cargamos al alfil 1 en esa posicion
            MatrizPrueba.matriz[auxFila, auxCol] = 1; //Cargamos la posicion del aflil como atacada
            //Ponemos al segudno alfil arriba o abajo del otro siempre respetando nuestro rectangulo
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
            //ya nos aseguramos que quede uno en casilla blanca y otro en negra
            MatrizPrueba.CargarDiagonales(ALFIL1.getFILA(), ALFIL1.getCOL());
            MatrizPrueba.CargarDiagonales(ALFIL2.getFILA(), ALFIL2.getCOL());


            //                   Cargamos ataque de la reina y guardamos la posicion en look up 
            //do
            //{
            //    auxFila = rd_fila.Next(2, 5);

            //} while (!(MatrizPrueba.VerificarLibredeAtaque(auxFila, auxCol))||!(MatrizPrueba.PosLibre(LOOKUP,auxFila,auxCol))); 
            if(ALFIL1.getFILA() < 6) //Se cargó al alfil 2 debajo del alfil 1
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
            else//alfil 1 esta en fila 6 y alfil2 esta en fila 5
            {
                auxFila = ALFIL2.getFILA() - 1;
            }
            // no ponemos a la reina donde pueda ser atacada por alfiles porque no tiene sol ni donde haya otra ficha

            REINA = new Reina(ePieza.REINA, auxFila, auxCol);//La reina la cargamos en la misma columna que los alfiles, justo abajo o arriba de ellos
            LOOKUP[4] = REINA;
            MatrizPrueba.matriz[REINA.getFILA(), REINA.getCOL()] = 1;
            MatrizPrueba.CargarDiagonales(REINA.posicion.FILA, REINA.posicion.COL);
            MatrizPrueba.CargarFILACOL(auxFila);
            MatrizPrueba.CargarFILACOL(auxFila, false);

            
            REY = new Rey();
            REY.BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, 0,2,2);
            LOOKUP[5] = REY;
            REY.CargarPosRey(MatrizPrueba);
            MatrizPrueba.matriz[REY.getFILA(), REY.getCOL()] = 1;


            CABALLO1 = new Caballo();
            CABALLO2 = new Caballo();
            CABALLO1.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO1);
            LOOKUP[6] = CABALLO1;
            MatrizPrueba.matriz[CABALLO1.getFILA(), CABALLO1.getCOL()] = 1;
            CABALLO2.PosicionarCaballos(MatrizPrueba, LOOKUP, CABALLO2);
            LOOKUP[7] = CABALLO2;
            MatrizPrueba.matriz[CABALLO2.getFILA(), CABALLO2.getCOL()] = 1;

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

        }


    }
}
