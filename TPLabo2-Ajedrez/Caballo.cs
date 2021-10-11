using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Caballo
    {
        static int N = 6;
        int cont = 0;
        //Constructor de clase Caballo
        public Caballo()
        {
            sPieza p_caballo = new sPieza(ePieza.CABALLO);
        }
        public sPieza p_caballo { get { return p_caballo; } }
        //Función para posicionar caballos en el tablero
        bool PosicionarCaballos(bool [,] MatrizPrueba , sPieza [] LOOKUP, sPieza CABALLO)
        {
            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, 0, 0);//Probamos casilla por casilla cuál es la mejor posición
            if (contarVacias(MatrizPrueba, 0) != 0) return false;//Si en la posición donde pusimos al caballo quedan más de ... casillas vacias, no lo ponemos ahi
            else return true;//Si esta bien ahí, lo dejamos en esa posición
        }
        void RecursividadCaballo(bool[,] MatrizPrueba, sPieza[] LOOKUP, sPieza CABALLO, int i, int j)
        {
            int NLibres = 0;
            if(i >= 0 && i < N && j >= 0 && j < N)
            {
                if(PosLibre(LOOKUP, i, j))//Si en la casilla [i,j] no hay otra pieza posicionadam es una posición válida que hay que verificar si sirve
                {
                    //Posisionamos el caballo ahí
                    sPosicion pos = new sPosicion(i, j);
                    CABALLO.posicion = pos;
                }
                cont = VerificarPosCaballo(MatrizPrueba, CABALLO);//Verificamos cuántas casillas ocuparía el caballo posicionado de esta forma
                if (LOOKUP[6].pieza == ePieza.LIBRE) NLibres = 5;//Si estamos posicionando al primer caballo, entonces las casillas libres serían 5 o menos
                else NLibres = 3;//Si estamos posicionando el segundo, las casillas libres son menos
                if(contarVacias(MatrizPrueba) - cont > NLibres)//Si las casillas 
                {
                    if (i == N - 1)
                    {
                        i = 0;
                        j++;
                    }
                    else i++;
                }
            }
            else
            {
                if (i == N - 1)
                {
                    i = 0;
                    j++;
                }
                else i++;
            }
            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, i, j);
        }
        int VerificarPosCaballo(bool [,] MatrizPrueba, sPieza CABALLO)
        {
            cont = 8;
            if(CABALLO.posicion.FILA + 1 < N)
            {
                if (CABALLO.posicion.COL - 2 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 1, CABALLO.posicion.COL - 2]);
                if (CABALLO.posicion.COL + 2 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 1, CABALLO.posicion.COL + 2]);
                if(CABALLO.posicion.FILA + 2 < N)
                {
                    if (CABALLO.posicion.COL - 1 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 2, CABALLO.posicion.COL - 1]);
                    if (CABALLO.posicion.COL + 1 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 2, CABALLO.posicion.COL + 1]);
                }
            }
            if(CABALLO.posicion.FILA - 1 > 1)
            {
                if (CABALLO.posicion.COL - 2 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 1, CABALLO.posicion.COL - 2]);
                if (CABALLO.posicion.COL + 2 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 1, CABALLO.posicion.COL + 2]);
                if(CABALLO.posicion.FILA - 2 < 1)
                {
                    if (CABALLO.posicion.COL - 1 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 2, CABALLO.posicion.COL - 1]);
                    if (CABALLO.posicion.COL + 1 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 2, CABALLO.posicion.COL + 1]);
                }
            }
            return cont;
        }
    }
}
